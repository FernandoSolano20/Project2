using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper.Contrasenna;
using Entities_POJO;

namespace DataAccess.Crud.Contrasenna
{
    public class ContrasennaCrudFactory : CrudFactory
    {
        ContrasennaMapper mapper;
        public ContrasennaCrudFactory() : base()
        {
            mapper = new ContrasennaMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (Entities_POJO.Contrasenna)entity;
            var sqlOperation = mapper.GetCreateStatement(customer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T RetrieveId<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementById(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T RetrieveIdUserActive<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByIdUserActive(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveIdUser<T>(BaseEntity entity)
        {
            var lstEntity = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatementByIdUser(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstEntity.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstEntity;
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }


        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public  void UpdateEstatus(BaseEntity entity)
        {
            var customer = (Entities_POJO.Contrasenna)entity;
            dao.ExecuteProcedure(mapper.GetUpdateEstatusStatement(customer));
        }
        
        public override void Delete(BaseEntity entity)
        {
            var customer = (Entities_POJO.Contrasenna)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(customer));
        }
    }
}
