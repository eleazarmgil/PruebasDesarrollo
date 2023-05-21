using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands
{
    public class AgregarRegistrarServicioCommand : IRequest<Guid>
    {
        public RegistrarServicioRequest _request { get; set; }

        public AgregarRegistrarServicioCommand(RegistrarServicioRequest request)
        {
            _request = request;
        }
    }
}
