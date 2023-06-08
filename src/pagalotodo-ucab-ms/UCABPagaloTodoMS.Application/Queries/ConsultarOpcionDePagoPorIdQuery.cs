using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;

public class ConsultarOpcionDePagoPorIdQuery : IRequest<List<ConsultarOpcionDePagoPorIdResponse>>
{
    public ConsultarOpcionDePagoPorIdRequest _request { get; set; }

    public ConsultarOpcionDePagoPorIdQuery(ConsultarOpcionDePagoPorIdRequest request)
    {
        _request = request;
    }

}

