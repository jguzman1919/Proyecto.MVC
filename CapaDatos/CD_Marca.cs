using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Marca
    {
        public List<Marca> Listar()
        {
            List<Marca> Lista = new List<Marca>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select IdMarca,Descripcion,Activo From Marca";

                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Marca()

                            {

                                IdMarca = Convert.ToInt32(dr["IdMarca"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Activo = Convert.ToBoolean(dr["Activo"]),

                            });

                              
                        }
                    }
                }
            }
            catch
            {
                Lista = new List<Marca>();

            }

            return Lista;
        }
        public int Registrar(Marca obj, out string mensaje)
        {
            int idautoenrolado = 0;
            mensaje = string.Empty;
            try
            {

                using (SqlConnection oConnexion = new SqlConnection(Conexion.cn))

                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarMarca", oConnexion);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnexion.Open();

                    cmd.ExecuteNonQuery();

                    idautoenrolado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautoenrolado = 0;
                mensaje = ex.Message;
            }

            return idautoenrolado;
        }
        public bool Editar(Marca obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))

                {
                    SqlCommand cmd = new SqlCommand("sp_EditarMarca", oConexion);
                    cmd.Parameters.AddWithValue("IdMarca", obj.IdMarca);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }

            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }

            return resultado;
        }
        public bool Eliminar(int Id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))

                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarMarca", oConexion);
                    cmd.Parameters.AddWithValue("IdMarca", Id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }

            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }

            return resultado;
        }
    }
}
