using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.UsuarioRolMapper
{
    public class UsuarioRolMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_USUARIO = "ID_USUARIO";
        private const string DB_COL_ID_ROL = "ID_ROL";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_ROL_CREATE_SP" };

            var c = (UsuarioRol)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_ROL_RETRIEVE_ID_SP" };

            var c = (UsuarioRol)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);

            return operation;
        }

        public SqlOperation GetRetriveRolByUserIdStament(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_ROL_RETRIEVE_BY_USUARIO_SP" };

            var c = (UsuarioRol)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);

            return operation;
        }

        public SqlOperation GetRetriveUserByRolStament(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_ROL_RETRIEVE_BY_ROL_SP" };

            var c = (UsuarioRol)entity;
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_ROL_ALL_RETRIEVE_SP" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_ROL_DELETE_SP" };

            var c = (UsuarioRol)entity;
            operation.AddNVarcharParam(DB_COL_ID_USUARIO, c.IdUsuario);
            operation.AddIntParam(DB_COL_ID_ROL, c.IdRol);

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
            var customer = new UsuarioRol
            {
                IdUsuario = GetStringValue(row, DB_COL_ID_USUARIO),
                IdRol = GetIntValue(row, DB_COL_ID_ROL)
            };

            return customer;
        }
    }
}
