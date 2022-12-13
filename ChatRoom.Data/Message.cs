using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatRoom.Data
{
    using static DataConstants;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxMessageContent)]
        public string Content { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ChatRoom))]
        public int ChatRoomId { get; set; }

        public ChatRoom ChatRoom { get; init; } = null!;

        [Required]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        public ChatUser Owner { get; init; } = null!;
    }
}
