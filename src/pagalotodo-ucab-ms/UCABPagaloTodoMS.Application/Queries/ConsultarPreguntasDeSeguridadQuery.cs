using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;
public class ConsultarPreguntasDeSeguridadQuery : IRequest<List<PreguntasDeSeguridadResponse>>
{
    public ConsultarUsuarioRequest _request { get; set; }

    public ConsultarPreguntasDeSeguridadQuery(ConsultarUsuarioRequest request)
    {
        _request = request;
    }
}
