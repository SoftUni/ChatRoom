using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using ChatRoom.Data;
using ChatRoom.WebApp.Claims;
using ChatRoom.WebApp.Models.ChatRoom;
using ChatRoom.WebApp.Models.Message;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.WebApp.Controllers
{
    [Authorize]
    public class ChatRoomController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ChatUser> userManager;

        public ChatRoomController(
            ApplicationDbContext context,
            UserManager<ChatUser> userManager)
        {
            this.dbContext = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (this.dbContext.ChatRooms.Find(id) == null)
            {
                return this.NotFound();
            }

            List<string> chatRoomUsers = this.dbContext.ChatRoomsUsers
                .Where(x => x.ChatRoomId == id)
                .Select(x => x.ChatUserId)
                .ToList();

            if (!chatRoomUsers.Contains(this.userManager.GetUserAsync(this.User).Result.Id))
            {
                return this.Unauthorized();
            }

            var chatRooms = this.dbContext
                .ChatRooms
                .Include(c => c.Members)
                .ThenInclude(cu => cu.ChatUser)
                .Where(c => c.Id == id)
                .Select(c => new ChatRoomViewModel
                {
                    Id = c.Id,
                    CurrentUser = this.userManager.GetUserName(this.User),
                    OwnerId = c.OwnerId,
                    Messages = c.Messages.Select(m => new MessageViewModel
                    {
                        Content = m.Content,
                        Owner = m.Owner.UserName
                    }),
                    Members = c.Members.Select(m => m.ChatUser.UserName)
                })
                .FirstOrDefault();

            return View(chatRooms);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ChatRoomFormModel model = new ChatRoomFormModel();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(ChatRoomFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            string ownerId = this.User.Id();

            Data.ChatRoom room = new Data.ChatRoom
            {
                Name = model.Name,
                OwnerId = ownerId,
            };

            this.dbContext.ChatRooms.Add(room);

            this.dbContext.SaveChanges();

            ChatRoomUser map = new ChatRoomUser
            {
                ChatRoomId = room.Id,
                ChatUserId = ownerId,
            };

            this.dbContext.ChatRoomsUsers.Add(map);

            this.dbContext.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Data.ChatRoom room = this.dbContext.ChatRooms.Find(id);
            if (room == null)
            {
                return this.NotFound();
            }

            string currentUserId = this.User.Id();
            if (currentUserId != room.OwnerId)
            {
                return this.Unauthorized();
            }

            ChatRoomModel model = new ChatRoomModel
            {
                Id = room!.Id,
                Name = room!.Name,
                Owner = room!.OwnerId
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Delete(ChatRoomModel model)
        {
            Data.ChatRoom room = this.dbContext.ChatRooms.Find(model.Id);
            if (room == null)
            {
                return this.NotFound();
            }

            string currentUserId = this.User.Id();
            if (currentUserId != room.OwnerId)
            {
                return this.Unauthorized();
            }

            this.dbContext.ChatRooms.Remove(room!);
            this.dbContext.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Data.ChatRoom room = dbContext.ChatRooms.Find(id);
            if (room == null)
            {
                return this.NotFound();
            }

            string currentUserId = this.User.Id();
            if (currentUserId != room.OwnerId)
            {
                return this.Unauthorized();
            }

            ChatRoomFormModel model = new ChatRoomFormModel
            {
                Name = room!.Name,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, ChatRoomFormModel model)
        {
            Data.ChatRoom room = dbContext.ChatRooms.Find(id);
            if (room == null)
            {
                return this.NotFound();
            }

            string currentUserId = this.User.Id();
            if (currentUserId != room.OwnerId)
            {
                return this.Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            room.Name = model.Name;
            this.dbContext.SaveChanges();

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddUser(int chatRoomId)
        {
            Data.ChatRoom room = dbContext.ChatRooms.Find(chatRoomId);
            if (room == null)
            {
                return this.NotFound();
            }

            string currentUserId = this.User.Id();
            if (currentUserId != room.OwnerId)
            {
                return this.Unauthorized();
            }

            ICollection<string> chatRoomMembers =
                this.dbContext.ChatRoomsUsers
                    .Where(cru => cru.ChatRoomId == chatRoomId)
                    .Select(cru => cru.ChatUserId)
                    .ToList();

            ICollection<ChatUser> usersNotInRoom = this.userManager.Users
                .Where(u => !chatRoomMembers.Contains(u.Id))
                .ToList();

            UserFormModel model = new UserFormModel
            {
                Id = chatRoomId,
                RoomName = room.Name,
                Users = usersNotInRoom,
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult AddUser(string userId, UserFormModel model)
        {
            return this.NotFound();
        }

        [HttpGet]
        public IActionResult RemoveUser(int chatRoomId)
        {
            return this.NotFound();
        }

        [HttpPost]
        public IActionResult RemoveUser(string userId, UserFormModel model)
        {
            return this.NotFound();
        }
    }
}
