using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;

public class AgregarOpcionPagoCommand : IRequest<Guid>
{
    public AgregarOpcionPagoRequest _request { get; set; }

    public AgregarOpcionPagoCommand(AgregarOpcionPagoRequest request)
    {
        _request = request;
    }
}
