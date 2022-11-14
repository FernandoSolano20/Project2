using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.TerminosServicio
{
    public class TerminosServicioMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        //Columnas de TBL_TERMINOS_SERVICIO
        private const string DB_COL_TITULO = "TITULO";
        private const string DB_COL_DESCRIPCION = "DESCRIPCION";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_IDIOMA = "IDIOMA";

        //Insert
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TERMINOS_SERVICIO_INSERT_SP" };
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;

            operation.AddNVarcharParam(DB_COL_TITULO, terminosServicio.Titulo);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, terminosServicio.Descripcion);
            operation.AddNVarcharParam(DB_COL_ESTADO, terminosServicio.Estado);
            operation.AddNVarcharParam(DB_COL_IDIOMA, terminosServicio.Idioma);

            return operation;
        }

        //Delete
        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TERMINOS_SERVICIO_DELETE_SP" };
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;

            operation.AddNVarcharParam(DB_COL_TITULO, terminosServicio.Titulo);

            return operation;
        }

        //Select Todos
        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TERMINOS_SERVICIO_SELECT_ALL_SP" };

            return operation;
        }

        //Select por Titulo
        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TERMINOS_SERVICIO_SELECT_TITULO_SP" };
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;

            operation.AddNVarcharParam(DB_COL_TITULO, terminosServicio.Titulo);

            return operation;
        }

        //Select por Estado
        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TERMINOS_SERVICIO_SELECT_ESTADO_SP" };
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, terminosServicio.Estado);

            return operation;
        }


        //Update
        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TERMINOS_SERVICIO_UPDATE_SP" };
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;

            operation.AddNVarcharParam(DB_COL_TITULO, terminosServicio.Titulo);
            operation.AddNVarcharParam(DB_COL_DESCRIPCION, terminosServicio.Descripcion);
            //operation.AddNVarcharParam(DB_COL_ESTADO, terminosServicio.Estado);
            operation.AddNVarcharParam(DB_COL_IDIOMA, terminosServicio.Idioma);

            return operation;
        }

        //Update Estado
        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TERMINOS_SERVICIO_UPDATE_STATUS_SP" };
            var terminosServicio = (Entities_POJO.TerminosServicio)entity;

            operation.AddNVarcharParam(DB_COL_TITULO, terminosServicio.Titulo);
            operation.AddNVarcharParam(DB_COL_ESTADO, terminosServicio.Estado);

            return operation;
        }


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var terminosServicio = new Entities_POJO.TerminosServicio()
            {
                Titulo = GetStringValue(row, DB_COL_TITULO),
                Descripcion = GetStringValue(row, DB_COL_DESCRIPCION),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Idioma = GetStringValue(row, DB_COL_IDIOMA)
            };

            return terminosServicio;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var terminosServicio = BuildObject(element);
                listResults.Add(terminosServicio);
            }
            return listResults;
        }
    }
}
