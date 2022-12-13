using System.ComponentModel.DataAnnotations;

namespace ChatRoom.Data
{
	public class ChatRoomUser
	{
        [Required]
        public int ChatRoomId { get; set; }

        [Required] 
        public string ChatUserId { get; set; } = null!;

        public ChatUser ChatUser { get; set; } = null!;
    }
}
