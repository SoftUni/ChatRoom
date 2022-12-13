using System.Threading.Tasks;

using ChatRoom.Data;

using NUnit.Framework;

namespace ChatRoom.Tests
{
    [TestFixture]
    public class ChatServiceTests : UnitTestsBase
    {
        //private IChatService chatService;

        [SetUp]
        public void SetUp()
        {
            //this.chatService = new ChatService(this.dbContext);
        }

        [Test]
        public async Task Test_GetChatDetails_ReturnsCorrectInfo()
        {
        }

        [Test]
        public async Task Test_SaveChatRoom_AddsCorrectly()
        {
        }

        [Test]
        public async Task Test_DeleteChatRoom_RemovesCorrectly()
        {
        }

        [Test]
        public async Task Test_EditChatRoom_ChangesCorrectly()
        {
        }
    }
}
