using DataAccess.Dao;
using DataAccess.Mapper.Configuracion;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.Configuracion
{
    public class ConfiguracionCrudFactory : CrudFactory
    {
        private ConfiguracionMapper mapper;

        public ConfiguracionCrudFactory()
        {
            mapper = new ConfiguracionMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var configuracion = (Entities_POJO.Configuracion)entity;
            var sqlOperation = mapper.GetCreateStatement(configuracion);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var configuracion = (Entities_POJO.Configuracion)entity;
            var sqlOperation = mapper.GetDeleteStatement(configuracion);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var configuracion = (Entities_POJO.Configuracion)entity;
            var sqlOperation = mapper.GetRetriveStatement(configuracion);
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

        public override void Update(BaseEntity entity)
        {
            var configuracion = (Entities_POJO.Configuracion)entity;
            var sqlOperation = mapper.GetUpdateStatement(configuracion);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
