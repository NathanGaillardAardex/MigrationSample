namespace DbSample.Domain.Entities;

public abstract record EntityBase
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }
}