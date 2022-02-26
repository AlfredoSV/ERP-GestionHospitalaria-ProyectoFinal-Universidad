using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain.IRepositorios;

namespace Infrastructure
{
    public class CitasDbContext : IRepositorioCitas
    {
        private readonly string _connectionString;

        public CitasDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Cita> ListarCitas()
        {
            var data = new List<Cita>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"select ci.id,pa.nombre,pa.id pacienteid, estci.nombre_estatus estatusnombre, am.nombre_area areaatencion,ci.fecha fechacita,ci.Observaciones observaciones from cita ci  inner join
                                        EstatusCita estci on ci.idEstatus = estci.idEstatus
                                        inner join Paciente pa on pa.Id = ci.PacienteId INNER JOIN AreaMedica am on ci.idArea = am.idArea
                                        where ci.idEstatus <> '5E84063D-A63D-4E28-8AAD-5196DA01D2D9' and ci.idEstatus <> '88B3CD53-4496-4185-85A6-5BDBBC5DE347';", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(Cita.Create(

                        (Guid)dr["Id"],
                        (Guid)dr["pacienteid"],
                        dr["nombre"].ToString(),
                        dr["estatusnombre"].ToString(),
                        dr["areaatencion"].ToString(),
                        Convert.ToDateTime(dr["fechacita"])
                        ,
                        dr["observaciones"].ToString()

                    ));
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

        public List<Cita> ListarCitasGraficas()
        {
            var data = new List<Cita>();

            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"select ci.id,pa.nombre,pa.id pacienteid, estci.nombre_estatus estatusnombre, am.nombre_area areaatencion,ci.fecha fechacita,ci.Observaciones observaciones from cita ci  inner join
                                        EstatusCita estci on ci.idEstatus = estci.idEstatus
                                        inner join Paciente pa on pa.Id = ci.PacienteId INNER JOIN AreaMedica am on ci.idArea = am.idArea;", con);
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(Cita.Create(

                        (Guid)dr["Id"],
                        (Guid)dr["pacienteid"],
                        dr["nombre"].ToString(),
                        dr["estatusnombre"].ToString(),
                        dr["areaatencion"].ToString(),
                        Convert.ToDateTime(dr["fechacita"])
                        ,
                        dr["observaciones"].ToString()

                    ));
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

        public Cita ConsultarDetalleCita(Guid id)
        {

            Cita data = null;
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"select ci.id,pa.nombre,pa.id pacienteid, estci.nombre_estatus estatusnombre, am.nombre_area areaatencion,ci.fecha fechacita,ci.Observaciones observaciones from cita ci  inner join
                                        EstatusCita estci on ci.idEstatus = estci.idEstatus
                                        inner join Paciente pa on pa.Id = ci.PacienteId INNER JOIN AreaMedica am on ci.idArea = am.idArea
                                        where ci.id = @id; ", con);
            cmd.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;
            try
            {
                con.Open();
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    data = Cita.Create(

                        (Guid)dr["Id"],
                        (Guid)dr["pacienteid"],
                        dr["nombre"].ToString(),
                        dr["estatusnombre"].ToString(),
                        dr["areaatencion"].ToString(),
                        Convert.ToDateTime(dr["fechacita"]),
                        dr["observaciones"].ToString()

                    );
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public bool CrearNuevaCita(Cita data)
        {
            var res = 0;
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("INSERT INTO [Cita] VALUES (@id,@pacienteId,@idestatus,@idarea,@fecha,@observaciones)", con);
            cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
            cmd.Parameters.Add("pacienteId", SqlDbType.UniqueIdentifier, 128).Value = data.PacienteId;
            cmd.Parameters.Add("idestatus", SqlDbType.UniqueIdentifier).Value = data.idEstaus;
            cmd.Parameters.Add("idarea", SqlDbType.UniqueIdentifier).Value = data.idArea;
            cmd.Parameters.Add("fecha", SqlDbType.DateTime).Value = data.Fecha;
            cmd.Parameters.Add("observaciones", SqlDbType.VarChar).Value = data.Observaciones;

            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                res = 0;
            }
            finally
            {
                con.Close();
            }
            return res > 0;
        }

        public bool EditarCita(Guid id, Cita data)
        {
            var res = 0;
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(@"UPDATE [dbo].[Cita] set                                    
                                    
                                    [idEstatus] = @idEstatus
                                    ,[idArea] = @idArea
                                    ,[Fecha] = @fecha
                                    ,[Observaciones] =@Observaciones where id = @id", con);

            cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
            cmd.Parameters.Add("idEstatus", SqlDbType.UniqueIdentifier).Value = data.idEstaus;
            cmd.Parameters.Add("fecha", SqlDbType.DateTime).Value = data.Fecha;
            cmd.Parameters.Add("idArea", SqlDbType.UniqueIdentifier).Value = data.idArea;
            cmd.Parameters.Add("Observaciones", SqlDbType.VarChar).Value = data.Observaciones;

            try
            {
                con.Open();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                res = 0;
            }
            finally
            {
                con.Close();
            }
            return res > 0;
        }


        public bool EliminarCita(Guid id)
        {
            var res = 0;
            var con = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("UPDATE CITA SET idEstatus = '88B3CD53-4496-4185-85A6-5BDBBC5DE347' where Id = @id", con);
            cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
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
