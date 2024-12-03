# Database Migrations Management

This is a sample project using the recommended structure for production database migrations management.

## Structure

- **DbSample**: The main class library project. It contains the domain and infrastructure of the application.
    - **DbSample.Domain.Entities**: The domain entities of the project. Checkout the comments to understand the
      evolution entities throughout the migration. This is done for sample purposes, the comments are not necessary in a
      real project.
    - **DbSample.Infrastructure**: The infrastructure of the project. It contains the database context.
- **DbSample**: The class library project that contains the database migrations. It is easier to use a separate project
  for migrations to better isolate the EF migration classes and SQL scripts. This project references the main project.
- **DbSample.ConsoleApp**: The test project of the main project.
- **DbSample.Migration**: The project containing the generated migration classes and SQL scripts. It references the main
  project. It is important that this project is not referenced by the main project and contains a runnable DbContext.

# How to apply the migrations

[Documentation](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli)

## General principles

The migration projects needs an active connection to a database. This is achieved by creating a inheritor of
ApplicationDbContext with a valid connection string. All following dotnet ef commands must be run in the migration
project. All changes to the model are made in the main project.

## Creating a migration

1. Implement your entities model changes in the main project.
2. Check if your model has pending changes: ``dotnet ef migrations has-pending-model-changes``
    1. If the model entities have changed, the command shall
       return ``Changes have been made to the model since the last migration. Add a new migration.``
3. Create a EF migration with the following command: ``dotnet ef migrations add <MigrationName>``
    1. This command must be run in the migration project.
    2. The first migration is usually named InitialCreate.
    3. Following migrations are created by comparing the current model with the last migration. They are usually named
       after the changes they introduce.
4. Check the migration code, especially if it contains data manipulation, column renaming, or other complex operations. You should correct it if necessary, while addind necessary comments.
5. Check the non-pending migration by running: ``dotnet ef migrations list``
6. Generate the incremental SQL script for the migration with the following
   command: ``dotnet ef migrations script <PreviousNonPendingLatestMigration> --idempotent -o migrations/<Timestamp_MigrationName>.sql``
    1. This creates a migration script that can be run on an up-to-date database.
    2. The script is idempotent, meaning it is meant to run multiple times without causing errors. However, the
       generated code should be checked and corrected if necessary.
        1. The first migration script does not need the <PreviousLatestMigration> parameter.
    3. You should thoroughly review the script, especially if it contains data manipulation, column renaming, or
       other complex operations, as **EF core migrations are by default NOT PREVENTING DATA LOSS**. Please add
       comments when modifying the generated script.
    4. The script is idempotent, meaning it is meant to run multiple times without causing errors. However, this fact
       should be checked and corrected if necessary.

### Applying migrations at a developer level

It is your responsibility to apply the migrations to your developer database. This is done via PGAdmin:

1. Connect to your server, and navigate to the target database.
2. Check applied migrations in the table ``__EFMigrationsHistory`` against the list of migrations in the migration
   project.
3. Open the Query Tool.
4. For each non-applied migration:
    1. Copy/Paste the SQL script in the migration project to the query editor.
    2. Execute the script.
5. Check applied migrations status with the following command: ``dotnet ef migrations list``
    1. All migrations should be applied to your database.

### Applying migrations to a specific environment
Before applying migrations to online databases, always test the migration locally and backup the database.
#### Alpha

#### Beta

#### Production
