using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;
public class ConsultarPreguntasDeSeguridadQuery : IRequest<List<PreguntasDeSeguridadResponse>>
{
    public PreguntasDeSeguridadRequest _request { get; set; }

    public ConsultarPreguntasDeSeguridadQuery(PreguntasDeSeguridadRequest request)
    {
        _request = request;
    }
}
