using System.ComponentModel.DataAnnotations;

using static ChatRoom.Data.DataConstants;

namespace ChatRoom.WebApp.Models.Message
{
	public class MessageFormModel
	{
        public string CurrentUser { get; init; }

        [Required]
        [StringLength(MaxMessageContent, MinimumLength = MinMessageContent, ErrorMessage = "Message must be with a minimum length of {2}")]
        public string NewMessage { get; set; }
    }
}
