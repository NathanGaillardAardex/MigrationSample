namespace DbSample.Domain.Entities;

// Add site
public record Site : EntityBase
{
    public required Guid ProjectId { get; init; }
    public Project Project { get; set; }
    
    public required string Name { get; set; }
    
    public List<Participant> Participants { get; init; }
}