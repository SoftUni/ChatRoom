using System.Threading.Tasks;

using NUnit.Framework;

namespace ChatRoom.Tests
{
    public class MessageServiceTests : UnitTestsBase
    {
        //private IMessageService messageService;

        [SetUp]
        public void SetUp()
        {
            //this.messageService = new MessageService(this.dbContext);
        }

        [Test]
        public async Task Test_SaveComment_AddsCorrectly()
        {
        }
    }
}
