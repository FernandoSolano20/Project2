﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Dao;
using DataAccess.Mapper.UsuarioRolMapper;
using Entities_POJO;

namespace DataAccess.Crud.UsuarioRol
{
    public class UsuarioRolCrudFactory : CrudFactory
    {
        UsuarioRolMapper mapper;
        public UsuarioRolCrudFactory() : base()
        {
            mapper = new UsuarioRolMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer = (Entities_POJO.UsuarioRol)entity;
            var sqlOperation = mapper.GetCreateStatement(customer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T RetrieveRolIdByUser<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveRolByUserIdStament(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public T RetrieveUsersByRol<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveUserByRolStament(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            var customer = (Entities_POJO.UsuarioRol)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(customer));
        }
    }
}
