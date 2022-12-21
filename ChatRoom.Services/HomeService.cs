using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChatRoom.Data;
using ChatRoom.Services.Contracts;
using ChatRoom.Services.Models.ChatRoom;
using ChatRoom.Services.Models.Home;

using Microsoft.AspNetCore.Identity;

namespace ChatRoom.Services
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext dbContext;

        public HomeService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
    }
}
