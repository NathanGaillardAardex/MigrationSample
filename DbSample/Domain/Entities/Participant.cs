using System.ComponentModel.DataAnnotations.Schema;

namespace DbSample.Domain.Entities;

public record Participant : EntityBase
{
    [Column(TypeName = "jsonb")]
    public Regimen? Regimen { get; set; }
    
    public required Guid ProjectId { get; set; }
    public Project Project { get; set; }
    
    // Add site
    public required Guid SiteId { get; set; }
    public Site Site { get; set; }
}