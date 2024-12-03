namespace DbSample.Migrations;

public sealed class MigrationsDbContext : ApplicationDbContext
{
    public MigrationsDbContext() : base("Host=localhost;Port=5432;Database=DbSample;Username=postgres;Password=admin")
    {
    }
}