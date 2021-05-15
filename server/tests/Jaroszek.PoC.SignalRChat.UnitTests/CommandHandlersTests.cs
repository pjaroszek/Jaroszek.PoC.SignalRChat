namespace Jaroszek.PoC.SignalRChat.UnitTests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Jaroszek.PoC.SignalRChat.Application.Chat.Commands;
    using Jaroszek.PoC.SignalRChat.Domain.Exceptions;
    using Jaroszek.PoC.SignalRChat.Infrastructure.Chat.CommandHandlers;
    using Jaroszek.PoC.SignalRChat.Infrastructure.Services;
    using MediatR;
    using MemoryCache.Testing.Moq;
    using Microsoft.Extensions.Logging;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CommandHandlersTests
    {
        [TestMethod]
        [ExpectedException(typeof(UserNameMustNotBeEmptyException))]
        public async Task UserNameEmpty()
        {
            var mockedCache = Create.MockedMemoryCache();

            var mockDateTime = new Mock<IDateTime>();
            mockDateTime.Setup(p => p.Now).Returns(DateTime.Now);

            var mock = new Mock<ILogger<SendMessageHandler>>();
            ILogger<SendMessageHandler> logger = mock.Object;

            var mockMediator = new Mock<IMediator>();

            //Arrange
            var command = new SendMessage()
            {
                UserName = string.Empty,
                Message = "message"
            };

            var handler = new SendMessageHandler(mockedCache, mockDateTime.Object, logger, mockMediator.Object);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert
        }

        [TestMethod]
        public async Task SendMessageTest()
        {
            var mockedCache = Create.MockedMemoryCache();

            var mockDateTime = new Mock<IDateTime>();
            mockDateTime.Setup(p => p.Now).Returns(DateTime.Now);

            var mock = new Mock<ILogger<SendMessageHandler>>();
            ILogger<SendMessageHandler> logger = mock.Object;

            var mockMediator = new Mock<IMediator>();

            //Arrange
            var command = new SendMessage()
            {
                UserName = "userName",
                Message = "message"
            };

            var handler = new SendMessageHandler(mockedCache, mockDateTime.Object, logger, mockMediator.Object);

            //Act
            var result = await handler.Handle(command, CancellationToken.None);

            //Assert

            result.Should().Equals(Unit.Value);
        }
    }
}
