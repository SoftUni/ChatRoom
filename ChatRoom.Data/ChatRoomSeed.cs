using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Data
{
    public class ChatRoomSeed
    {
        public static void SeedDatabase(ModelBuilder builder)
        {
            ChatUser guestUser;
            ChatUser guestTwoUser;
            ChatUser mariaUser;
            ChatRoom londonChatRoom;
            ChatRoom uniChatRoom;

            SeedUsers();
            SeedChatRooms();
            builder.Entity<ChatUser>()
                .HasData(guestUser, guestTwoUser, mariaUser);

            builder
                .Entity<ChatRoom>()
                .HasData(londonChatRoom, uniChatRoom);

            builder
                .Entity<Message>()
                .HasData(new Message
                {
                    Id = 1,
                    Content = "Hello Guest Two",
                    OwnerId = guestUser.Id,
                    ChatRoomId = londonChatRoom.Id
                },
                new Message
                {
                    Id = 2,
                    Content = "Hello Guest!",
                    OwnerId = guestTwoUser.Id,
                    ChatRoomId = londonChatRoom.Id
                },
                new Message
                {
                    Id = 3,
                    Content = "We need to finish building this app!",
                    OwnerId = guestUser.Id,
                    ChatRoomId = uniChatRoom.Id
                });

            builder.Entity<ChatRoomUser>()
                .HasData(new ChatRoomUser
                {
                    ChatRoomId = londonChatRoom.Id,
                    ChatUserId = guestUser.Id,
                },
                new ChatRoomUser
                {
                    ChatRoomId = londonChatRoom.Id,
                    ChatUserId = guestTwoUser.Id,
                },
                new ChatRoomUser
                {
                    ChatRoomId = uniChatRoom.Id,
                    ChatUserId = guestUser.Id,
                },
                new ChatRoomUser
                {
                    ChatRoomId = uniChatRoom.Id,
                    ChatUserId = guestTwoUser.Id,
                });

            void SeedUsers()
            {
                PasswordHasher<ChatUser> hasher = new PasswordHasher<ChatUser>();

                guestUser = new ChatUser
                {
                    UserName = "guest",
                    NormalizedUserName = "GUEST",
                    Email = "guest@mail.com",
                    NormalizedEmail = "GUEST@MAIL.COM",
                };
                guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest");

                guestTwoUser = new ChatUser
                {
                    UserName = "guest2",
                    NormalizedUserName = "GUEST2",
                    Email = "guest2@mail.com",
                    NormalizedEmail = "GUEST2@MAIL.COM",
                };
                guestTwoUser.PasswordHash = hasher.HashPassword(guestTwoUser, "guest2");

                mariaUser = new ChatUser
                {
                    UserName = "maria",
                    NormalizedUserName = "MARIA",
                    Email = "maria@mail.com",
                    NormalizedEmail = "MARIA@MAIL.COM",
                };
                mariaUser.PasswordHash = hasher.HashPassword(mariaUser, "maria");
            }

            void SeedChatRooms()
            {
                londonChatRoom = new ChatRoom
                {
                    Id = 1,
                    Name = "Our Journey to London",
                    OwnerId = guestUser.Id,
                };

                uniChatRoom = new ChatRoom
                {
                    Id = 2,
                    Name = "Informatics University Group",
                    OwnerId = guestTwoUser.Id,
                };
            }
        }
    }
}
