using DbSample.Domain.Entities;
using DbSample.Migrations;
using Microsoft.EntityFrameworkCore;

const string connectionString = "Host=localhost;Port=5432;Database=DbSample;Username=postgres;Password=admin";

using var context = new ApplicationDbContext(connectionString);

var project = new Project()
{
    CreatedAt = DateTime.UtcNow,
    Id = Guid.NewGuid(),
    Protocol = "sample",
    UpdatedAt = DateTime.UtcNow
};
context.Projects.Add(project);
Console.WriteLine($"Wrote: {context.SaveChanges()}");

var site = new Site()
{
    CreatedAt = DateTime.UtcNow,
    Id = Guid.NewGuid(),
    ProjectId = project.Id,
    UpdatedAt = DateTime.UtcNow,
    Name = "Sample Site"
};
context.Sites.Add(site);
Console.WriteLine($"Wrote: {context.SaveChanges()}");

var newParticipants = new List<Participant>(3);
for (var i = 0; i<newParticipants.Capacity; i++)
{
    newParticipants.Add(new Participant
    {
        CreatedAt = DateTime.UtcNow,
        Id = Guid.NewGuid(),
        ProjectId = project.Id,
        UpdatedAt = DateTime.UtcNow,
        Regimen = new Regimen("QID",
            "Four times a day"),
        SiteId = site.Id
    });
}
context.Participants.AddRange(newParticipants);
Console.WriteLine($"Wrote: {context.SaveChanges()}");

var projects = context.Projects.ToList();
var sites = context.Sites.Include(s => s.Participants).ToList();
var participants = context.Participants.Include(p=> p.Project).ToList();
foreach (var p in projects)
{
    Console.WriteLine(p.ToString());
}
foreach (var s in sites)
{
    Console.WriteLine(s.ToString());
}
foreach (var p in participants)
{
    Console.WriteLine(p.ToString());
}