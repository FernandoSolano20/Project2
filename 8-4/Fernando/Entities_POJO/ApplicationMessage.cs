using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class ApplicationMessage : BaseEntity
    {
        public string Key { get; set; }
        public string MensajeEspanol { get; set; }

        public string MensajeIngles { get; set; }
    }
}
