using Cortex.Mediator.Behaviors;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TuChambaPe.IAM.Application.Internal.CommandServices;
using TuChambaPe.IAM.Application.Internal.OutboundServices;
using TuChambaPe.IAM.Application.Internal.QueryServices;
using TuChambaPe.IAM.Domain.Repositories;
using TuChambaPe.IAM.Domain.Services;
using TuChambaPe.IAM.Infrastructure.Hashing.BCrypt.Services;
using TuChambaPe.IAM.Infrastructure.Persistence.EFC.Repositories;
using TuChambaPe.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using TuChambaPe.IAM.Infrastructure.Tokens.JWT.Configuration;
using TuChambaPe.IAM.Infrastructure.Tokens.JWT.Services;
using TuChambaPe.IAM.Interfaces.ACL;
using TuChambaPe.IAM.Interfaces.ACL.Services;
using TuChambaPe.Offers.Application.Internal.CommandServices;
using TuChambaPe.Offers.Application.Internal.QueryServices;
using TuChambaPe.Offers.Domain.Repositories;
using TuChambaPe.Offers.Domain.Services;
using TuChambaPe.Offers.Infrastructure.Persistence.EFC.Repositories;
using TuChambaPe.Shared.Domain.Repositories;
using TuChambaPe.Shared.Infrastructure.Interfaces.ASP.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Configuration;
using TuChambaPe.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

System.Console.Write(connectionString);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)))
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Register repositories
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "ACME.TuChambaPe.API",
            Version = "v1",
            Description = "ACME Tu Chamba.pe API",
            TermsOfService = new Uri("https://acme-learning.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "ACME Studios",
                Email = "adoa2705@gmail.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
    options.EnableAnnotations();
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// IAM Bounded Context Injection Configuration
// TokenSettings Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferCommandService, OfferCommandService>();
builder.Services.AddScoped<IOfferQueryService, OfferQueryService>();

// Add Mediator Injection Configuration
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: new[] { typeof(Program) }, configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
        //options.AddDefaultBehaviors();
    });


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    //context.Database.EnsureCreated();
    await context.Database.MigrateAsync();
}


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; // Opcional: para que Swagger sea la p�gina ra�z
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);

    });

}

app.UseCors("AllowAllPolicy");

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
