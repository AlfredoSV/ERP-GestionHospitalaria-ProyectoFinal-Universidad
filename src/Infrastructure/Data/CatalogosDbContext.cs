using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class CatalogosDbContext
    {
        private readonly string _connectionString;

        public CatalogosDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<CatalogoEstatusCitas> ListCatEst()
        {
            var data = new List<CatalogoEstatusCitas>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"select idEstatus,nombre_estatus,descripcion from EstatusCita", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new CatalogoEstatusCitas
                    {
                        IdEstatus = (Guid)dr["idEstatus"],
                        Nombre_Estatus = dr["nombre_estatus"].ToString(),
                        Descripcion = dr["descripcion"].ToString()

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

        public List<CatalogoAreasMedicas> ListCatMed()
        {
            var data = new List<CatalogoAreasMedicas>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"SELECT idArea,nombre_area,descripcion_area FROM AreaMedica", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new CatalogoAreasMedicas
                    {
                        Id_Area = (Guid)dr["idArea"],
                        Nombre_Area = dr["nombre_area"].ToString(),
                        Descripcion_Area = dr["descripcion_area"].ToString()

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

        public List<CatalogoEstadoCivil> ListCatEstadoCivil()
        {
            var data = new List<CatalogoEstadoCivil>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"SELECT * FROM EstadoCivil", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new CatalogoEstadoCivil
                    {
                        IdEstado = (Guid)dr["idEstadoC"],
                        Nombre_Estado = dr["nombre_EstadoC"].ToString()

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

        public List<CatalogoTiposSagre> ListCatTiposSangre()
        {
            var data = new List<CatalogoTiposSagre>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"SELECT * FROM TipoSangre", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new CatalogoTiposSagre
                    {
                        IdTipo = (Guid)dr["idTipo"],
                        nombre_Tipo = dr["nombre_Tipo"].ToString()

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

        public List<CatalogoProfesiones> ListCatProfesion()
        {
            var data = new List<CatalogoProfesiones>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"SELECT * FROM Profesion", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new CatalogoProfesiones
                    {
                        IdProfesion = (Guid)dr["idProfesion"],
                        Nombre_profesion = dr["nombre_Profesion"].ToString()

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

        public List<CatalogoTipoProducto> ListCatTipoProductos()
        {
            var data = new List<CatalogoTipoProducto>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"select * from TipoProducto;", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new CatalogoTipoProducto
                    {
                        IdTipo = (Guid)dr["idTipo"],
                        Nombre = dr["nombre"].ToString()

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

    }
}
