using DataAccess.Crud.Membresia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.MembresiaManager
{
    public class MembresiaManager : BaseManager
    {
        private MembresiaCrudFactory factory;

        public MembresiaManager()
        {
            factory = new MembresiaCrudFactory();
        }

        public void Create(Membresia membresia)
        {
            try
            {
                membresia.Estado = Estado.NOCOMPRADO;
                var tempMembresia = factory.Retrieve<Membresia>(membresia);

                if (tempMembresia != null)
                {
                    throw new BusinessException("30");
                }
                else
                    factory.Create(membresia);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public Membresia RetrieveByID(Membresia membresia)
        {
            Membresia tempMembresia = null;

            try
            {

                tempMembresia = factory.Retrieve<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempMembresia;
        }

        public Membresia RetrievePerDate(Membresia membresia)
        {
            Membresia tempMembresia = new Membresia();
            try
            {
                tempMembresia = factory.RetrievePerDate<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                    return tempMembresia;

            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return tempMembresia;
        }

        public List<Membresia> RetrieveAll()
        {
            return factory.RetrieveAll<Membresia>();
        }

        public void Update(Membresia membresia)
        {
            try
            {
                var tempMembresia = factory.Retrieve<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                    factory.Update(membresia);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        

        public void UpdateDate(Membresia membresia)
        {
            try
            {

                var tempMembresia = factory.RetrievePerDate<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                {
                    //Si la membresia está vencida, a partir de la fecha de hoy estará vigente un año
                    //Si no, añadirá un año más a la fecha de vencimiento.

                    if(tempMembresia.Fecha < DateTime.Now)
                        membresia.Fecha = DateTime.Now.AddYears(1);
                    else
                        membresia.Fecha = tempMembresia.Fecha.AddYears(1);

                    membresia.Estado = Estado.ACT;

                    factory.UpdateDate(membresia);
                }
                    

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
        public void Delete(Membresia membresia)
        {
            try
            {
                var tempMembresia = factory.Retrieve<Membresia>(membresia);

                if (tempMembresia == null)
                {
                    throw new BusinessException("31");
                }
                else
                    factory.Delete(membresia);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }


}
