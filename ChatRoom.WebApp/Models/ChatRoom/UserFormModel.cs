using System.Collections.Generic;

using ChatRoom.Data;

namespace ChatRoom.WebApp.Models.ChatRoom
{
    public class UserFormModel
    {
        public int Id { get; set; }

        public string RoomName { get; set; }

        public ICollection<ChatUser> Users { get; set; }
    }
}
