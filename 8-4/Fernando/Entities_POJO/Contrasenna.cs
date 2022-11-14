using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Contrasenna : BaseEntity
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public string Password { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
