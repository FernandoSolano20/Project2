using DataAccess.Dao;
using DataAccess.Mapper.TipoTrabajo;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud.TipoTrabajo
{
    public class TipoTrabajoCrudFactory : CrudFactory
    {

        private TipoTrabajoMapper mapper;
        private SqlDao dao;

        public TipoTrabajoCrudFactory()
        {
            mapper = new TipoTrabajoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;
            var sqlOperation = mapper.GetCreateStatement(tipoTrabajo);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;
            var sqlOperation = mapper.GetDeleteStatement(tipoTrabajo);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;
            var sqlOperation = mapper.GetRetriveStatement(tipoTrabajo);
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
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;
            var sqlOperation = mapper.GetRetriveStatusStatement(tipoTrabajo);
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

        //Metodo que busca en la tabla TBL_TIPO_TRABAJO_TRABAJADOR si existe algun registro relacionado con un tipo de trabajo especifico. Esto para validar que al borrar o desactivar un registro, este no afecte ninguna otra parte de la aplicacion
        public bool RetrieveJobTypeWorkerPerStatus(BaseEntity entity)
        {
            var exist = false;
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;
            var sqlOperation = mapper.GetRetriveSelectAllJobTypeWorkerStatement(tipoTrabajo);
            var queryResult = dao.ExecuteQueryProcedure(sqlOperation);


            if (queryResult.Count > 0)
            {
                exist = true;
            }
            return exist;
        }

        public override void Update(BaseEntity entity)
        {
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;
            var sqlOperation = mapper.GetUpdateStatement(tipoTrabajo);
            dao.ExecuteProcedure(sqlOperation);
        }

        public void UpdateStatus(BaseEntity entity)
        {
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;
            var sqlOperation = mapper.GetUpdateStatusStatement(tipoTrabajo);
            dao.ExecuteProcedure(sqlOperation);
        }
    }
}
