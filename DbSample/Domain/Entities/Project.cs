namespace DbSample.Domain.Entities;

public record Project : EntityBase
{
    // Initial variables
    public required string Protocol { get; set; }
    
    public List<Participant> Participants { get; set; }
    public List<Site> Sites { get; set; }
}