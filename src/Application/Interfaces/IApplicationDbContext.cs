using EventsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsApp.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<Event> Events { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserEvent> UserEvents { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
