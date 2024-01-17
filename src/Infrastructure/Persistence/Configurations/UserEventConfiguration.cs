using EventsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsApp.Infrastructure.Persistence.Configurations;
public class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
{
    public void Configure(EntityTypeBuilder<UserEvent> builder)
    {
        #region Relation
        //Primary Key
        builder.HasKey(ue => new { ue.UserId,ue.EventId });
        // Many to Many Relation User and Event
        builder.HasOne<User>(ue => ue.User)
            .WithMany(u=> u.UserEvents)
            .HasForeignKey(ue => ue.UserId);

        builder.HasOne<Event>(ue => ue.Event)
        .WithMany(u => u.UserEvents)
        .HasForeignKey( ue => ue.EventId);
        #endregion
    }
}
