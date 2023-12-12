using AutoMapper;
using MoorCodeSofia.Application.UserTasks.Commands;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using Moq;
using FluentValidation;
using FluentValidation.TestHelper;
using MoorCodeSofia.Domain;

namespace MoorCodeSofia.Tests.Unit.UserTasks.Commands
{

    public class UpdateUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock;
        private readonly Mock<IMapper> _mapper;
        private readonly UpdateUserTaskCommandValidator _validator;
        public UpdateUserCommandHandlerTests()
        {
            _userTaskRepositoryMock = new Mock<IUserTaskRepository>();
            _mapper = new Mock<IMapper>();
            _validator = new UpdateUserTaskCommandValidator();
        }


        [Fact]
        public async Task Handle_Should_UpdateUserTask_Successfully()
        {
            // arrange
            var command = new UpdateUserTaskCommand(
                Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"),
                "David",
                "Description",
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
           

            var handler = new UpdateUserTaskCommandHandler(
                _userTaskRepositoryMock.Object,
                _mapper.Object);
            
            // act
            Result<UserTask> result = await handler.Handle(command, default);
            
            // assert
            Assert.NotEmpty(new[] { result.Value });
            Assert.True(result.IsSuccess);
           

        }
        [Fact]
        public async Task StartDate_Should_Be_LessThen_EndDate_And_NotNull_UpdateUserTask()
        {
            // arrange
            var command = new UpdateUserTaskCommand(
                 Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"),
                "Murat",
                "Description",
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var  result = _validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.StartDate);

        }
        [Fact]
        public async Task StartDate_Should_Be_Valid_UpdateUserTask()
        {
            // arrange
            var command = new UpdateUserTaskCommand(
                 Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"),
                "Nazdar",
                "Description",
                new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var  result = _validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.StartDate);

        } 
        [Fact]
        public async Task EndDate_Should_Be_GreaterThan_StartDate_And_NotNull_UpdateUserTask()
        {
            // arrange
            var command = new UpdateUserTaskCommand(
                Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"),
                "Nazdar",
                "Description",
                new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var  result = _validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.EndDate);

        }
        [Fact]
        public async Task EndDate_Should_Be_Valid_UpdateUserTask()
        {
            // arrange
            var command = new UpdateUserTaskCommand(
                 Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"),
                "Nazdar",
                "Description",
                new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.EndDate);

        }
        [Fact]
        public async Task User_Cannot_Be_Null_UpdateUserTask()
        {
            // arrange
            var command = new UpdateUserTaskCommand(
               Guid.Parse("a907d1a4-2874-48a6-abc7-f76045bdbe8e"),
                "Nazdar",
                "Description",
                new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.User);

        }
    }
}
