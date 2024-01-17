using System.Reflection;
using Microsoft.EntityFrameworkCore;
using EventsApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EventsApp.Application.Interfaces;

namespace EventsApp.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>,int>,IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Event> Events { get;set; }
    public DbSet<UserEvent> UserEvents { get;set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
