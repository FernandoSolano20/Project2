using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Canton
    {
        public string Title { get; set; }
        public IList<Distrito> Distritos { get; set; }
    }
}
