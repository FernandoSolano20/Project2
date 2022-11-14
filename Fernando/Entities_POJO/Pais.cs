using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Pais
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public IList<Provincia> Provincias { get; set; }
    }
}
