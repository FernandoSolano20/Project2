using DataAccess.Crud.TipoTrabajo;
using Entities_POJO;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class TipoTrabajoManager : BaseManager
    {
        private TipoTrabajoCrudFactory factory;

        public TipoTrabajoManager()
        {
            factory = new TipoTrabajoCrudFactory();
        }

        public void Create(TipoTrabajo tipoTrabajo)
        {
            try
            {
                tipoTrabajo.Estado = Estado.ACT;
                var tempTipoTrabjo = factory.Retrieve<TipoTrabajo>(tipoTrabajo);

                if (tempTipoTrabjo != null)
                {
                    throw new BusinessException("10");
                }
                else
                    factory.Create(tipoTrabajo);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public TipoTrabajo RetrieveByID(TipoTrabajo tipoTrabajo)
        {
            TipoTrabajo tempTipoTrabajo = null;

            try
            {

                tempTipoTrabajo = factory.Retrieve<TipoTrabajo>(tipoTrabajo);

                if (tempTipoTrabajo == null)
                {
                    throw new BusinessException("11");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempTipoTrabajo;
        }

        public List<TipoTrabajo> RetrieveActive()
        {
            var tipoTrabajo = new TipoTrabajo
            {
                Estado = Estado.ACT
            };
            return factory.RetrieveStatus<TipoTrabajo>(tipoTrabajo);
        }

        public List<TipoTrabajo> RetrieveAll()
        {
            return factory.RetrieveAll<TipoTrabajo>();
        }

        public void Update(TipoTrabajo tipoTrabajo)
        {
            try
            {
                var tempTipoTrabajo = factory.Retrieve<TipoTrabajo>(tipoTrabajo);

                if (tempTipoTrabajo == null)
                {
                    throw new BusinessException("11");
                }
                else
                    factory.Update(tipoTrabajo);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Delete(TipoTrabajo tipoTrabajo)
        {   
            try
            {
                //Se agrega este valor para obtener los registros en DB que esten activos unicamente
                tipoTrabajo.Estado = Estado.ACT;

                bool relacionesTrabajadores = factory.RetrieveJobTypeWorkerPerStatus(tipoTrabajo);

                if (relacionesTrabajadores)
                {
                    throw new BusinessException("12");
                }
                else
                {
                    var tempTipoTrabajo = factory.Retrieve<TipoTrabajo>(tipoTrabajo);

                    if (tempTipoTrabajo == null)
                    {
                        throw new BusinessException("11");
                    }
                    else
                        factory.Delete(tipoTrabajo);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void UpdateStatus(TipoTrabajo tipoTrabajo)
        {
            try
            {
                if (tipoTrabajo.Estado == Estado.ACT)
                    tipoTrabajo.Estado = Estado.DES;
                else
                    tipoTrabajo.Estado = Estado.ACT;

                var tempTipoTrabajo = factory.Retrieve<TipoTrabajo>(tipoTrabajo);

                if (tempTipoTrabajo == null)
                {
                    throw new BusinessException("11");
                }
                else
                    factory.UpdateStatus(tipoTrabajo);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
