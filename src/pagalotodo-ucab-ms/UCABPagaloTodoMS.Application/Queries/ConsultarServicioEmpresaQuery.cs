using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;

public class ConsultarServicioEmpresaQuery : IRequest<List<ConsultarServicioEmpresaResponse>>
{
    public ConsultarServicioEmpresaRequest _request { get; set; }

    public ConsultarServicioEmpresaQuery(ConsultarServicioEmpresaRequest request)
    {
        _request = request;
    }

}

