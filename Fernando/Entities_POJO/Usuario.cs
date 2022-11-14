using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Usuario : BaseEntity
    {
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Genero { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string PaisNacimiento { get; set; }
        public DateTime FechaNacimeinto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CodigoVerificacion { get; set; }
        public int IntentosContrasenna { get; set; }
        public string Moneda { get; set; }
        public string EstadoChatbot { get; set; }
        public string Estado { get; set; }
        public string Lenguaje { get; set; }
        public string IdEmpresa { get; set; }
    }
}
