using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Data
{
    public class ApplicationDbContext : IdentityDbContext<ChatUser>
    {
        private bool seedDb = true;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
            this.Database.EnsureCreated();
        }

        public DbSet<ChatRoom> ChatRooms { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<ChatRoomUser> ChatRoomsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatRoomUser>()
                .HasKey(cu => new { cu.ChatRoomId, UserId = cu.ChatUserId });

            builder
                .Entity<ChatRoom>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.IsOwnerOf)
                .HasForeignKey(t => t.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Message>()
                .HasOne(t => t.ChatRoom)
                .WithMany(b => b.Messages)
                .HasForeignKey(t => t.ChatRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            if (seedDb)
            {
                ChatRoomSeed.SeedDatabase(builder);
            }

            base.OnModelCreating(builder);
        }
    }
}
