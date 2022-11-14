using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.Configuracion;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.ConfiguracionManager
{
    public class ConfiguracionManager : BaseManager
    {
        private ConfiguracionCrudFactory factory;

        public ConfiguracionManager()
        {
            factory = new ConfiguracionCrudFactory();
        }

        public Configuracion RetrieveByParameter(Configuracion configuracion)
        {
            Configuracion tempConfiguracion = null;

            try
            {

                tempConfiguracion = factory.Retrieve<Configuracion>(configuracion);

                if (tempConfiguracion == null)
                {
                    throw new BusinessException("32");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempConfiguracion;
        }
    }
}
