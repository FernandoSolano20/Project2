using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.AppCode.Helper;
using DataAccess.Crud.Empresa;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.EmpresaManager
{
    public class EmpresaManager : BaseManager
    {
        private EmpresaCrudFactory crudFactory;

        public EmpresaManager()
        {
            crudFactory = new EmpresaCrudFactory();
        }

        public void Create(Empresa entity)
        {
            try
            {
                var c = crudFactory.Retrieve<Empresa>(entity);

                if (c != null)
                {
                    throw new BusinessException("1");
                }
                entity.FechaIngreso = DateTime.Now;
                crudFactory.Create(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public IList<Empresa> RetrieveAll()
        {
            var entities = new List<Empresa>();
            try
            {
                entities = crudFactory.RetrieveAll<Empresa>();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return entities;
        }

        public Empresa RetrieveById(Empresa entity)
        {
            Empresa c = null;
            try
            {
                c = crudFactory.Retrieve<Empresa>(entity);
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

        public void Update(Empresa entity)
        {

        }

        public void Delete(Empresa entity)
        {

        }
    }
}
