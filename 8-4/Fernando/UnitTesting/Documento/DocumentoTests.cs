using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Documento
{
    [TestClass]
    public class DocumentoTests
    {
        [TestMethod]
        public void Documento_Inicializacion_IDEsIgual()
        {
            //Arrange
            var documento = new Entities_POJO.Documento();
            //Act
            documento.ID = 15;
            //Asert
            Assert.AreEqual(15, documento.ID);
        }

        [TestMethod]
        public void Documento_Inicializacion_URLEsIgual()
        {
            //Arrange
            var documento = new Entities_POJO.Documento();
            //Act
            documento.URL = "https://www.google.com";
            //Asert
            Assert.AreEqual("https://www.google.com", documento.URL);
        }

        [TestMethod]
        public void Documento_Inicializacion_TituloEsIgual()
        {
            //Arrange
            var documento = new Entities_POJO.Documento();
            //Act
            documento.Titulo = "Patente";
            //Asert
            Assert.AreEqual("Patente", documento.Titulo);
        }

        [TestMethod]
        public void Documento_Inicializacion_ID_PropietarioEsIgual()
        {
            //Arrange
            var documento = new Entities_POJO.Documento();
            //Act
            documento.ID_Propietario = "117640741";
            //Asert
            Assert.AreEqual("117640741", documento.ID_Propietario);
        }

        [TestMethod]
        public void Documento_Inicializacion_Tipo_DocumentoEsIgual()
        {
            //Arrange
            var documento = new Entities_POJO.Documento();
            //Act
            documento.TipoDocumento = "Oficial";
            //Asert
            Assert.AreEqual("Oficial", documento.TipoDocumento);
        }

        [TestMethod]
        public void Documento_Inicializacion_EstadoEsIgual()
        {
            //Arrange
            var documento = new Entities_POJO.Documento();
            //Act
            documento.Estado = "ACT";
            //Asert
            Assert.AreEqual("ACT", documento.Estado);
        }
    }
}
