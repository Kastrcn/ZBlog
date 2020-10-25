dotnet tool install dotnet-ef -g
dotnet ef migrations add initialMigration
dotnet ef database update
