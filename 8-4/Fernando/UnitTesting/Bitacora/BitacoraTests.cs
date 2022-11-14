using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Bitacora
{
    [TestClass]
    public class BitacoraTests
    {
        [TestMethod]
        public void Membresia_Inicializacion_IDEsIgual()
        {
            //Arrange
            var bitacora = new Entities_POJO.Bitacora();
            //Act
            bitacora.ID = 10;
            //Asert
            Assert.AreEqual(10, bitacora.ID);
        }
        [TestMethod]
        public void Membresia_Inicializacion_EntidadEsIgual()
        {
            //Arrange
            var bitacora = new Entities_POJO.Bitacora();
            //Act
            bitacora.Entidad = "TipoTrabajo";
            //Asert
            Assert.AreEqual("TipoTrabajo", bitacora.Entidad);
        }
        [TestMethod]
        public void Membresia_Inicializacion_AccionEsIgual()
        {
            //Arrange
            var bitacora = new Entities_POJO.Bitacora();
            //Act
            bitacora.Accion = "Get";
            //Asert
            Assert.AreEqual("Get", bitacora.Accion);
        }
        [TestMethod]
        public void Membresia_Inicializacion_FechaEsIgual()
        {
            //Arrange
            var bitacora = new Entities_POJO.Bitacora();
            //Act
            bitacora.Fecha = new DateTime(2000,10,10);
            //Asert
            Assert.AreEqual(new DateTime(2000, 10, 10), bitacora.Fecha);
        }
        [TestMethod]
        public void Membresia_Inicializacion_IdentificadorEsIgual()
        {
            //Arrange
            var bitacora = new Entities_POJO.Bitacora();
            //Act
            bitacora.Identificador = "ID:0";
            //Asert
            Assert.AreEqual("ID:0", bitacora.Identificador);
        }
        [TestMethod]
        public void Membresia_Inicializacion_VerboEsIgual()
        {
            //Arrange
            var bitacora = new Entities_POJO.Bitacora();
            //Act
            bitacora.Verbo = "POST";
            //Asert
            Assert.AreEqual("POST", bitacora.Verbo);
        }
        [TestMethod]
        public void Membresia_Inicializacion_ID_UsuarioEsIgual()
        {
            //Arrange
            var bitacora = new Entities_POJO.Bitacora();
            //Act
            bitacora.ID_Usuario = "117640741";
            //Asert
            Assert.AreEqual("117640741", bitacora.ID_Usuario);
        }
    }
}
