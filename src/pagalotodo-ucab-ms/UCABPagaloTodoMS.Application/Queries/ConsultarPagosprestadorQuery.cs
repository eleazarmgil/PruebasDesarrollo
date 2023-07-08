using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;

public class ConsultarPagosPrestadorQuery : IRequest<List<ConsultarPagosPrestadorResponse>>
{
    public ConsultarPagosPrestadorRequest _request { get; set; }
    public ConsultarPagosPrestadorQuery(ConsultarPagosPrestadorRequest request)
    {
        _request = request;
    }
}
