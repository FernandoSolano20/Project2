using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Configuracion
{
    public class ConfiguracionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {

        private const string DB_COL_PARAMETRO = "PARAMETRO";
        private const string DB_COL_VALOR = "VALOR";
       

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_CONFIGURACION_INSERT_SP" };
            var configuracion = (Entities_POJO.Configuracion)entity;

            operation.AddNVarcharParam(DB_COL_PARAMETRO, configuracion.Parametro);
            operation.AddNVarcharParam(DB_COL_VALOR, configuracion.Valor);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_CONFIGURACION_DELETE_SP" };
            var configuracion = (Entities_POJO.Configuracion)entity;

            operation.AddNVarcharParam(DB_COL_PARAMETRO, configuracion.Parametro);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_CONFIGURACION_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_CONFIGURACION_SELECT_PARAMETRO_SP" };
            var membresia = (Entities_POJO.Configuracion)entity;

            operation.AddNVarcharParam(DB_COL_PARAMETRO, membresia.Parametro);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_CONFIGURACION_UPDATE_SP" };
            var configuracion = (Entities_POJO.Configuracion)entity;

            operation.AddNVarcharParam(DB_COL_PARAMETRO, configuracion.Parametro);
            operation.AddNVarcharParam(DB_COL_VALOR, configuracion.Valor);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var configuracion = new Entities_POJO.Configuracion()
            {
                Parametro = GetStringValue(row, DB_COL_PARAMETRO),
                Valor = GetStringValue(row, DB_COL_VALOR)
            };

            return configuracion;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var configuracion = BuildObject(element);
                listResults.Add(configuracion);
            }
            return listResults;
        }
    }
}
