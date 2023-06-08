using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;
public class ConsultarRecuperarClaveQuery : IRequest<List<RecuperarClaveResponse>>
{
    public RecuperarClaveRequest _request { get; set; }

    public ConsultarRecuperarClaveQuery(RecuperarClaveRequest request)
    {
        _request = request;
    }
}