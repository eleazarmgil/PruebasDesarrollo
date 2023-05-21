using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;


namespace UCABPagaloTodoMS.Application.Commands
{
    public class ActualizarPrestadorCommand : IRequest<Guid>
    {
        public ActualizarPrestadorRequest _request { get; set; }

        public ActualizarPrestadorCommand(ActualizarPrestadorRequest request)
        {
            _request = request;
        }

    }
}
