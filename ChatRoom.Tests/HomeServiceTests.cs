using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using ChatRoom.Data;

using Microsoft.EntityFrameworkCore;

using NUnit.Framework;

namespace ChatRoom.Tests
{
    [TestFixture]
    public class HomeServiceTests : UnitTestsBase
    {
        //private IHomeService homeService;

        [SetUp]
        public void SetUp()
        {
            //this.homeService = new HomeService(this.dbContext);
        }

        [Test]
        public async Task Test_GetUserRooms_ReturnsCorrectChatRooms()
        {
        }
    }
}
