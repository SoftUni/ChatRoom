using System.Collections.Generic;
using System.Linq;

using ChatRoom.Data;
using ChatRoom.WebApp.Models.ChatRoom;
using ChatRoom.WebApp.Models.Home;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoom.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ChatUser> userManager;

        public HomeController(ApplicationDbContext context, UserManager<ChatUser> userManager)
        {
            this.dbContext = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.View();
            }

            ChatUser user = this.userManager.GetUserAsync(this.User).Result;
            List<int> userChatRooms = this.dbContext.ChatRoomsUsers
                .Where(x => x.ChatUserId == user.Id)
                .Select(x => x.ChatRoomId)
                .ToList();

            var homeModel = new HomeViewModel
            {
                ChatRooms = this.dbContext.ChatRooms
                    .Where(cr => userChatRooms.Contains(cr.Id))
                    .Select(c => new ChatRoomModel
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Owner = c.Owner.UserName
                    })
                    .ToList()
            };

            return View(homeModel);
        }

        public IActionResult Error401() 
            => View();

        public IActionResult Error404()
            => View();
    }
}
