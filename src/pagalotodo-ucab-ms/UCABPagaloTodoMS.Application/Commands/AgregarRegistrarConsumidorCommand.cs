using MediatR;
using UCABPagaloTodoMS.Application.Requests;
using UCABPagaloTodoMS.Application.Responses;

namespace UCABPagaloTodoMS.Application.Commands
{
    public class AgregarRegistrarConsumidorCommand : IRequest<Guid>
    {
        public RegistrarConsumidorRequest _request { get; set; }

        public AgregarRegistrarConsumidorCommand(RegistrarConsumidorRequest request)
        {
            _request = request;
        }
    }
}
