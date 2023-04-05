using EventSourcing.Service.Application.Requests.Base;
using EventSourcing.Service.Application.Requests.User;
using EventSourcing.Service.Application.Responses.Base;
using EventSourcing.Service.Infrastructure.Interfaces;
using MediatR;

namespace EventSourcing.Service.Application.DomainCommands.User
{
    public class CreateUserCommandHandler : RequestHandler, IRequestHandler<CreateUserRequest, ApiResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var entitie = new Domain.Entities.User.User(request.Name, request.Password);

            await _userRepository.Add(entitie);

            return await CustomResponse(_userRepository, () => {
                entitie.CreateUserEventStart();
            }, cancellationToken);
        }
    }
}
