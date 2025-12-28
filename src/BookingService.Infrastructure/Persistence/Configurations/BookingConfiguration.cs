using BookingService.Domain.Entities;
using BookingService.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("bookings");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnName("id");

        builder.Property(b => b.ResourceId)
            .HasColumnName("resource_id")
            .IsRequired();

        builder.Property(b => b.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(b => b.StartUtc)
            .HasColumnName("start_utc")
            .IsRequired();

        builder.Property(b => b.EndUtc)
            .HasColumnName("end_utc")
            .IsRequired();

        builder.Property(b => b.Status)
            .HasColumnName("status")
            .HasConversion<int>()
            .IsRequired();
    }
}