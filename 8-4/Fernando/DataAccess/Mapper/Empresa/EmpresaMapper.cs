using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using Entities_POJO;

namespace DataAccess.Mapper.Empresa
{
    public class EmpresaMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_CEDULA = "CEDULA";
        private const string DB_COL_RAZON_SOCIAL = "RAZON_SOCIAL";
        private const string DB_COL_NOMBRE_COMERCIAL = "NOMBRE_COMERCIAL";
        private const string DB_COL_FECHA_CREACION = "FECHA_CREACION";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_DIRECCION = "DIRECCION";
        private const string DB_COL_LONGITUD = "LONGITUD";
        private const string DB_COL_LATITUD = "LATITUD";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_TIPO_MEMBRESIA = "TIPO_MEMBRESIA";
        private const string DB_COL_FECHA_INGRESO = "FECHA_INGRESO";
        private const string DB_COL_ID_REPRESENTANTE = "ID_REPRESENTANTE";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_EMPRESA_CREATE_EMPRESA_SP" };

            var c = (Entities_POJO.Empresa)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA, c.Cedula);
            operation.AddNVarcharParam(DB_COL_RAZON_SOCIAL, c.RazonSocial != null ? c.RazonSocial :"");
            operation.AddNVarcharParam(DB_COL_NOMBRE_COMERCIAL, c.NombreComercial);
            operation.AddDatetimeParam(DB_COL_FECHA_CREACION, c.FechaCreacion);
            operation.AddNVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddNVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddNVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddNVarcharParam(DB_COL_DIRECCION, c.Direccion);
            operation.AddNVarcharParam(DB_COL_LONGITUD, c.Longitud);
            operation.AddNVarcharParam(DB_COL_LATITUD, c.Latitud);
            operation.AddNVarcharParam(DB_COL_TIPO, c.Tipo != null? c.Tipo: "" );
            operation.AddNVarcharParam(DB_COL_TIPO_MEMBRESIA, c.TipoMembresia);
            operation.AddDatetimeParam(DB_COL_FECHA_INGRESO, c.FechaIngreso);
            operation.AddNVarcharParam(DB_COL_ID_REPRESENTANTE, c.IdRepresentante);

            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_EMPRESA_RETRIEVE_EMPRESA_ID_SP" };

            var c = (Entities_POJO.Empresa)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA, c.Cedula);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "TBL_EMPRESA_RETRIEVE_ALL_EMPRESA_SP" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_EMPRESA_UPDATE_EMPRESA_SP" };

            var c = (Entities_POJO.Empresa)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA, c.Cedula);
            operation.AddNVarcharParam(DB_COL_RAZON_SOCIAL, c.RazonSocial);
            operation.AddNVarcharParam(DB_COL_NOMBRE_COMERCIAL, c.NombreComercial);
            operation.AddDatetimeParam(DB_COL_FECHA_CREACION, c.FechaCreacion);
            operation.AddNVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddNVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddNVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddNVarcharParam(DB_COL_DIRECCION, c.Direccion);
            operation.AddNVarcharParam(DB_COL_LONGITUD, c.Longitud);
            operation.AddNVarcharParam(DB_COL_LATITUD, c.Latitud);
            operation.AddNVarcharParam(DB_COL_TIPO, c.Tipo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "TBL_EMPRESA_DELETE_EMPRESA_SP" };

            var c = (Entities_POJO.Empresa)entity;
            operation.AddNVarcharParam(DB_COL_CEDULA, c.Cedula);
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
            var customer = new Entities_POJO.Empresa
            {
                Cedula = GetStringValue(row, DB_COL_CEDULA),
                RazonSocial = GetStringValue(row, DB_COL_RAZON_SOCIAL),
                NombreComercial = GetStringValue(row, DB_COL_NOMBRE_COMERCIAL),
                FechaCreacion = GetDateValue(row, DB_COL_FECHA_CREACION),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                Direccion = GetStringValue(row, DB_COL_DIRECCION),
                Longitud = GetStringValue(row, DB_COL_LONGITUD),
                Latitud = GetStringValue(row, DB_COL_LATITUD),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                TipoMembresia = GetStringValue(row, DB_COL_TIPO_MEMBRESIA),
                FechaIngreso = GetDateValue(row, DB_COL_FECHA_INGRESO),
                IdRepresentante = GetStringValue(row, DB_COL_ID_REPRESENTANTE)
            };

            return customer;
        }
    }
}
