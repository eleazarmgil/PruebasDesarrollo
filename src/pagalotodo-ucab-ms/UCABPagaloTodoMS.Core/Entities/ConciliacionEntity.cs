using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCABPagaloTodoMS.Core.Entities
{
    public class ConciliacionEntity : BaseEntity
    {
        public DateTime? fecha { set; get; }
        public Dictionary<string, string>? archivo { set; get; }

    }
}