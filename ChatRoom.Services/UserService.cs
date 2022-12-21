using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChatRoom.Data;
using ChatRoom.Services.Contracts;
using ChatRoom.Services.Models.ChatRoom;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
    }
}
