using AutoMapper;
using FluentValidation.TestHelper;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using MoorCodeSofia.Infrastructure;
using Moq;

namespace MoorCodeSofia.Tests.Unit.UserTasks.Commands
{


    public class GetUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock;
        private readonly Mock<IMapper> _mapper;
        private readonly GetUserTaskCommandValidator _validator;
        public GetUserCommandHandlerTests()
        {
            _userTaskRepositoryMock = new Mock<IUserTaskRepository>();
            _mapper = new Mock<IMapper>();
            _validator = new GetUserTaskCommandValidator();
        }



        [Fact]
        public async Task Handle_Should_GetUserTask_Successfully()
        {
            // arrange
            var command = new GetUserTaskCommand(
            //Guid.Parse("b3c9322c-9743-48c3-aa48-a903418549f6")
            DataSet.AllUserTasks.FirstOrDefault().Id);

            var handler = new GetUserTaskCommandHandler(
                _userTaskRepositoryMock.Object,
                _mapper.Object);

            // act
            Result<UserTask> result = await handler.Handle(command, default);

            // assert;
            Assert.True(result.IsSuccess);


        }
        [Fact]
        public async Task Id_Should_Be_NotNull_GetUserTask()
        {
            // arrange
            var command = new GetUserTaskCommand(
                 Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"));
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.id);

        }

    }
}
