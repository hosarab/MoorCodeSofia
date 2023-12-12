namespace MoorCodeSofia.Tests.Unit.UserTasks.Commands
{

    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserTaskRepository> _userTaskRepositoryMock;
        private readonly Mock<IMapper> _mapper;
        private readonly CreateUserTaskCommandValidator _validator;
        public CreateUserCommandHandlerTests()
        {
            _userTaskRepositoryMock = new Mock<IUserTaskRepository>();
            _mapper = new Mock<IMapper>();
            _validator = new CreateUserTaskCommandValidator();
        }


        [Fact]
        public async Task Handle_Should_CreateUserTask_Successfully()
        {
            // arrange
            var command = new CreateUserTaskCommand(

                "David",
                "Description",
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");


            _userTaskRepositoryMock.Setup(x => x.AddAsync(
                    It.IsAny<UserTask>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(Guid.NewGuid())
            .Verifiable();



            var handler = new CreateUserTaskCommandHandler(
                _userTaskRepositoryMock.Object,
                _mapper.Object);

            // act
            Result<Guid> result = await handler.Handle(command, default);

            // assert
            Assert.NotEmpty(new[] { result.Value });
            Assert.True(result.IsSuccess);


        }
        [Fact]
        public async Task StartDate_Should_Be_LessThen_EndDate_And_NotNull_CreateUserTask()
        {
            // arrange
            var command = new CreateUserTaskCommand(
                "Murat",
                "Description",
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.StartDate);

        }
        [Fact]
        public async Task StartDate_Should_Be_Valid_CreateUserTask()
        {
            // arrange
            var command = new CreateUserTaskCommand(
                "Nazdar",
                "Description",
                new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldHaveValidationErrorFor(x => x.StartDate);

        }
        [Fact]
        public async Task EndDate_Should_Be_GreaterThan_StartDate_And_NotNull_CreateUserTask()
        {
            // arrange
            var command = new CreateUserTaskCommand(
                "Nazdar",
                "Description",
                new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.EndDate);

        }
        [Fact]
        public async Task EndDate_Should_Be_Valid_CreateUserTask()
        {
            // arrange
            var command = new CreateUserTaskCommand(
                "Nazdar",
                "Description",
                new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                "Subject");
            // act
            var result = _validator.TestValidate(command);

            // assert
            result.ShouldNotHaveValidationErrorFor(x => x.EndDate);

        }

    }
}
