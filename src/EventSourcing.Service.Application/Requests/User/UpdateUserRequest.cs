using EventSourcing.Service.Application.Responses.Base;
using MediatR;

namespace EventSourcing.Service.Application.Requests.User
{
    public class UpdateUserRequest : IRequest<ApiResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
