using System.Linq;
using System.Security.Claims;

using ChatRoom.Data;
using ChatRoom.WebApp.Claims;
using ChatRoom.WebApp.Models.Message;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChatRoom.WebApp.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public MessagesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpPost]
        public IActionResult Create(int chatRoomId, MessageFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                foreach (ModelError error in this.ModelState.Values.SelectMany(entry => entry.Errors))
                {
                    this.TempData["Error"] = error.ErrorMessage;
                }

                return this.RedirectToAction("Details", "ChatRoom", new { id = chatRoomId });
            }

            Message message = new Message
            {
                Content = model.NewMessage,
                ChatRoomId = chatRoomId,
                OwnerId = this.User.Id()
            };

            this.dbContext.Messages.Add(message);
            this.dbContext.SaveChanges();

            return this.RedirectToAction("Details", "ChatRoom", new { id = chatRoomId });
        }
    }
}
