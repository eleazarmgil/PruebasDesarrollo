using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries;

public class ConsultarDetalleDeOpcionDePagoQuery : IRequest<List<ConsultarDetalleDeOpcionDePagoResponse>>
{
    public ConsultarDetalleDeOpcionDePagoRequest _request { get; set; }

    public ConsultarDetalleDeOpcionDePagoQuery(ConsultarDetalleDeOpcionDePagoRequest request)
    {
        _request = request;
    }

}

