using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Documento : BaseEntity
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string Titulo { get; set; }
        public string ID_Propietario { get; set; }
        public string TipoDocumento { get; set; }
        public string Estado { get; set; }

    }
}
