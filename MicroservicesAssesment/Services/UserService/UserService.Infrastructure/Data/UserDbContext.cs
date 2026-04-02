using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data;

public class UserDbContext : IdentityDbContext<ApplicationUser>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    public DbSet<OtpRecord> OtpRecords => Set<OtpRecord>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<OtpRecord>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.OtpCode).HasMaxLength(10);
            e.Property(x => x.Purpose).HasMaxLength(50);
            e.Property(x => x.Channel).HasMaxLength(20);
            e.HasIndex(x => new { x.UserId, x.Purpose });
        });

        builder.Entity<ApplicationUser>(e =>
        {
            e.Property(x => x.FirstName).HasMaxLength(50);
            e.Property(x => x.LastName).HasMaxLength(50);
        });
    }
}