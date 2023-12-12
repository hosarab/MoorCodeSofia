﻿using AutoMapper;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using Moq;
using FluentValidation.TestHelper;
using MoorCodeSofia.Infrastructure;

namespace MoorCodeSofia.Tests.Unit.UserTasks.Commands
{ 
    public class DeleteUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock;
        private readonly Mock<IMapper> _mapper;
        private readonly DeleteUserTaskCommandValidator _validator;
        public DeleteUserCommandHandlerTests()
        {
             _userTaskRepositoryMock = new Mock<IUserTaskRepository>();
            _mapper = new Mock<IMapper>();
            _validator = new DeleteUserTaskCommandValidator();
        }
        


        [Fact]
        public async Task Handle_Should_DeleteUserTask_Successfully()
        {
            // arrange
            var command = new DeleteUserTaskCommand(
            Guid.Parse("b3c9322c-9743-48c3-aa48-a903418549f6"));
           
            var handler = new DeleteUserTaskCommandHandler(
                _userTaskRepositoryMock.Object,
                _mapper.Object);

            // act
            Result<bool> result = await handler.Handle(command, default);

            // assert
            Assert.NotEmpty(new[] { result.Value });
            Assert.True(result.IsSuccess);
            

        }
        [Fact]
        public async Task Id_Should_Be_NotNull_DeleteUserTask()
        {
            // arrange
            var command = new DeleteUserTaskCommand(
                  Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"));
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.id);

        }
        
    }
}
