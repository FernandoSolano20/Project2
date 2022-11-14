using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class TipoTrabajo : BaseEntity
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Estado { get; set; }
    }
}
