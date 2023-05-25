using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;
public class AgregarRegistrarConsumidorCommand : IRequest<Guid>
{
    public RegistrarConsumidorRequest _request { get; set; }

    public AgregarRegistrarConsumidorCommand(RegistrarConsumidorRequest request)
    {
        _request = request;
    }
}
