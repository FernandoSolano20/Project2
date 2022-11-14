using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Configuracion : BaseEntity
    {
        public string Parametro { get; set; }
        public string Valor { get; set; }
    }
}
