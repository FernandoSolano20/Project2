using Entities_POJO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    [TestClass]
    public class TipoTrabajoTests
    {
        [TestMethod]
        public void TipoTrabajo_Inicializacion_NombreEsIgual()
        {
            //Arrange
            var tipoTrabajo = new TipoTrabajo();
            //Act
            tipoTrabajo.Nombre = "Reparacion";
            //Asert
            Assert.AreEqual("Reparacion", tipoTrabajo.Nombre);
           
        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_IDEsIgual()
        {
            //Arrange
            var tipoTrabajo = new TipoTrabajo();
            //Act
            tipoTrabajo.ID = 0;
            //Asert
            Assert.AreEqual(0, tipoTrabajo.ID);

        }

        [TestMethod]
        public void TipoTrabajo_Inicializacion_EstadoEsIgual()
        {
            //Arrange
            var tipoTrabajo = new TipoTrabajo();
            //Act
            tipoTrabajo.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", tipoTrabajo.Estado);

        }
    }
}
