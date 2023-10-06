using Microsoft.EntityFrameworkCore;
using BlueLight.Data.Models;
using Microsoft.Identity.Client;

namespace BlueLight.Data;

[Coalesce]
public class AppDbContext : DbContext
{
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();

    public DbSet<Event> Events => Set<Event>();
    public DbSet<EventTime> EventTimes => Set<EventTime>();
    public DbSet<EventRegistration> EventRegistrations => Set<EventRegistration>();
    

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Remove cascading deletes.
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
