using MediatR;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands;
public class AgregarValorPruebaCommand : IRequest<Guid>
{
    public ValoresRequest _request { get; set; }

    public AgregarValorPruebaCommand(ValoresRequest request)
    {
        _request = request;
    }
}
