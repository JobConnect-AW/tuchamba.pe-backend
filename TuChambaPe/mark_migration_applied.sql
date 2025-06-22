-- Script para marcar la migración como aplicada sin tocar datos existentes
-- Este script es seguro y no afecta los datos existentes

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) 
VALUES ('20250621221845_AddOffersAndUniqueUids', '8.0.17')
ON DUPLICATE KEY UPDATE `ProductVersion` = '8.0.17'; 