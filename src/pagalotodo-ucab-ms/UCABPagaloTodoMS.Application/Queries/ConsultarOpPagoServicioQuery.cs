using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;

public class ConsultarOpPagoServicioQuery : IRequest<List<ConsultarOpPagoServicioResponse>>
{
    public ConsultarOpPagoServicioRequest _request { get; set; }
    public ConsultarOpPagoServicioQuery(ConsultarOpPagoServicioRequest request)
    {
        _request = request;
    }
}
