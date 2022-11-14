using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Factura : BaseEntity
    {
        public int ID { get; set; }
        public int ID_Transaccion { get; set; }
        public DateTime Fecha { get; set; }
        public string ID_Proveedor { get; set; }
    }
}
