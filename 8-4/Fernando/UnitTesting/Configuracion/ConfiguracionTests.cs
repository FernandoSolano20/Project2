using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Configuracion
{
    [TestClass]
    public class ConfiguracionTests
    {
        [TestMethod]
        public void Configuracion_Inicializacion_ParametroEsIgual()
        {
            //Arrange
            var configuracion = new Entities_POJO.Configuracion();
            //Act
            configuracion.Parametro = "IVA";
            //Asert
            Assert.AreEqual("IVA", configuracion.Parametro);
        }

        [TestMethod]
        public void Configuracion_Inicializacion_ValorEsIgual()
        {
            //Arrange
            var configuracion = new Entities_POJO.Configuracion();
            //Act
            configuracion.Valor = "0.13";
            //Asert
            Assert.AreEqual("0.13", configuracion.Valor);
        }
    }
}
