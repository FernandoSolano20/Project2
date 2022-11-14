using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Transaccion : BaseEntity
    {
        public int ID { get; set; }
        public decimal Monto { get; set; }
        public string Movimiento { get; set; }
        public DateTime Fecha { get; set; }
        public string ID_Usuario { get; set; }
        public string ID_Trabajo { get; set; }
        public string ID_Membresia { get; set; }
    }
}
