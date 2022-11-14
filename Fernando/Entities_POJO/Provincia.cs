using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Provincia
    {
        public string Title { get; set; }
        public IList<Canton> Cantones { get; set; }
    }
}
