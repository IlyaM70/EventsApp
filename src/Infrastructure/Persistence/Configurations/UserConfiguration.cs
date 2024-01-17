using EventsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsApp.Infrastructure.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x=>x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.UserName)
        .HasMaxLength(30)
        .IsRequired();

        builder.Property(x => x.Gender)
        .IsRequired();
    }
}
