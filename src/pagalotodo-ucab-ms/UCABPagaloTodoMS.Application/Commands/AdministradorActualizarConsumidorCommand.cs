using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;

public class AdministradorActualizarConsumidorCommand : IRequest<Guid>
{
    public AdministradorActualizarConsumidorRequest _request { get; set; }

    public AdministradorActualizarConsumidorCommand(AdministradorActualizarConsumidorRequest request)
    {
        _request = request;
    }
}
