using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Membresia : BaseEntity
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public decimal Costo { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string ID_Empresa { get; set; }
        public string ID_Representante { get; set; }
        public string Moneda { get; set; }
    }
}
