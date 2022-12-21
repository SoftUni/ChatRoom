using System;
using System.Threading.Tasks;

using ChatRoom.Data;
using ChatRoom.Services.Contracts;

namespace ChatRoom.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext dbContext;

        public MessageService(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
    }
}
