using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper.TerminosServicio;
using Entities_POJO;

namespace DataAccess.Crud.TerminosServicio
{
    public class TerminosServicioCrudFactory : CrudFactory
    {
        private TerminosServicioMapper mapper;
        private SqlDao dao;

        public TerminosServicioCrudFactory()
        {
            mapper = new TerminosServicioMapper();
            dao = SqlDao.GetInstance();
        }

        //Create
        public override void Create(BaseEntity entity)
        {
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;
            var sqlOperation = mapper.GetCreateStatement(terminosServicio);
            dao.ExecuteProcedure(sqlOperation);
        }

        //Delete
        public override void Delete(BaseEntity entity)
        {
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;
            var sqlOperation = mapper.GetDeleteStatement(terminosServicio);
            dao.ExecuteProcedure(sqlOperation);
        }

        //Get by Titulo
        public override T Retrieve<T>(BaseEntity entity)
        {
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;
            var sqlOperation = mapper.GetRetriveStatement(terminosServicio);
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

        //Get by Estado                                             //--> Agregar a la interfaz ISQLStatement
        public List<T> RetrieveStatus<T>(BaseEntity entity)
        {
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;
            var sqlOperation = mapper.GetRetriveStatusStatement(terminosServicio);
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


        //Get all
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

        //Update
        public override void Update(BaseEntity entity)
        {
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;
            var sqlOperation = mapper.GetUpdateStatement(terminosServicio);
            dao.ExecuteProcedure(sqlOperation);
        }

        //Update Estado
        public void UpdateStatus(BaseEntity entity)
        {
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;
            var sqlOperation = mapper.GetUpdateStatusStatement(terminosServicio);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
