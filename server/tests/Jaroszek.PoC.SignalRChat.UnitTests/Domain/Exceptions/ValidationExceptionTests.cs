namespace Jaroszek.PoC.SignalRChat.UnitTests.Core.Exceptions
{
    using System;
    using System.Threading.Tasks;
    using Jaroszek.PoC.SignalRChat.Domain.Entities;
    using Jaroszek.PoC.SignalRChat.Domain.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidationExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidMessageIdException))]
        public async Task GuidEmpty()
        {
            new MessageEntities(Guid.Empty, string.Empty, string.Empty, DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNameMustNotBeEmptyException))]
        public async Task UserNameEmpty()
        {
            new MessageEntities(Guid.NewGuid(), string.Empty, string.Empty, DateTime.Now);
        }

    }
}
