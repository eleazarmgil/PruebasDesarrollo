using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;

public class ActualizarConsumidorCommand : IRequest<Guid>
{
    public ActualizarConsumidorRequest _request { get; set; }

    public ActualizarConsumidorCommand(ActualizarConsumidorRequest request)
    {
        _request = request;
    }
}

