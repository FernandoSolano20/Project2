using DataAccess.Dao;
using DataAccess.Mapper.Documento;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.Documento
{
    public class DocumentoCrudFactory : CrudFactory
    {
        private DocumentoMapper mapper;
        private SqlDao dao;

        public DocumentoCrudFactory()
        {
            mapper = new DocumentoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var documento = (Entities_POJO.Documento)entity;
            var sqlOperation = mapper.GetCreateStatement(documento);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var documento = (Entities_POJO.Documento)entity;
            var sqlOperation = mapper.GetDeleteStatement(documento);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var documento = (Entities_POJO.Documento)entity;
            var sqlOperation = mapper.GetRetriveStatement(documento);
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

        //Agregar a la interfaz ISQLStatement
        public List<T> RetrieveStatus<T>(BaseEntity entity)
        {
            var documento = (Entities_POJO.Documento)entity;
            var sqlOperation = mapper.GetRetriveStatusStatement(documento);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);
            var resultList = new List<T>();

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

        public List<T> RetrieveByUserID<T>(BaseEntity entity)
        {
            var documento = (Entities_POJO.Documento)entity;
            var sqlOperation = mapper.GetRetriveByUserIDStatement(documento);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);
            var resultList = new List<T>();

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
            var documento = (Entities_POJO.Documento)entity;
            var sqlOperation = mapper.GetUpdateStatement(documento);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateStatus(BaseEntity entity)
        {
            var documento = (Entities_POJO.Documento)entity;
            var sqlOperation = mapper.GetUpdateStatusStatement(documento);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
