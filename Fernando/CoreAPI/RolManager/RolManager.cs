using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.Rol;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.RolManager
{
    public class RolManager : BaseManager
    {
        private RolCrudFactory crudFactory;

        public RolManager()
        {
            crudFactory = new RolCrudFactory();
        }

        public Rol RetrieveByName(Rol entity)
        {
            Rol c = null;
            try
            {
                c = crudFactory.RetrieveByName<Rol>(entity);
                if (c == null)
                {
                    throw new BusinessException("3");
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Create(Rol rol)
        {
            try
            {
                var c = crudFactory.Retrieve<Rol>(rol);

                if (c != null)
                {
                    //Type already exist
                    throw new BusinessException("2");
                }
                else
                    crudFactory.Create(rol);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Rol> RetrieveAll()
        {
            return crudFactory.RetrieveAll<Rol>();
        }

        public Rol RetrieveById(Rol rol)
        {
            Rol c = null;
            try
            {
                c = crudFactory.Retrieve<Rol>(rol);
                if (c == null)
                {
                    throw new BusinessException("1");
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Rol rol)
        {
            crudFactory.Update(rol);
        }

        public void Delete(Rol rol)
        {
            crudFactory.Delete(rol);
        }
    }
}
