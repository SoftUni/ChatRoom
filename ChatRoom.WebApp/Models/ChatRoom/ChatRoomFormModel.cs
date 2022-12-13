using System.ComponentModel.DataAnnotations;

using ChatRoom.Data;

namespace ChatRoom.WebApp.Models.ChatRoom
{
    using static DataConstants;

    public class ChatRoomFormModel
    {
        [Required]
        [StringLength(MaxRoomName, MinimumLength = MinRoomName,
            ErrorMessage = "Room name should be at least {2} characters long.")]
        public string Name { get; set; }
    }
}
