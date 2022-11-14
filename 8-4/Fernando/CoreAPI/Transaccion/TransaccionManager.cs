using DataAccess.Crud.Transaccion;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Transaccion
{
    public class TransaccionManager : BaseManager
    {
        private TransaccionCrudFactory factory;

        public TransaccionManager()
        {
            factory = new TransaccionCrudFactory();
        }

        public void Create(Entities_POJO.Transaccion transaccion)
        {
            try
            {
                var tempTipoTrabjo = factory.Retrieve<Entities_POJO.Transaccion>(transaccion);

                if (tempTipoTrabjo != null)
                {
                    throw new BusinessException("33");
                }
                else
                    factory.Create(transaccion);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Entities_POJO.Transaccion RetrieveByID(Entities_POJO.Transaccion transaccion)
        {
            Entities_POJO.Transaccion tempTransaccion = null;

            try
            {

                tempTransaccion = factory.Retrieve<Entities_POJO.Transaccion>(transaccion);

                if (tempTransaccion == null)
                {
                    throw new BusinessException("34");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempTransaccion;
        }

        public List<Entities_POJO.Transaccion> RetrieveAll()
        {
            return factory.RetrieveAll<Entities_POJO.Transaccion>();
        }

        public void Update(Entities_POJO.Transaccion transaccion)
        {
            try
            {
                var tempTransaccion = factory.Retrieve<Entities_POJO.Transaccion>(transaccion);

                if (tempTransaccion == null)
                {
                    throw new BusinessException("34");
                }
                else
                    factory.Update(transaccion);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(Entities_POJO.Transaccion transaccion)
        {
            try
            {

                var tempTransaccion = factory.Retrieve<Entities_POJO.Transaccion>(transaccion);

                if (tempTransaccion == null)
                {
                    throw new BusinessException("34");
                }
                else
                    factory.Delete(transaccion);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
