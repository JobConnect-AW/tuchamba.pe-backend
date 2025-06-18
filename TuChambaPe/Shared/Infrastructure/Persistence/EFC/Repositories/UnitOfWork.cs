﻿using LearningCenterPlatform.Shared.Domain.Repositories;
using LearningCenterPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
namespace LearningCenterPlatform.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
