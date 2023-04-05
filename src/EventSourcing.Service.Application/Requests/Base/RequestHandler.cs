using EventSourcing.Service.Application.Responses.Base;
using EventSourcing.Service.Domain.Interfaces.Repositories.Base;

namespace EventSourcing.Service.Application.Requests.Base
{
    public class RequestHandler
    {
        public delegate void ExecuteEvents();

        public static async Task<ApiResponse> CustomResponse<TEntity>(IBaseRepository<TEntity> repository, ExecuteEvents executeEvents, CancellationToken cancellationToken = default) where TEntity : class {
            var responseResultSaveEntity = await repository.UnitOfWork.SaveEntitiesAndDispathEvents(() => { executeEvents(); }, cancellationToken);
            return new ApiResponse() { IsValid = responseResultSaveEntity };
        }
    }
}
