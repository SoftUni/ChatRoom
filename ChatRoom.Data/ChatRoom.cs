using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatRoom.Data
{
    using static DataConstants;

    public class ChatRoom
    {
        public ChatRoom()
        {
            this.Members = new HashSet<ChatRoomUser>();
            this.Messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(MaxRoomName)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public ChatUser Owner { get; init; }

        public ICollection<ChatRoomUser> Members { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
