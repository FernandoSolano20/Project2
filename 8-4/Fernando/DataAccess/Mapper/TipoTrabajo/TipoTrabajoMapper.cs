using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.TipoTrabajo
{
    public class TipoTrabajoMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        //Atributos inherentes de la tabla TipoTrabajo
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_ESTADO = "ESTADO";

        //Atributos de la tabla Tipo_Trabajo_Trabajador
        private const string DB_ID_TIPO_TRABAJO = "ID_TIPO_TRABAJO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_INSERT_SP" };
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;

            operation.AddNVarcharParam(DB_COL_NOMBRE, tipoTrabajo.Nombre);
            operation.AddNVarcharParam(DB_COL_ESTADO, tipoTrabajo.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_DELETE_SP" };
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID, tipoTrabajo.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_SELECT_ID_SP" };
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID, tipoTrabajo.ID);

            return operation;
        }

        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_SELECT_ESTADO_SP" };
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, tipoTrabajo.Estado);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_UPDATE_SP" };
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID, tipoTrabajo.ID);
            operation.AddNVarcharParam(DB_COL_NOMBRE, tipoTrabajo.Nombre);

            return operation;
        }

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_UPDATE_STATUS_SP" };
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;

            operation.AddIntParam(DB_COL_ID, tipoTrabajo.ID);
            operation.AddNVarcharParam(DB_COL_ESTADO, tipoTrabajo.Estado);

            return operation;
        }

        //Operaciones para obtener los tipos de trabajo relacionados con trabajadores
        public SqlOperation GetRetriveSelectAllJobTypeWorkerStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TIPO_TRABAJO_TRABAJADOR_SELECT_ESTADO_SP" };
            var tipoTrabajo = (Entities_POJO.TipoTrabajo)entity;

            operation.AddIntParam(DB_ID_TIPO_TRABAJO, tipoTrabajo.ID);
            operation.AddNVarcharParam(DB_COL_ESTADO, tipoTrabajo.Estado);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var tipoTrabajo = new Entities_POJO.TipoTrabajo()
            {
                ID = GetIntValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };

            return tipoTrabajo;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var tipoTrabajo = BuildObject(element);
                listResults.Add(tipoTrabajo);
            }
            return listResults;
        }
    }
}
