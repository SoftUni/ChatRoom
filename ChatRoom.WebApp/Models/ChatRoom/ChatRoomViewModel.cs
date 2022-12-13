using System.Collections.Generic;
using ChatRoom.WebApp.Models.Message;

namespace ChatRoom.WebApp.Models.ChatRoom
{
    public class ChatRoomViewModel
    {
        public int Id { get; init; }

        public string CurrentUser { get; init; }

        public string OwnerId { get; set; }

        public IEnumerable<MessageViewModel> Messages { get; set; } = new List<MessageViewModel>();

        public IEnumerable<string> Members { get; set; } = new List<string>();
    }
}
