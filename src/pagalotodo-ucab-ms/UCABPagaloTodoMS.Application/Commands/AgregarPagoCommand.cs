using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;

public class AgregarPagoCommand : IRequest<Guid>
{
    public AgregarPagoRequest _request { get; set; }

    public AgregarPagoCommand(AgregarPagoRequest request)
    {
        _request = request;
    }
}
