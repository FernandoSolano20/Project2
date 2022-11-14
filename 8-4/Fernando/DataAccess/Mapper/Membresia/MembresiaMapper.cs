using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Membresia
{
    public class MembresiaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_COSTO = "COSTO";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";
        private const string DB_COL_ID_REPRESENTANTE = "ID_REPRESENTANTE";

        //Moneda proveniente de la tabla de usuarios
        private const string DB_COL_MONEDA = "MONEDA";

        

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_MEMBRESIA_INSERT_SP" };
            var membresia = (Entities_POJO.Membresia)entity;

            operation.AddNVarcharParam(DB_COL_TIPO, membresia.Tipo);
            operation.AddDecimalParam(DB_COL_COSTO, membresia.Costo);
            operation.AddDatetimeParam(DB_COL_FECHA, membresia.Fecha);
            operation.AddNVarcharParam(DB_COL_ESTADO, membresia.Estado);
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, membresia.ID_Empresa);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_MEMBRESIA_DELETE_SP" };
            var membresia = (Entities_POJO.Membresia)entity;

            operation.AddIntParam(DB_COL_ID, membresia.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_MEMBRESIA_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_MEMBRESIA_SELECT_ID_SP" };
            var membresia = (Entities_POJO.Membresia)entity;

            operation.AddIntParam(DB_COL_ID, membresia.ID);

            return operation;
        }
        
        public SqlOperation GetRetrivePerDateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_MEMBRESIA_SELECT_ACTUAL_SP" };
            var membresia = (Entities_POJO.Membresia)entity;

            operation.AddNVarcharParam(DB_COL_ID_REPRESENTANTE, membresia.ID_Representante);

            return operation;
        }

        //  Permite ampliar el tiempo de expiración de una membresía
        public SqlOperation GetUpdateDateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_MEMBRESIA_UPDATE_FECHA_SP" };
            var membresia = (Entities_POJO.Membresia)entity;

            operation.AddNVarcharParam(DB_COL_ID_REPRESENTANTE, membresia.ID_Representante);
            operation.AddDatetimeParam(DB_COL_FECHA, membresia.Fecha);
            operation.AddNVarcharParam(DB_COL_ESTADO, membresia.Estado);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_MEMBRESIA_UPDATE_SP" };
            var membresia = (Entities_POJO.Membresia)entity;

            operation.AddIntParam(DB_COL_ID, membresia.ID);
            operation.AddDecimalParam(DB_COL_COSTO, membresia.Costo);
            operation.AddNVarcharParam(DB_COL_TIPO, membresia.Tipo);
            operation.AddDatetimeParam(DB_COL_FECHA, membresia.Fecha);
            operation.AddNVarcharParam(DB_COL_ESTADO, membresia.Estado);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            BaseEntity membresia;

            if (row.ContainsKey(DB_COL_MONEDA))
            {
                membresia = new Entities_POJO.Membresia()
                {
                    ID = GetIntValue(row, DB_COL_ID),
                    Tipo = GetStringValue(row, DB_COL_TIPO),
                    Costo = GetDecimalValue(row, DB_COL_COSTO),
                    Fecha = GetDateValue(row, DB_COL_FECHA),
                    Estado = GetStringValue(row, DB_COL_ESTADO),
                    ID_Empresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                    Moneda = GetStringValue(row, DB_COL_MONEDA)
                };
            }
            else
            {
                membresia = new Entities_POJO.Membresia()
                {
                    ID = GetIntValue(row, DB_COL_ID),
                    Tipo = GetStringValue(row, DB_COL_TIPO),
                    Costo = GetDecimalValue(row, DB_COL_COSTO),
                    Fecha = GetDateValue(row, DB_COL_FECHA),
                    Estado = GetStringValue(row, DB_COL_ESTADO),
                    ID_Empresa = GetStringValue(row, DB_COL_ID_EMPRESA)
                };
            }
            

            return membresia;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var membresia = BuildObject(element);
                listResults.Add(membresia);
            }
            return listResults;
        }
    }
}
