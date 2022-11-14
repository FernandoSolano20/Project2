using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.Contrasenna
{
    public class ContrasennaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_CONTRASENNA = "CONTRASENNA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ESTADO = "ESTADO";
        

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_CONTRASENNA_CREATE_CONTRASENNA_SP" };

            var c = (Entities_POJO.Contrasenna)entity;
            operation.AddNVarcharParam(DB_COL_CONTRASENNA, c.Password);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_CONTRASENNA_RETRIEVE_CONTRASENNA_SP" };

            var c = (Entities_POJO.Contrasenna)entity;
            operation.AddNVarcharParam(DB_COL_CONTRASENNA, c.Password);
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveStatementById(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_CONTRASENNA_RETRIEVE_CONTRASENNA_ID_SP" };

            var c = (Entities_POJO.Contrasenna)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveStatementByIdUserActive(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_CONTRASENNA_RETRIEVE_CONTRASENNA_ID_USER_ACTIVE_SP" };

            var c = (Entities_POJO.Contrasenna)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddNVarcharParam(DB_COL_CONTRASENNA, c.Password);

            return operation;
        }

        public SqlOperation GetRetriveStatementByIdUser(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_CONTRASENNA_RETRIEVE_CONTRASENNA_ID_USER_SP" };

            var c = (Entities_POJO.Contrasenna)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateEstatusStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_CONTRASENNA_UPDATE_ESTADO_SP" };

            var c = (Entities_POJO.Contrasenna)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_CONTRASENNA_DELETE_CONTRASENNA_SP" };

            var c = (Entities_POJO.Contrasenna)entity;
            operation.AddIntParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var customer = BuildObject(row);
                lstResults.Add(customer);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var customer = new Entities_POJO.Contrasenna
            {
                Id = GetIntValue(row, DB_COL_ID),
                Password = GetStringValue(row, DB_COL_CONTRASENNA),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };

            return customer;
        }
    }
}
