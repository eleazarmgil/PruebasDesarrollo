using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;
public class ConsultarConsumidorQuery : IRequest<List<ConsultarConsumidorResponse>>
{
    public ConsultarConsumidorRequest _request { get; set; }

    public ConsultarConsumidorQuery(ConsultarConsumidorRequest request)
    {
        _request = request;
    }
}