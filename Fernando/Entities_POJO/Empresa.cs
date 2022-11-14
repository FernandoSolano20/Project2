using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Empresa : BaseEntity
    {
        public string Cedula { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Tipo { get; set; }
        public string TipoMembresia { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string IdRepresentante { get; set; }
    }
}
