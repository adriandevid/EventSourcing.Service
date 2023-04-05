using EventSourcing.Service.Application.Requests.Base;
using EventSourcing.Service.Application.Requests.User;
using EventSourcing.Service.Application.Responses.Base;
using EventSourcing.Service.Domain.Entities.Base;
using EventSourcing.Service.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Service.Application.DomainCommands.User
{
    public class UpdateUserCommandHandler : RequestHandler, IRequestHandler<UpdateUserRequest, ApiResponse>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<ApiResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.User.User user = await _userRepository.GetByIdAsync(request.Id);

            if (user.IsInvalidPassword(request.Password)) {
                return await CustomResponse(_userRepository, () => {
                    user.RefusedUpdateEventStart();
                }, cancellationToken);
            } 
            
            if (user != null)
            {
                user.Update(request.Name, "Updated");
                _userRepository.Update(user);

                return await CustomResponse(_userRepository, () => {
                    user.UpdateUserEventStart();
                }, cancellationToken);
            }

            return await CustomResponse(_userRepository, () => { }, cancellationToken);
        }
    }
}
