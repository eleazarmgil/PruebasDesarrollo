using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;

public class ConsultarUsuarioIdQuery : IRequest<List<ConsultarUsuarioIdResponse>>
{
    public ConsultarUsuarioIdRequest _request { get; set; }
    public ConsultarUsuarioIdQuery(ConsultarUsuarioIdRequest request)
    {
        _request = request;
    }
}
