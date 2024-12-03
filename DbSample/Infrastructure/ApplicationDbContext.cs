using DbSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace DbSample.Migrations;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;
    
    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public DbSet<Project> Projects { get; init; }
    public DbSet<Participant> Participants { get; init; }
    public DbSet<Site> Sites { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(_connectionString);
        dataSourceBuilder.EnableDynamicJson();
        optionsBuilder
            .UseNpgsql(dataSourceBuilder.Build())
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information);
    }
}