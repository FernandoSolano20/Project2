using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Bitacora : BaseEntity
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Entidad { get; set; }
        public string Identificador { get; set; }
        public string Verbo { get; set; }
        public string Accion { get; set; }
        public string ID_Usuario { get; set; }
    }
}
