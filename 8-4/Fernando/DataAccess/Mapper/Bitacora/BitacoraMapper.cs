using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Bitacora
{
    public class BitacoraMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ENTIDAD = "ENTIDAD";
        private const string DB_COL_IDENTIFICADOR = "IDENTIFICADOR";
        private const string DB_COL_ACCION = "ACCION";
        private const string DB_COL_VERBO = "VERBO";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_BITACORA_INSERT_SP" };
            var bitacora = (Entities_POJO.Bitacora)entity;

            operation.AddDatetimeParam(DB_COL_FECHA, bitacora.Fecha);
            operation.AddNVarcharParam(DB_COL_ENTIDAD, bitacora.Entidad);
            operation.AddNVarcharParam(DB_COL_IDENTIFICADOR, bitacora.Identificador);
            operation.AddNVarcharParam(DB_COL_ACCION, bitacora.Accion);
            operation.AddNVarcharParam(DB_COL_VERBO, bitacora.Verbo);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, bitacora.ID_Usuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_BITACORA_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var bitacora = new Entities_POJO.Bitacora()
            {
                ID = GetIntValue(row, DB_COL_ID),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Entidad = GetStringValue(row, DB_COL_ENTIDAD),
                Identificador = GetStringValue(row, DB_COL_IDENTIFICADOR),
                Accion = GetStringValue(row, DB_COL_ACCION),
                Verbo = GetStringValue(row, DB_COL_VERBO),
                ID_Usuario = GetStringValue(row, DB_COL_ID_USUARIO)
            };

            return bitacora;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var bitacora = BuildObject(element);
                listResults.Add(bitacora);
            }
            return listResults;
        }

    }
}
