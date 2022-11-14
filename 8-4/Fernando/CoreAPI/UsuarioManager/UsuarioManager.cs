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
                entity.Estado = Estado.NOAPROVADO;
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
                entity.Estado = Estado.NOAPROVADO;
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

        public IList<Usuario> RetrievePendingOferentes()
        {
            var entities = new List<Usuario>();
            try
            {
                entities = crudFactory.RetrieveByEstado<Usuario>(new Usuario()
                {
                    Estado = Estado.NOAPROVADO
                });
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

        public void RecuperarClave(Usuario entity)
        {
            Usuario c = null;
            try
            {

                if (entity.Estado == Estado.NOPAGOYCAMBIARCONTRASENNA || entity.Estado == Estado.NOPAGO)
                {
                    entity.Estado = Estado.DESYNOPAGO;
                }
                else
                {
                    entity.Estado = Estado.DES;
                }
                entity.CodigoVerificacion = CodigoHelper.GenerarCodigo(2, 2, 3, 1);
                crudFactory.UpdateCodigo(entity);
                EmailHelper.Execute(entity.Email, 
                    entity.Nombre + " " + entity.PrimerApellido, 
                    "Recuperacion de cuenta",
                    EmailHelper.AcessoPlataforma(entity)).Wait();
                TwilioHelper.SendMessage(entity.Telefono,entity.CodigoVerificacion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<BaseEntity> IniciarSesion(string email, string contrasenna)
        {
            var entities = new List<BaseEntity>();
            Usuario usuario = null;
            try
            {
                usuario = crudFactory.RetrieveByEmail<Usuario>(new Usuario()
                {
                    Email = email
                });

                if (usuario == null)
                {
                    throw new BusinessException("Erroraliniciarsesion");
                }

                if (usuario.IntentosContrasenna < 3)
                {
                    usuario.IntentosContrasenna++;
                    if (usuario.Estado == Estado.DES || usuario.Estado == Estado.DESYNOPAGO)
                    {
                        if (usuario.CodigoVerificacion == contrasenna)
                        {
                            if (usuario.Estado == Estado.DESYNOPAGO)
                            {
                                usuario.Estado = Estado.NOPAGOYCAMBIARCONTRASENNA;
                            }
                            else
                            {
                                usuario.Estado = Estado.CAMBIARCONTRASENNA;
                            }
                            usuario.IntentosContrasenna = 0;
                        }
                        else
                        {
                            crudFactory.UpdateIntentos(usuario);
                            throw new BusinessException("Error al iniciar sesión");
                        }
                    }
                    else if (usuario.Estado != Estado.NOAPROVADO)
                    {
                        contrasenna = contrasenna.md5();
                        var managerContra = new ContrasennaManager.ContrasennaManager();
                        var pass = managerContra.RetrieveByIdUserActive(new Contrasenna()
                        {
                            IdUsuario = usuario.Identificacion,
                            Password = contrasenna
                        });

                        if (pass != null)
                        {
                            usuario.IntentosContrasenna = 0;
                            if (pass.Fecha.MonthDifference() == 3)
                            {
                                usuario.Estado = Estado.CAMBIARCONTRASENNA;
                            }
                        }
                        else
                        {
                            crudFactory.UpdateIntentos(usuario);
                            throw new BusinessException("Error al iniciar sesión");
                        }

                        if (!string.IsNullOrEmpty(usuario.IdEmpresa))
                        {
                            var empresaManager = new EmpresaManager.EmpresaManager();
                            var membresiaManager = new MembresiaManager.MembresiaManager();
                            var membresia =  membresiaManager.RetrievePerDate(new Membresia()
                            {
                                ID_Representante = usuario.Identificacion
                            });

                            if (DateTime.Now > membresia.Fecha.AddDays(365))
                            {
                                if (usuario.Estado == Estado.CAMBIARCONTRASENNA)
                                {
                                    usuario.Estado = Estado.NOPAGOYCAMBIARCONTRASENNA;
                                }
                                else
                                {
                                    usuario.Estado = Estado.NOPAGO;
                                }
                                usuario.IntentosContrasenna = 0;
                            }
                        }

                        if (usuario.IntentosContrasenna >= 3)
                        {
                            usuario.IntentosContrasenna = 3;
                            if (usuario.Estado == Estado.NOPAGOYCAMBIARCONTRASENNA || usuario.Estado == Estado.NOPAGO)
                            {
                                usuario.Estado = Estado.DESYNOPAGO;
                            }
                            else
                            {
                                usuario.Estado = Estado.DES;
                            }
                            
                            UpdateEstado(usuario);
                            crudFactory.UpdateIntentos(usuario);
                            throw new BusinessException("UsuarioDesactivado");
                        }
                    }
                    else
                    {
                        throw new BusinessException("Contacte al aadmin");
                    }
                }
                else
                {
                    throw new BusinessException("UsuarioDesactivado");
                }
                UpdateEstado(usuario);
                crudFactory.UpdateIntentos(usuario);
                var rolesManager = new UsuarioRolManager.UsuarioRolManager();
                var roles = rolesManager.RetrieveRolIdByUser(usuario);
                entities.Add(usuario);
                foreach (var role in roles)
                {
                    entities.Add(role);    
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return entities;
        }

        private void UpdateEstado(Usuario usuario)
        {
            try
            {
                crudFactory.UpdateEstado(usuario);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
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

        public void CambiarEstado(Usuario entity)
        {
            try
            {

                var usuario = crudFactory.Retrieve<Usuario>(entity);

                if (usuario == null)
                {
                    throw new BusinessException("No se encuentra usuario");
                }

                usuario.Estado = entity.Estado;
                UpdateEstado(usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void Aceptar(Usuario entity)
        {
            try
            {
                entity.Estado = Estado.DESYNOPAGO;
                CambiarEstado(entity);
                EmailHelper.Execute(entity.Email, entity.Nombre + " " + entity.PrimerApellido, "Acceso Plataforma",
                    EmailHelper.AcessoPlataforma(entity)).Wait();
                TwilioHelper.SendMessage(entity.Telefono, entity.CodigoVerificacion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public void DeleteLogic(Usuario entity)
        {
            try
            {

                var usuario = crudFactory.Retrieve<Usuario>(entity);

                if (usuario == null)
                {
                    throw new BusinessException("No se encuentra usuario");
                }

                usuario.Estado = Estado.BORRADO;
                crudFactory.UpdateEstado(usuario);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }
    }
}
