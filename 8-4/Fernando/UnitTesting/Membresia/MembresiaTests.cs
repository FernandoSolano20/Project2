using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;

namespace UnitTesting.Membresia
{
    [TestClass]
    public class MembresiaTests
    {
        [TestMethod]
        public void Membresia_Inicializacion_IDEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.ID = 1;
            //Asert
            Assert.AreEqual(1, membresia.ID);
        }

        [TestMethod]
        public void Membresia_Inicializacion_TipoEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.Tipo = "PRO";
            //Asert
            Assert.AreEqual("PRO", membresia.Tipo);
        }

        [TestMethod]
        public void Membresia_Inicializacion_CostoEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.Costo = 25;
            //Asert
            Assert.AreEqual(25, membresia.Costo);
        }

        [TestMethod]
        public void Membresia_Inicializacion_FechaEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.Fecha = new DateTime(1999,12,11);
            //Asert
            Assert.AreEqual(new DateTime(1999,12,11), membresia.Fecha);
        }

        [TestMethod]
        public void Membresia_Inicializacion_EstadoEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", membresia.Estado);
        }

        [TestMethod]
        public void Membresia_Inicializacion_ID_EmpresaEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.ID_Empresa = "500200";
            //Asert
            Assert.AreEqual("500200", membresia.ID_Empresa);
        }

        [TestMethod]
        public void Membresia_Inicializacion_ID_RepresentanteEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.ID_Representante = "117640741";
            //Asert
            Assert.AreEqual("117640741", membresia.ID_Representante);
        }

        [TestMethod]
        public void Membresia_Inicializacion_MonedaEsIgual()
        {
            //Arrange
            var membresia = new Entities_POJO.Membresia();
            //Act
            membresia.Moneda = "CRC";
            //Asert
            Assert.AreEqual("CRC", membresia.Moneda);
        }
    }
}
