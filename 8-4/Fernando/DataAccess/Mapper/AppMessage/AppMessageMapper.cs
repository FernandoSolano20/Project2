using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.AppMessage
{
    public class AppMessageMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_NAME_KEY = "NAME_KEY";
        private const string DB_COL_MENSAJE_INGLES = "MENSAJE_INGLES";
        private const string DB_COL_MENSAJE_ESPANOL = "MENSAJE_ESPANOL";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MESSAGE_PR" };
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

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var appMessage = BuildObject(row);
                lstResults.Add(appMessage);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var appMessage = new ApplicationMessage
            {
                Key = GetStringValue(row, DB_COL_NAME_KEY),
                MensajeIngles = GetStringValue(row, DB_COL_MENSAJE_INGLES),
                MensajeEspanol = GetStringValue(row, DB_COL_MENSAJE_ESPANOL)
            };

            return appMessage;
        }
    }
}
