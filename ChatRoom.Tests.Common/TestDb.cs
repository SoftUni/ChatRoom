using System;

using ChatRoom.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Tests.Common
{
    public class TestDb
    {
        private string uniqueDbName;

        public TestDb()
        {
            this.uniqueDbName = $"ChatRoom-TestDb-{DateTime.Now.Ticks}";
            this.SeedDatabase();
        }

        public ChatUser GuestUser { get; private set; }

        public ChatUser GuestUserTwo { get; private set; }

        public ChatUser UserMaria { get; private set; }

        public Data.ChatRoom LondonChatRoom { get; private set; }

        public Data.ChatRoom UniChatRoom { get; private set; }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            optionsBuilder.UseInMemoryDatabase(uniqueDbName);

            return new ApplicationDbContext(optionsBuilder.Options, false);
        }

        private void SeedDatabase()
        {
            ApplicationDbContext dbContext = this.CreateDbContext();
            UserStore<ChatUser> userStore = new UserStore<ChatUser>(dbContext);
            PasswordHasher<ChatUser> hasher = new PasswordHasher<ChatUser>();
            UpperInvariantLookupNormalizer normalizer = new UpperInvariantLookupNormalizer();
            UserManager<ChatUser> userManager = new UserManager<ChatUser>(
                userStore, null, hasher, null, null, normalizer, null, null, null);

            // Create GuestUser
            this.GuestUser = new ChatUser
            {
                UserName = $"guest{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"guest{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
            };
            userManager
                .CreateAsync(this.GuestUser, this.GuestUser.UserName)
                .Wait();

            // Create GuestUserTwo
            this.GuestUserTwo = new ChatUser
            {
                UserName = $"guestTwo{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"guesttwo{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "guestTwo@mail.com",
                NormalizedEmail = "guesttwo@mail.com",
            };
            userManager
                .CreateAsync(this.GuestUserTwo, this.GuestUserTwo.UserName)
                .Wait();

            // Create UserMaria
            this.UserMaria = new ChatUser
            {
                UserName = $"Maria{DateTime.Now.Ticks.ToString().Substring(10)}",
                NormalizedUserName = $"maria{DateTime.Now.Ticks.ToString().Substring(10)}",
                Email = "maria@mail.com",
                NormalizedEmail = "maria@mail.com",
            };
            userManager
                .CreateAsync(this.UserMaria, this.UserMaria.UserName)
                .Wait();

            // GuestUser has LondonChatRoom
            this.LondonChatRoom = new Data.ChatRoom
            {
                Id = 1,
                Name = "Our Journey to London",
                OwnerId = this.GuestUser.Id,
            };
            dbContext.Add(this.LondonChatRoom);

            // GuestUserTwo has UniChatRoom
            this.UniChatRoom = new Data.ChatRoom
            {
                Id = 2,
                Name = "Informatics University Group",
                OwnerId = this.GuestUserTwo.Id,
            };
            dbContext.Add(this.UniChatRoom);

            dbContext.AddRange(new ChatRoomUser
            {
                ChatRoomId = this.LondonChatRoom.Id,
                ChatUserId = this.GuestUser.Id,
            },
            new ChatRoomUser
            {
                ChatRoomId = this.LondonChatRoom.Id,
                ChatUserId = this.GuestUserTwo.Id,
            },
            new ChatRoomUser
            {
                ChatRoomId = this.UniChatRoom.Id,
                ChatUserId = this.GuestUser.Id,
            },
            new ChatRoomUser
            {
                ChatRoomId = this.UniChatRoom.Id,
                ChatUserId = this.GuestUserTwo.Id,
            });

            dbContext.SaveChanges();
        }
    }
}
