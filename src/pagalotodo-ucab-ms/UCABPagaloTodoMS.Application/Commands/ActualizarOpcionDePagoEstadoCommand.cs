using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;

public class ActualizarOpcionDePagoEstadoCommand : IRequest<Guid>
{
    public ActualizarOpcionDePagoEstadoRequest _request { get; set; }

    public ActualizarOpcionDePagoEstadoCommand(ActualizarOpcionDePagoEstadoRequest request)
    {
        _request = request;
    }
}

