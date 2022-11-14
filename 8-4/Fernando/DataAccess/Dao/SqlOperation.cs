using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        public void AddNVarcharParam(string paramName, string paramValue)
        {
            if (!string.IsNullOrEmpty(paramValue))
            {
                var param = new SqlParameter("@P_" + paramName, SqlDbType.NVarChar)
                {
                    Value = paramValue
                };
                Parameters.Add(param);
            }
            else
            {
                var param = new SqlParameter("@P_" + paramName, DBNull.Value);
                Parameters.Add(param);
            }
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            if (!paramValue.Equals(null))
            {
                var param = new SqlParameter("@P_" + paramName, SqlDbType.Int)
                {
                    Value = paramValue
                };
                Parameters.Add(param);
            }
            else
            {
                var param = new SqlParameter("@P_" + paramName, DBNull.Value);
                Parameters.Add(param);
            }
        }

        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            if (!paramValue.Equals(null))
            {
                var param = new SqlParameter("@P_" + paramName, SqlDbType.Decimal)
                {
                    Value = paramValue
                };
                Parameters.Add(param);
            }
            else
            {
                var param = new SqlParameter("@P_" + paramName, DBNull.Value);
                Parameters.Add(param);
            }
        }

        public void AddDatetimeParam(string paramName, DateTime paramValue)
        {
            if (paramValue.Year > 1907)
            {
                var param = new SqlParameter("@P_" + paramName, SqlDbType.DateTime)
                {
                    Value = paramValue
                };
                Parameters.Add(param);
            }
            else
            {
                var param = new SqlParameter("@P_" + paramName, DBNull.Value);
                Parameters.Add(param);
            }
        }
    }
}
