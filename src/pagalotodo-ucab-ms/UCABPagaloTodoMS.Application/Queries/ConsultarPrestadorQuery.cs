using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;
public class ConsultarPrestadorQuery : IRequest<List<ConsultarPrestadorResponse>>
{
    public ConsultarPrestadorRequest _request { get; set; }
    public ConsultarPrestadorQuery(ConsultarPrestadorRequest request)
    {
        _request = request;
    }
}