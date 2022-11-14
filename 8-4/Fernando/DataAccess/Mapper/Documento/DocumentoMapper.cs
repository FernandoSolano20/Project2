using DataAccess.Dao;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Documento
{
    public class DocumentoMapper : EntityMapper, IObjectMapper, ISqlStaments
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_URL = "URL";
        private const string DB_COL_TITULO = "TITULO";
        private const string DB_COL_ID_PROPIETARIO = "ID_PROPIETARIO";
        private const string DB_COL_TIPO_DOCUMENTO = "TIPO_DOCUMENTO";
        private const string DB_COL_ESTADO = "ESTADO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_INSERT_SP" };
            var documento = (Entities_POJO.Documento)entity;

            operation.AddNVarcharParam(DB_COL_URL, documento.URL);
            operation.AddNVarcharParam(DB_COL_TITULO, documento.Titulo);
            operation.AddNVarcharParam(DB_COL_ID_PROPIETARIO, documento.ID_Propietario);
            operation.AddNVarcharParam(DB_COL_TIPO_DOCUMENTO, documento.TipoDocumento);
            operation.AddNVarcharParam(DB_COL_ESTADO, documento.Estado);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_DELETE_SP" };
            var documento = (Entities_POJO.Documento)entity;

            operation.AddIntParam(DB_COL_ID, documento.ID);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_SELECT_ALL_SP" };

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_SELECT_ID_SP" };
            var documento = (Entities_POJO.Documento)entity;
            operation.AddIntParam(DB_COL_ID, documento.ID);

            return operation;
        }

        public SqlOperation GetRetriveStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_SELECT_ESTADO_SP" };
            var documento = (Entities_POJO.Documento)entity;

            operation.AddNVarcharParam(DB_COL_ESTADO, documento.Estado);

            return operation;
        }

        public SqlOperation GetRetriveByUserIDStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_SELECT_ID_PROPIETARIO_SP" };
            var documento = (Entities_POJO.Documento)entity;

            operation.AddNVarcharParam(DB_COL_ID_PROPIETARIO, documento.ID_Propietario);
            operation.AddNVarcharParam(DB_COL_TIPO_DOCUMENTO, documento.TipoDocumento);

            return operation;
        }

        public SqlOperation GetUpdateStatusStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_UPDATE_ESTADO_SP" };
            var documento = (Entities_POJO.Documento)entity;

            operation.AddIntParam(DB_COL_ID, documento.ID);
            operation.AddNVarcharParam(DB_COL_ESTADO, documento.Estado);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            SqlOperation operation = new SqlOperation { ProcedureName = "TBL_DOCUMENTO_UPDATE_SP" };
            var documento = (Entities_POJO.Documento)entity;

            operation.AddIntParam(DB_COL_ID, documento.ID);
            operation.AddNVarcharParam(DB_COL_URL, documento.URL);
            operation.AddNVarcharParam(DB_COL_TITULO, documento.Titulo);

            return operation;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var documento = new Entities_POJO.Documento()
            {
                ID = GetIntValue(row, DB_COL_ID),
                URL = GetStringValue(row, DB_COL_URL),
                Titulo = GetStringValue(row, DB_COL_TITULO),
                ID_Propietario = GetStringValue(row, DB_COL_ID_PROPIETARIO),
                TipoDocumento = GetStringValue(row, DB_COL_TIPO_DOCUMENTO),
                Estado = GetStringValue(row, DB_COL_ESTADO)
            };

            return documento;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var listResults = new List<BaseEntity>();

            foreach (var element in lstRows)
            {
                var documento = BuildObject(element);
                listResults.Add(documento);
            }
            return listResults;
        }
    }
}
