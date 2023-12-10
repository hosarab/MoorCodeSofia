﻿using AutoMapper;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using Moq;

namespace MoorCodeSofia.Tests.Unit.UserTasks.Commands
{
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock;
        private readonly Mock<IMapper> _mapper;

        public DeleteUserCommandHandlerTests()
        {
            _userTaskRepositoryMock = new Mock<IUserTaskRepository>();
            _mapper = new Mock<IMapper>();
        }


        [Fact]
        public async Task Handle_Should_Delete_A_UserTask_Successfully()
        {
            // arrange
            var command = new CreateUserTaskCommand(
                "David",
                "Description",
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");

            var handler = new CreateUserTaskCommandHandler(
                _userTaskRepositoryMock.Object,
                _mapper.Object);
            // act

            Result<Guid> result = await handler.Handle(command, default);


            // assert
            Assert.NotEmpty(new[] { result.Value });
            Assert.True(result.IsSuccess);

        }

    }
}