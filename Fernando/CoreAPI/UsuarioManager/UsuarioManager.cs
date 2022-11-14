using System;
using System.Collections.Generic;
using System.Text;
using CoreAPI.AppCode.Helper;
using DataAccess.Crud.Empresa;
using DataAccess.Crud.Usuario;
using DataAccess.Crud.UsuarioRol;
using Entities_POJO;
using Excepciones;

namespace CoreAPI.User
{
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudFactory;

        public UsuarioManager()
        {
            crudFactory = new UsuarioCrudFactory();
        }

        public void Create(Usuario entity)
        {
            try
            {
                var c = crudFactory.Retrieve<Usuario>(entity);

                if (c != null)
                {
                    //Customer already exist
                    throw new BusinessException("2");
                }
                c = crudFactory.RetrieveByEmail<Usuario>(entity);
                if (c != null)
                {
                    throw new BusinessException("3");
                }

                entity.CodigoVerificacion = CodigoHelper.GenerarCodigo(2, 2, 3, 1);
                entity.EstadoChatbot = Estado.DES;
                entity.Estado = Estado.DES;

                crudFactory.Create(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void CreateOferenteFisico(Empresa empresa, Usuario entity)
        {
            try
            {
                var empresaCrudFactory = new EmpresaCrudFactory();
                var usuarioRolCrudFactory = new UsuarioRolCrudFactory();

                var c = crudFactory.Retrieve<Usuario>(entity);
                var emp = empresaCrudFactory.Retrieve<Empresa>(empresa);
                var rol = ObtenerRol(empresa.Tipo);
                var rolUsuario = ObtenerUsuarioRol(entity, rol);
                rolUsuario = usuarioRolCrudFactory.Retrieve<UsuarioRol>(rolUsuario);
                var createUser = true;

                if (c != null)
                {
                    createUser = false;
                    if (entity.Email != c.Email && entity.Telefono != c.Telefono)
                    {
                        throw new BusinessException("2");
                    }
                }

                if (emp != null)
                {
                    throw new BusinessException("2");
                }

                if (rolUsuario != null)
                {
                    throw new BusinessException("2");
                }

                if (empresa.Tipo != "Oferente Físico")
                {
                    empresa.Tipo = "Oferente Físico";
                }

                entity.CodigoVerificacion = CodigoHelper.GenerarCodigo(2, 2, 3, 1);
                entity.EstadoChatbot = Estado.DES;
                entity.Estado = Estado.DES;
                empresa.FechaIngreso = DateTime.Now;
                empresaCrudFactory.Create(empresa);
                entity.IdEmpresa = empresa.Cedula;
                if (createUser)
                {
                    crudFactory.Create(entity);
                }
                AgregarRolUsuario(entity, rol);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void CreateOferenteJuridico(Empresa empresa, Usuario entity)
        {
            try
            {
                var empresaCrudFactory = new EmpresaCrudFactory();
                var usuarioRolCrudFactory = new UsuarioRolCrudFactory();

                var c = crudFactory.Retrieve<Usuario>(entity);
                var emp = empresaCrudFactory.Retrieve<Empresa>(empresa);
                var rol = ObtenerRol(empresa.Tipo);
                var rolUsuario = ObtenerUsuarioRol(entity, rol);
                rolUsuario = usuarioRolCrudFactory.Retrieve<UsuarioRol>(rolUsuario);
                var createUser = true;

                if (c != null)
                {
                    createUser = false;
                    if (entity.Email != c.Email && entity.Telefono != c.Telefono)
                    {
                        throw new BusinessException("2");
                    }
                }

                if (emp != null)
                {
                    throw new BusinessException("2");
                }

                if (rolUsuario != null)
                {
                    throw new BusinessException("2");
                }

                if (empresa.Tipo != "Oferente Jurídico")
                {
                    empresa.Tipo = "Oferente Jurídico";
                }

                entity.CodigoVerificacion = CodigoHelper.GenerarCodigo(2, 2, 3, 1);
                entity.EstadoChatbot = Estado.DES;
                entity.Estado = Estado.DES;
                empresa.FechaIngreso = DateTime.Now;
                empresaCrudFactory.Create(empresa);
                entity.IdEmpresa = empresa.Cedula;
                if (createUser)
                {
                    crudFactory.Create(entity);
                }
                AgregarRolUsuario(entity, rol);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public IList<Usuario> RetrieveAll()
        {
            var entities = new List<Usuario>();
            try
            {
                entities =  crudFactory.RetrieveAll<Usuario>();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return entities;
        }

        public Usuario RetrieveById(Usuario entity)
        {
            Usuario c = null;
            try
            {
                c = crudFactory.Retrieve<Usuario>(entity);
                if (c == null)
                {
                    throw new BusinessException("ElUsuarioNoExiste");
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public Usuario RetrieveByEmail(Usuario entity)
        {
            Usuario c = null;
            try
            {
                c = crudFactory.RetrieveByEmail<Usuario>(entity);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        private Rol ObtenerRol(string rolName)
        {
            var rolManager = new RolManager.RolManager();
            var rol = rolManager.RetrieveByName(new Rol() { Nombre = rolName });
            return rol;
        }

        private UsuarioRol ObtenerUsuarioRol(Usuario usuario, Rol rol)
        {
            var usuarioRol = new UsuarioRol()
            {
                IdRol = rol.Id,
                IdUsuario = usuario.Identificacion
            };
            return usuarioRol;
        }

        private void AgregarRolUsuario(Usuario entity, Rol rol)
        {
            var userRolManager = new UsuarioRolManager.UsuarioRolManager();
            var usuarioRol = ObtenerUsuarioRol(entity, rol);
            userRolManager.Create(usuarioRol);
        }

        public void Update(Usuario entity)
        {

        }

        public void Delete(Usuario entity)
        {

        }
    }
}
