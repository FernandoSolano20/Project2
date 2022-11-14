using DataAccess.Dao;
using DataAccess.Mapper.Membresia;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.Membresia
{ 
    public class MembresiaCrudFactory : CrudFactory
    {

        private MembresiaMapper mapper;


        public MembresiaCrudFactory()
        {
            dao = SqlDao.GetInstance();
            mapper = new MembresiaMapper();
        }

        public override void Create(BaseEntity entity)
        {
            var membresia = (Entities_POJO.Membresia)entity;
            SqlOperation operation = mapper.GetCreateStatement(membresia);
            dao.ExecuteProcedure(operation);
        }

        public override void Delete(BaseEntity entity)
        {
            var membresia = (Entities_POJO.Membresia)entity;
            SqlOperation operation = mapper.GetDeleteStatement(membresia);
            dao.ExecuteProcedure(operation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var membresia = (Entities_POJO.Membresia)entity;
            var sqlOperation = mapper.GetRetriveStatement(membresia);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);
            var objectDictionary = new Dictionary<string, object>();

            if (queryResult.Count > 0)
            {
                objectDictionary = queryResult[0];
                var finalObject = mapper.BuildObject(objectDictionary);
                return (T)Convert.ChangeType(finalObject, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var resultList = new List<T>();
            var sqlOperation = mapper.GetRetriveAllStatement();
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);


            if (queryResult.Count > 0)
            {
                var finalObjects = mapper.BuildObjects(queryResult);

                foreach (var element in finalObjects)
                {
                    resultList.Add((T)Convert.ChangeType(element, typeof(T)));
                }
            }
            return resultList;
        }

        public T RetrievePerDate<T>(BaseEntity entity)
        {
            var membresia = (Entities_POJO.Membresia)entity;
            var sqlOperation = mapper.GetRetrivePerDateStatement(membresia);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);
            var objectDictionary = new Dictionary<string, object>();

            if (queryResult.Count > 0)
            {
                objectDictionary = queryResult[0];
                var finalObject = mapper.BuildObject(objectDictionary);
                return (T)Convert.ChangeType(finalObject, typeof(T));
            }

            return default(T);
        }

        public override void Update(BaseEntity entity)
        {
            var membresia = (Entities_POJO.Membresia)entity;
            var sqlOperation = mapper.GetUpdateStatement(membresia);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateDate(BaseEntity entity)
        {
            var membresia = (Entities_POJO.Membresia)entity;
            var sqlOperation = mapper.GetUpdateDateStatement(membresia);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
