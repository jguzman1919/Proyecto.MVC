using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;



namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> Listar()
        {
            List<Producto> Lista = new List<Producto>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {

                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select p.Idproducto,p.Nombre,p.Descripcion,");
                    sb.AppendLine("m.IdMarca,m.Descripcion[DesMarca],");
                    sb.AppendLine("c.IdCategoria,c.Descripcion[DesCategoria],");
                    sb.AppendLine("p.Precio,p.Stock,p.RutaImagen,p.NombreImagen,p.Activo");
                    sb.AppendLine("from PRODUCTO p");
                    sb.AppendLine(" inner join MARCA m on m. IdMarca = p.IdMarca");
                    sb.AppendLine("inner join Categoria c on c. IdCategoria = p.IdCategoria");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Producto()
                            {                            
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oMarca = new Marca() { IdMarca = Convert.ToInt32(dr["IdMarca"]), Descripcion = dr["DesMarca"].ToString() },
                                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]), Descripcion = dr["DesCategoria"].ToString() },
                                Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-RD")),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                RutaImagen = dr["RutaImagen"].ToString(),
                                NombreImagen = dr["NombreImagen"].ToString(),
                                //Activo = Convert.ToBoolean(dr["Activo"])
                            });
                        }
                    }
                }
            }
            catch
            {
                Lista = new List<Producto>();

            }
            return Lista;
        }
        public int Registrar(Producto obj, out string mensaje)
        {
            int idautoenrolado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oConexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

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
        public bool Editar(Producto obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))

                {
                    SqlCommand cmd = new SqlCommand("sp_EditarProducto", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("IdMarca", obj.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("IdCategoria", obj.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Precio", obj.Precio);
                    cmd.Parameters.AddWithValue("Stock", obj.Stock);
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
        public bool GuardarDatosImagen(Producto obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    string query = "update producto set RutaImagen = @rutaimagen, NombreImagen = @nombreimagen where Idproducto = @idproducto";

                    SqlCommand cmd = new SqlCommand(query, oConexion);                  
                    cmd.Parameters.AddWithValue("@rutaimagen", obj.RutaImagen);
                    cmd.Parameters.AddWithValue("@nombreimagen", obj.NombreImagen);
                    cmd.Parameters.AddWithValue("@idproducto", obj.IdProducto);                   
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        resultado = true;
                    }
                    else
                    {
                        mensaje = "No se pudo actualizar la imagen";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return (resultado);
        }




        public bool Eliminar(int Id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))

                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarProducto", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", Id);
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





