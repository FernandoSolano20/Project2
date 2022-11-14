using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.TerminosServicio;
using Entities_POJO;
using Excepciones;

namespace CoreAPI
{
    public class TerminosServicioManager : BaseManager
    {
        private TerminosServicioCrudFactory factory;

        public TerminosServicioManager()
        {
            factory = new TerminosServicioCrudFactory();
        }

        //Create - Post
        public void Create(TerminosServicio terminosServicio)
        {
            try
            {
                terminosServicio.Estado = Estado.ACT;
                var tempTerminosServ = factory.Retrieve<TerminosServicio>(terminosServicio);

                if (tempTerminosServ != null)
                {
                    throw new BusinessException("20");
                }
                else
                    factory.Create(terminosServicio);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //RetrieveByTitulo - Get by
        public TerminosServicio RetrieveByTitulo(TerminosServicio terminosServicio)
        {
            TerminosServicio tempTerminosServ = null;

            try
            {

                tempTerminosServ = factory.Retrieve<TerminosServicio>(terminosServicio);

                if (tempTerminosServ == null)
                {
                    throw new BusinessException("21");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempTerminosServ;
        }

        //RetrieveAll - Get All
        public List<TerminosServicio> RetrieveAll()
        {
            return factory.RetrieveAll<TerminosServicio>();
        }

        //Update
        public void Update(TerminosServicio terminosServicio)
        {
            try
            {
                var tempTerminosServ = factory.Retrieve<TerminosServicio>(terminosServicio);

                if (tempTerminosServ == null)
                {
                    throw new BusinessException("21");
                }
                else
                    factory.Update(terminosServicio);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //Delete
        public void Delete(TerminosServicio terminosServicio)
        {
            try
            {
                var tempTerminosServ = factory.Retrieve<TerminosServicio>(terminosServicio);

                if (tempTerminosServ == null)
                {
                    throw new BusinessException("21");
                }
                else
                    factory.Delete(terminosServicio);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        //UpdateStatus
        public void UpdateStatus(TerminosServicio terminosServicio)
        {
            try
            {
                if (terminosServicio.Estado == Estado.ACT)
                {
                    terminosServicio.Estado = Estado.DES;
                }
                else
                {
                    terminosServicio.Estado = Estado.ACT;
                }

                var tempTerminosServ = factory.Retrieve<TerminosServicio>(terminosServicio);

                if (tempTerminosServ == null)
                {
                    throw new BusinessException("21");
                }
                else
                    factory.UpdateStatus(terminosServicio);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
