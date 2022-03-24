using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.IRepositorios;

namespace Infrastructure
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly string _connectionString;
        public RepositorioUsuarios(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Usuario> ConsultarUsuarios()
        {
            var data = new List<Usuario>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"SELECT users.Id,users.UserName,users.Email,rolesName.Name
                                        FROM [dbo].[AspNetUsers] users full outer join AspNetUserRoles roles
                                        on users.Id = roles.UserId left join AspNetRoles rolesName on roles.RoleId = rolesName.Id", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new Usuario
                    {
                        Id = (string)dr["Id"],
                        UserName = (string)dr["UserName"],
                        Email = (string)dr["Email"],
                        NameRol = dr.IsDBNull(3) ? "No asignado" : (string)dr["Name"]
                    });
                }
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public UsuarioInfo ConsultarDetalleUsuario(string nombreUsuario)
        {

            var data = new UsuarioInfo();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"select top 1 us.*, rolesName.Name from UsuariosInfor us full outer join EstadoCivil es on us.id_EstadoCivil = es.idEstadoC
                                        full outer join [dbo].[AspNetUsers] users on users.UserName = us.usuario  full outer join AspNetUserRoles roles
                                        on users.Id = roles.UserId full outer join AspNetRoles rolesName on roles.RoleId = rolesName.Id where users.UserName = @user;", con);
            cmd.Parameters.Add("user", SqlDbType.VarChar).Value = nombreUsuario;
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = UsuarioInfo.Create((Guid)dr["Id"], (string)dr["usuario"],
                        (string)dr["correo"], (string)dr["direccion"], (int)dr["edad"],
                        (string)dr["numCelular"], (string)dr["Name"], (string)dr["foto"],
                        (string)dr["numDomicilio"], (Guid)dr["id_EstadoCivil"], (string)dr["nombre"], (string)dr["apellidoP"],
                        (string)dr["apellidoM"], (string)dr["sexo"]);
                }
                return data;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ActualizarUsuario(UsuarioInfo usuarioInfo, string nombreUsuario)
        {
            var res = 0;
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"UPDATE [dbo].[UsuariosInfor]
                                   SET 
                                      [correo] = @correo
                                      ,[direccion] = @direccion
                                      ,[edad] = @edad
                                      ,[numCelular] = @numCelular
                                      ,[foto] = @foto
                                      ,[numDomicilio] = @numDomicilio
                                      ,[id_EstadoCivil] = @idEstado
                                      ,[sexo] = @sexo
                                 WHERE usuario = @usuario", con);
            cmd.Parameters.Add("usuario", SqlDbType.VarChar).Value = nombreUsuario;
            cmd.Parameters.Add("correo", SqlDbType.VarChar).Value = usuarioInfo.Correo;
            cmd.Parameters.Add("direccion", SqlDbType.VarChar).Value = usuarioInfo.Direccion;
            cmd.Parameters.Add("edad", SqlDbType.Int).Value = usuarioInfo.Edad;
            cmd.Parameters.Add("numCelular", SqlDbType.VarChar).Value = usuarioInfo.NumCelular;
            cmd.Parameters.Add("foto", SqlDbType.VarChar).Value = usuarioInfo.FotoT;

            cmd.Parameters.Add("numDomicilio", SqlDbType.VarChar).Value = usuarioInfo.NumDomicilio;
            cmd.Parameters.Add("idEstado", SqlDbType.UniqueIdentifier).Value = usuarioInfo.Id_EstadoCivil;
            cmd.Parameters.Add("sexo", SqlDbType.VarChar).Value = usuarioInfo.Sexo;


            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
                res = 0;
            }
            finally
            {
                con.Close();
            }
            return res > 0;
        }

        public bool ActualizarRolDeUsuario(string nombreUsuario, string rol)
        {
            var res = 0;
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"EXECUTE CambiarRol @rol,@usuario", con);
            cmd.Parameters.Add("usuario", SqlDbType.VarChar).Value = nombreUsuario;
            cmd.Parameters.Add("rol", SqlDbType.VarChar).Value = rol;

            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return res > 0;
        }

    }
}
