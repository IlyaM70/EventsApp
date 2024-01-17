using EventsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsApp.Infrastructure.Persistence.Configurations;
public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        #region Relation
        // One to many Event and SubEvents
        builder.HasOne<Event>(e => e.MainEvent)
            .WithMany(me => me.SubEvents)
            .HasForeignKey(e => e.MainEventId);

        // One to many created Events and User
        builder.HasOne<User>(u => u.Creater)
            .WithMany(ce=>ce.CreatedEvents)
            .HasForeignKey(u => u.CreaterId);

        // One to many Category and Event
        builder.HasOne<Category>(u => u.Category)
            .WithMany(c => c.Events)
            .HasForeignKey(u => u.CategoryId);
        #endregion

        #region Requirements
        // /////////////////////////Name
        builder.Property(x=>x.Name)
            .HasMaxLength(50)
            .IsRequired();
        // /////////////////////////Description
        builder.Property(x => x.Description)
            .HasMaxLength(500);
        // /////////////////////////Address
        builder.Property(x => x.Address)
            .HasMaxLength(200)
            .IsRequired();
        // /////////////////////////MinPersons
        builder.Property(x => x.MinPersons)
            .HasDefaultValue(2);
        // /////////////////////////MaxPersons
        builder.Property(x => x.MaxPersons)
            .HasDefaultValue(2);
        // /////////////////////////MinAge
        builder.Property(x => x.MinAge)
            .HasDefaultValue(0);
        // /////////////////////////MaxAge
        builder.Property(x => x.MaxAge)
            .HasDefaultValue(120);
        // /////////////////////////ApplicationsDue
        builder.Property(x => x.ApplicationsDue)
            .IsRequired();
        // /////////////////////////Begining
        builder.Property(x => x.Begining)
            .IsRequired();
        // /////////////////////////Ending
        builder.Property(x => x.Ending)
            .IsRequired();
        // /////////////////////////Created
        builder.Property(x => x.Created)
            .HasDefaultValue(DateTime.UtcNow);
        // /////////////////////////Updated
        builder.Property(x => x.Updated)
            .HasDefaultValue(DateTime.UtcNow);
        // /////////////////////////IsCommercial
        builder.Property(x => x.IsCommercial)
            .HasDefaultValue(false);
        #endregion

    }
}
