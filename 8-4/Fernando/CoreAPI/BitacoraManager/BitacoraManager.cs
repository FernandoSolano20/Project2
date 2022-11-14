using DataAccess.Crud.Bitacora;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.BitacoraManager
{
    public class BitacoraManager : BaseManager
    {
        private BitacoraCrudFactory factory;

        public BitacoraManager()
        {
            factory = new BitacoraCrudFactory();
        }

        public void Create(Bitacora bitacora)
        {
            try
            {
              factory.Create(bitacora);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Bitacora> RetrieveAll()
        {
            return factory.RetrieveAll<Bitacora>();
        }
    }
}
