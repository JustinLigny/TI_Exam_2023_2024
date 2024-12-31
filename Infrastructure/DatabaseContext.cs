using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DatabaseContext: DbContext
{
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbPublication> Publications { get; set; }
    
    public DbSet<DbInvitation> Invitations { get; set; }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>(builder =>
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Pseudo);
            builder.Property(x => x.Role);
            
            builder.HasMany(u => u.Publications)
                .WithOne(p => p.CreatedByUser)
                .HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(u => u.InvitationsAsSender)
                .WithOne(p => p.UserSender)
                .HasForeignKey(x => x.UserSenderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(u => u.InvitationsAsInvited)
                .WithOne(p => p.UserInvited)
                .HasForeignKey(x => x.UserInvitedId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<DbPublication>(builder =>
        {
            builder.ToTable("Publications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Title);
            builder.Property(x => x.Content);
            builder.Property(x => x.CreatedAt);

            builder.HasOne(x => x.CreatedByUser)
                .WithMany(u => u.Publications)
                .HasForeignKey(x => x.CreatedByUserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<DbInvitation>(builder =>
        {
            builder.ToTable("Invitations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.Status);

            builder.HasOne(x => x.UserSender)
                .WithMany(u => u.InvitationsAsSender)
                .HasForeignKey(x => x.UserSenderId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(x => x.UserInvited)
                .WithMany(u => u.InvitationsAsInvited)
                .HasForeignKey(x => x.UserInvitedId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}