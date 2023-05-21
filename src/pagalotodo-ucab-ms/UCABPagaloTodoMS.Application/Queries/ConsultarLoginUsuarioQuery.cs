using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Queries
{
    public class ConsultarLoginUsuarioQuery : IRequest<List<LoginUsuarioResponse>>
    {
        public LoginUsuarioRequest _request { get; set; }

        public ConsultarLoginUsuarioQuery(LoginUsuarioRequest request)
        {
            _request = request;
        }
    }
}
