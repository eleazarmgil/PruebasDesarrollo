using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;
public class CambiarClaveCommand : IRequest<Guid>
{
    public CambiarClaveUsuarioRequest _request { get; set; }


    public CambiarClaveCommand(CambiarClaveUsuarioRequest request)
    {
        _request = request;
    }
}
