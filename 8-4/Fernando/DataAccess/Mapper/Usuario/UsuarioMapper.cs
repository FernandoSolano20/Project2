using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.Usuario
{
    public class UsuarioMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_IDENTIFICACION = "IDENTIFICACION";
        private const string DB_COL_TIPO_IDENTIFICACION = "TIPO_IDENTIFICACION";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_PRIMER_APELLIDO = "PRIMER_APELLIDO";
        private const string DB_COL_SEGUNDO_APELLIDO = "SEGUNDO_APELLIDO";
        private const string DB_COL_GENERO = "GENERO";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_DIRECCION = "DIRECCION";
        private const string DB_COL_LONGITUD = "LONGITUD";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_PAIS_NACIMIENTO = "PAIS_NACIMIENTO";
        private const string DB_COL_FECHA_NACIMIENTO = "FECHA_NACIMIENTO";
        private const string DB_COL_TELEFONO = "TELEFONO";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_CODIGO_VERIFICACION = "CODIGO_VERIFICACION";
        private const string DB_COL_INTENTOS_CONTRASENNA = "INTENTOS_CONTRASENNA";
        private const string DB_COL_MONEDA = "MONEDA";
        private const string DB_COL_ESTADO_CHATBOT = "ESTADO_CHATBOT";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_LENGUAJE = "LENGUAJE";
        private const string DB_COL_ID_EMPRESA = "ID_EMPRESA";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_CRE_USER_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_IDENTIFICACION, c.Identificacion);
            operation.AddNVarcharParam(DB_COL_TIPO_IDENTIFICACION, c.TipoIdentificacion);
            operation.AddNVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddNVarcharParam(DB_COL_PRIMER_APELLIDO, c.PrimerApellido);
            operation.AddNVarcharParam(DB_COL_SEGUNDO_APELLIDO, c.SegundoApellido != null? c.SegundoApellido:"");
            operation.AddNVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddNVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddNVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddNVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddNVarcharParam(DB_COL_DIRECCION, c.Direccion);
            operation.AddNVarcharParam(DB_COL_LONGITUD, c.Longitud);
            operation.AddNVarcharParam(DB_COL_LATITUD, c.Latitud);
            operation.AddNVarcharParam(DB_COL_PAIS_NACIMIENTO, c.PaisNacimiento);
            operation.AddDatetimeParam(DB_COL_FECHA_NACIMIENTO, c.FechaNacimeinto);
            operation.AddNVarcharParam(DB_COL_TELEFONO, c.Telefono);
            operation.AddNVarcharParam(DB_COL_EMAIL, c.Email);
            operation.AddNVarcharParam(DB_COL_CODIGO_VERIFICACION, c.CodigoVerificacion);
            operation.AddIntParam(DB_COL_INTENTOS_CONTRASENNA, c.IntentosContrasenna);
            operation.AddNVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddNVarcharParam(DB_COL_ESTADO_CHATBOT, c.EstadoChatbot);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddNVarcharParam(DB_COL_LENGUAJE, c.Lenguaje);
            operation.AddNVarcharParam(DB_COL_ID_EMPRESA, c.IdEmpresa);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_RET_USER_ID_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_IDENTIFICACION, c.Identificacion);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_RET_ALL_USER_SP" };
            return operation;
        }

        public SqlOperation GetRetriveByEstado(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_RET_BY_ESTADO_SP" };
            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_UPD_USER_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_IDENTIFICACION, c.Identificacion);
            operation.AddNVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddNVarcharParam(DB_COL_PRIMER_APELLIDO, c.PrimerApellido);
            operation.AddNVarcharParam(DB_COL_SEGUNDO_APELLIDO, c.SegundoApellido);
            operation.AddNVarcharParam(DB_COL_GENERO, c.Genero);
            operation.AddNVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddNVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddNVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddNVarcharParam(DB_COL_DIRECCION, c.Direccion);
            operation.AddNVarcharParam(DB_COL_LONGITUD, c.Longitud);
            operation.AddNVarcharParam(DB_COL_LATITUD, c.Latitud);
            operation.AddNVarcharParam(DB_COL_PAIS_NACIMIENTO, c.PaisNacimiento);
            operation.AddDatetimeParam(DB_COL_FECHA_NACIMIENTO, c.FechaNacimeinto);
            operation.AddNVarcharParam(DB_COL_TELEFONO, c.Telefono);
            operation.AddNVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddNVarcharParam(DB_COL_LENGUAJE, c.Lenguaje);

            return operation;
        }

        public SqlOperation GetUpdateEstadoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_UPD_ESTADO_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_IDENTIFICACION, c.Identificacion);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);

            return operation;
        }

        public SqlOperation GetUpdateIntentosStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_UPD_INTENTOS_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_IDENTIFICACION, c.Identificacion);
            operation.AddIntParam(DB_COL_INTENTOS_CONTRASENNA, c.IntentosContrasenna);

            return operation;
        }

        public SqlOperation GetUpdateCodigoStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_UPD_CODIGO_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_IDENTIFICACION, c.Identificacion);
            operation.AddNVarcharParam(DB_COL_CODIGO_VERIFICACION, c.CodigoVerificacion);
            operation.AddNVarcharParam(DB_COL_ESTADO, c.Estado);   

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_DEL_USER_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_IDENTIFICACION, c.Identificacion);
            return operation;
        }

        public SqlOperation GetRetriveEmailStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_USUARIO_RET_USER_EMAIL_SP" };

            var c = (Entities_POJO.Usuario)entity;
            operation.AddNVarcharParam(DB_COL_EMAIL, c.Email);
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
            var customer = new Entities_POJO.Usuario
            {
                Identificacion = GetStringValue(row, DB_COL_IDENTIFICACION),
                IdEmpresa = GetStringValue(row, DB_COL_ID_EMPRESA),
                TipoIdentificacion = GetStringValue(row, DB_COL_TIPO_IDENTIFICACION),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                PrimerApellido = GetStringValue(row, DB_COL_PRIMER_APELLIDO),
                SegundoApellido = GetStringValue(row, DB_COL_SEGUNDO_APELLIDO),
                Genero = GetStringValue(row, DB_COL_GENERO),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                Direccion = GetStringValue(row, DB_COL_DIRECCION),
                Longitud = GetStringValue(row, DB_COL_LONGITUD),
                Latitud = GetStringValue(row, DB_COL_LATITUD),
                PaisNacimiento = GetStringValue(row, DB_COL_PAIS_NACIMIENTO),
                FechaNacimeinto = GetDateValue(row, DB_COL_FECHA_NACIMIENTO),
                Telefono = GetStringValue(row, DB_COL_TELEFONO),
                Email = GetStringValue(row, DB_COL_EMAIL),
                CodigoVerificacion = GetStringValue(row, DB_COL_CODIGO_VERIFICACION),
                IntentosContrasenna = GetIntValue(row, DB_COL_INTENTOS_CONTRASENNA),
                Moneda = GetStringValue(row, DB_COL_MONEDA),
                EstadoChatbot = GetStringValue(row, DB_COL_ESTADO_CHATBOT),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Lenguaje = GetStringValue(row, DB_COL_LENGUAJE),
            };

            return customer;
        }

    }
}
