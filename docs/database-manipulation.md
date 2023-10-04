# Database Manipulation

The database has been setup using the code-first approach. This means that any alterations (to both structure or data) are managed using EF migrations.

Use the following commands:

- Add migration:

  `dotnet ef --startup-project ./SmartMeterLogger.Api --project ./SmartMeterLogger.Data migrations add {NAME}`

- Remove migration

  `dotnet ef --startup-project ./SmartMeterLogger.Api --project ./SmartMeterLogger.Data migrations remove`

- Update database

  `dotnet ef --startup-project ./SmartMeterLogger.Api --project ./SmartMeterLogger.Data database update`

- Partual database update or rollback to target migration

  `dotnet ef --startup-project ./SmartMeterLogger.Api --project ./SmartMeterLogger.Data database update {TARGET MIGRATION}`
