using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Transaccion
{
    public class TransaccionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_MOVIMIENTO = "MOVIMIENTO";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ID_TRABAJO = "ID_TRABAJO";
        private const string DB_COL_ID_MEMBRESIA = "ID_MEMBRESIA";
       

        //Se agregan todos los parametros || NO SP
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRANSACCION_INSERT_SP" };
            var transaccion = (Entities_POJO.Transaccion)entity;

            operation.AddDecimalParam(DB_COL_MONTO, transaccion.Monto);
            operation.AddNVarcharParam(DB_COL_MOVIMIENTO, transaccion.Movimiento);
            operation.AddDatetimeParam(DB_COL_FECHA, transaccion.Fecha);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, transaccion.ID_Usuario);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJO, transaccion.ID_Trabajo);
            operation.AddNVarcharParam(DB_COL_ID_MEMBRESIA, transaccion.ID_Membresia);

            return operation;
        }

        //Se agrega una transacion para un trabajo
        public SqlOperation GetCreateForTrabajoStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRANSACCION_INSERT_TRABAJO_SP" };
            var transaccion = (Entities_POJO.Transaccion)entity;

            operation.AddDecimalParam(DB_COL_MONTO, transaccion.Monto);
            operation.AddNVarcharParam(DB_COL_MOVIMIENTO, transaccion.Movimiento);
            operation.AddDatetimeParam(DB_COL_FECHA, transaccion.Fecha);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, transaccion.ID_Usuario);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJO, transaccion.ID_Trabajo);

            return operation;
        }

        //Se agrega una transacion para una membresia
        public SqlOperation GetCreateForMembresiaStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRANSACCION_INSERT_MEMBRESIA_SP" };
            var transaccion = (Entities_POJO.Transaccion)entity;

            operation.AddDecimalParam(DB_COL_MONTO, transaccion.Monto);
            operation.AddNVarcharParam(DB_COL_MOVIMIENTO, transaccion.Movimiento);
            operation.AddDatetimeParam(DB_COL_FECHA, transaccion.Fecha);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, transaccion.ID_Usuario);
            operation.AddNVarcharParam(DB_COL_ID_MEMBRESIA, transaccion.ID_Membresia);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRANSACCION_DELETE_SP" };
            var transaccion = (Entities_POJO.Transaccion)entity;

            operation.AddIntParam(DB_COL_ID, transaccion.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRANSACCION_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRANSACCION_SELECT_ID_SP" };
            var transaccion = (Entities_POJO.Transaccion)entity;

            operation.AddIntParam(DB_COL_ID, transaccion.ID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_TRANSACCION_UPDATE_SP" };
            var transaccion = (Entities_POJO.Transaccion)entity;

            operation.AddIntParam(DB_COL_MONTO, transaccion.ID);
            operation.AddDecimalParam(DB_COL_MONTO, transaccion.Monto);
            operation.AddNVarcharParam(DB_COL_MOVIMIENTO, transaccion.Movimiento);
            operation.AddDatetimeParam(DB_COL_FECHA, transaccion.Fecha);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, transaccion.ID_Usuario);
            operation.AddNVarcharParam(DB_COL_ID_TRABAJO, transaccion.ID_Trabajo);
            operation.AddNVarcharParam(DB_COL_ID_MEMBRESIA, transaccion.ID_Membresia);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            Entities_POJO.Transaccion transaccion = new Entities_POJO.Transaccion();
            if (row.ContainsKey(DB_COL_ID_TRABAJO))
            {
                transaccion = new Entities_POJO.Transaccion()
                {
                    ID = GetIntValue(row, DB_COL_ID),
                    Monto = GetDecimalValue(row, DB_COL_MONTO),
                    Movimiento = GetStringValue(row, DB_COL_MOVIMIENTO),
                    Fecha = GetDateValue(row, DB_COL_FECHA),
                    ID_Usuario = GetStringValue(row, DB_COL_ID_USUARIO),
                    ID_Trabajo = GetStringValue(row, DB_COL_ID_TRABAJO)
                };
            }
            else
            {
                transaccion = new Entities_POJO.Transaccion()
                {
                    ID = GetIntValue(row, DB_COL_ID),
                    Monto = GetDecimalValue(row, DB_COL_MONTO),
                    Movimiento = GetStringValue(row, DB_COL_MOVIMIENTO),
                    Fecha = GetDateValue(row, DB_COL_FECHA),
                    ID_Usuario = GetStringValue(row, DB_COL_ID_USUARIO),
                    ID_Membresia = GetStringValue(row, DB_COL_ID_MEMBRESIA)
                };
            }
            

            return transaccion;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var transaccion = BuildObject(element);
                listResults.Add(transaccion);
            }
            return listResults;
        }
    }
}
