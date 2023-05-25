using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;
public class AdministradorActualizarPrestadorCommand : IRequest<Guid>
{
    public AdministradorActualizarPrestadorRequest _request { get; set; }

    public AdministradorActualizarPrestadorCommand(AdministradorActualizarPrestadorRequest request)
    {
        _request = request;
    }

}
