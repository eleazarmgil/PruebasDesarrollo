using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCABPagaloTodoMS.Application.Requests;

namespace UCABPagaloTodoMS.Application.Commands
{
    public class CambiarClaveCommand : IRequest<Guid>
    {
        public CambiarClaveUsuarioRequest _request { get; set; }


        public CambiarClaveCommand(CambiarClaveUsuarioRequest request)
        {
            _request = request;
        }
    }
}
