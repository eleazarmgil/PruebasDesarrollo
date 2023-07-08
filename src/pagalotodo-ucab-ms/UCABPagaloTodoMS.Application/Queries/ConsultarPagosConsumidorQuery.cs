using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;

public class ConsultarPagosConsumidorQuery : IRequest<List<ConsultarPagosConsumidorResponse>>
{
    public ConsultarPagosConsumidorRequest _request { get; set; }
    public ConsultarPagosConsumidorQuery(ConsultarPagosConsumidorRequest request)
    {
        _request = request;
    }
}
