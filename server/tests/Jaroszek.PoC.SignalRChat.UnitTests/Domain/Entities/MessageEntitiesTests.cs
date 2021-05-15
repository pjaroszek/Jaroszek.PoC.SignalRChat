namespace Jaroszek.PoC.SignalRChat.UnitTests.Core.Entities
{
    using System;
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Domain.Entities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MessageEntitiesTests
    {
        [TestMethod]
        public async Task MessageEntitiesPropertyIsActiveDefaultTrue()
        {
            var result = new MessageEntities(Guid.NewGuid(), "Pawel", string.Empty, DateTime.Now);

            Assert.AreEqual(result.IsActive, true);
        }

    }
}