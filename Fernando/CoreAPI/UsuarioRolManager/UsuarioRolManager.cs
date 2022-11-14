using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.UsuarioRol;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.UsuarioRolManager
{
    public class UsuarioRolManager : BaseManager
    {
        private UsuarioRolCrudFactory crudFactory;

        public UsuarioRolManager()
        {
            crudFactory = new UsuarioRolCrudFactory();
        }

        public void Create(UsuarioRol entity)
        {
            try
            {
                var c = crudFactory.Retrieve<UsuarioRol>(entity);

                if (c != null)
                {
                    throw new BusinessException("1");
                }

                crudFactory.Create(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public IList<UsuarioRol> RetrieveAll()
        {
            var entities = new List<UsuarioRol>();
            try
            {
                entities = crudFactory.RetrieveAll<UsuarioRol>();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return entities;
        }

        public UsuarioRol RetrieveById(UsuarioRol entity)
        {
            UsuarioRol c = null;
            try
            {
                c = crudFactory.Retrieve<UsuarioRol>(entity);
                if (c == null)
                {
                    throw new BusinessException("2");
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Delete(UsuarioRol entity)
        {

        }
    }
}
