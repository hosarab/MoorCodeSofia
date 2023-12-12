using AutoMapper;
using MoorCodeSofia.Application.Abstractions;
using MoorCodeSofia.Domain;
using MoorCodeSofia.Domain.Contracts;
using MoorCodeSofia.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoorCodeSofia.Application.UserTasks.Commands
{
    public class GetUserTaskCommandHandler : ICommandHandler<GetUserTaskCommand, UserTask>
    {
        private readonly IMapper _mapper;
        IUserTaskRepository _userTaskRepository;
        public GetUserTaskCommandHandler(IUserTaskRepository userTaskRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userTaskRepository = userTaskRepository;
        }

        public async Task<Result<UserTask>> Handle(GetUserTaskCommand request, CancellationToken cancellationToken)
        {
            
                var userTask = new UserTask()
                {
                    Id = request.id,
                };
               var response = await  _userTaskRepository.GetTaskByIdAsync(userTask, cancellationToken) ?? new UserTask();
                if (response == null) {response = new UserTask();}
            
            return response;
        }
    }
}
