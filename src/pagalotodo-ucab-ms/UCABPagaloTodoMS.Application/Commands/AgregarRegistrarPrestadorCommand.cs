using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;
public class AgregarRegistrarPrestadorCommand : IRequest<Guid>
{
    public RegistrarPrestadorRequest _request { get; set; }

    public AgregarRegistrarPrestadorCommand(RegistrarPrestadorRequest request)
    {
        _request = request;
    }
}
