using ChatRoom.Data;
using ChatRoom.Tests.Common;

using NUnit.Framework;

namespace ChatRoom.Tests
{
    public class UnitTestsBase
    {
        protected TestDb testDb;
        protected ApplicationDbContext dbContext;

        [SetUp]
        public void SetUpBase()
        {
            // Instantiate the testing db with a db context
            this.testDb = new TestDb();
            this.dbContext = testDb.CreateDbContext();
        }
    }
}

