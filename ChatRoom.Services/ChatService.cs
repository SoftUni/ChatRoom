using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChatRoom.Data;
using ChatRoom.Services.Contracts;
using ChatRoom.Services.Models.ChatRoom;
using ChatRoom.Services.Models.Message;

using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Services
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext dbContext;

        public ChatService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
    }
}
