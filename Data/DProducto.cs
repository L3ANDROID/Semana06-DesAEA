using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                comandText = "USP_GetProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto",SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();


                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, comandText,
                   CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            NombreProducto = reader["nombreproducto"] != null ? Convert.ToString(reader["nombreproducto"]) : string.Empty,
                            idProveedor = reader["idproveedor"] != null ? Convert.ToInt32(reader["idproveedor"]) : 0,
                            idCategoria = reader["idcategoria"] != null ? Convert.ToInt32(reader["idcategoria"]) : 0,
                            cantidadPorUnidad = reader["cantidadporunidad"] != null ? Convert.ToString(reader["cantidadporunidad"]) : string.Empty,
                            precioUnidadDecimal = reader["preciounidad"] != null ? Convert.ToDecimal(reader["preciounidad"]) : 0,
                            unidadesEnExistencia = reader["unidadesenexistencia"] !=null ? Convert.ToInt32(reader["unidadesenexistencia"]) : 0,
                            unidadesEnPedido = reader["unidadesenpedido"] !=null ? Convert.ToInt32(reader["unidadesenpedido"]) : 0,
                            nivelNuevoPedido = reader["nivelnuevopedido"] !=null ? Convert.ToInt32(reader["nivelnuevopedido"]) : 0,
                            Suspendido = reader["suspendido"] !=null ? Convert.ToInt32(reader["suspendido"]) : 0,
                            categoriaProducto = reader["categoriaproducto"] !=null ? Convert.ToString(reader["categoriaproducto"]) : string.Empty,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            return productos;
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;

            try
            {
                comandText = "USP_InsProducto";
                parameters = new SqlParameter[10];
                parameters[0] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@idproveedor", SqlDbType.Int);
                parameters[1].Value = producto.idProveedor;
                parameters[2] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[2].Value = producto.idCategoria;
                parameters[3] = new SqlParameter("@cantidadporunidad", SqlDbType.VarChar);
                parameters[3].Value = producto.cantidadPorUnidad;
                parameters[4] = new SqlParameter("@preciounidad", SqlDbType.Decimal);
                parameters[4].Value = producto.precioUnidadDecimal;
                parameters[5] = new SqlParameter("@unidadesenexistencia", SqlDbType.Int);
                parameters[5].Value = producto.unidadesEnExistencia;
                parameters[6] = new SqlParameter("@unidadesenpedido", SqlDbType.Int);
                parameters[6].Value = producto.unidadesEnPedido;
                parameters[7] = new SqlParameter("@nivelnuevopedido", SqlDbType.Int);
                parameters[7].Value = producto.nivelNuevoPedido;
                parameters[8] = new SqlParameter("@suspendido", SqlDbType.Int);
                parameters[8].Value = producto.Suspendido;
                parameters[9] = new SqlParameter("@categoriaproducto", SqlDbType.VarChar);
                parameters[9].Value = producto.categoriaProducto;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }

        }

        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;

            try
            {
                comandText = "USP_UpdProducto";
                parameters = new SqlParameter[11];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.VarChar);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombreproducto", SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@idproveedor", SqlDbType.Int);
                parameters[2].Value = producto.idProveedor;
                parameters[3] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[3].Value = producto.idCategoria;
                parameters[4] = new SqlParameter("@cantidadporunidad", SqlDbType.VarChar);
                parameters[4].Value = producto.cantidadPorUnidad;
                parameters[5] = new SqlParameter("@preciounidad", SqlDbType.Decimal);
                parameters[5].Value = producto.precioUnidadDecimal;
                parameters[6] = new SqlParameter("@unidadesenexistencia", SqlDbType.Int);
                parameters[6].Value = producto.unidadesEnExistencia;
                parameters[7] = new SqlParameter("@unidadesenpedido", SqlDbType.Int);
                parameters[7].Value = producto.unidadesEnPedido;
                parameters[8] = new SqlParameter("@nivelnuevopedido", SqlDbType.Int);
                parameters[8].Value = producto.nivelNuevoPedido;
                parameters[9] = new SqlParameter("@suspendido", SqlDbType.Int);
                parameters[9].Value = producto.Suspendido;
                parameters[10] = new SqlParameter("@categoriaproducto", SqlDbType.VarChar);
                parameters[10].Value = producto.categoriaProducto;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;

            try
            {
                comandText = "USP_DelProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
