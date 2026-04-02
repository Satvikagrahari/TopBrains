using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Data;

public class NotificationDbContext : DbContext
{
    public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }
    public DbSet<NotificationLog> NotificationLogs => Set<NotificationLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<NotificationLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Channel).HasMaxLength(20);
            e.Property(x => x.Recipient).HasMaxLength(200);
            e.Property(x => x.Subject).HasMaxLength(200);
        });
    }
}
