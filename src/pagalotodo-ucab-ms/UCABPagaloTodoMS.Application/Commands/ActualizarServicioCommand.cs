using MediatR;
using UCABPagaloTodoMS.Application.Requests; 

namespace UCABPagaloTodoMS.Application.Commands;

public class ActualizarServicioCommand : IRequest<Guid>
{
    public ActualizarServicioRequest _request { get; set; }

    public ActualizarServicioCommand(ActualizarServicioRequest request)
    {
        _request = request;
    }
}
