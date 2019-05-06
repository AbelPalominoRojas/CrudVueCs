
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apr.Repository
{
    public class DetallePedidosRepository
    {
        public bool create(DetallePedidos detallePedidos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_detalle_pedidos_Insert";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", detallePedidos.Idpedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", detallePedidos.Idproducto);
                    sqlCommand.Parameters.AddWithValue("@precio", detallePedidos.Precio);
                    sqlCommand.Parameters.AddWithValue("@cantidad", detallePedidos.Cantidad);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool edit(DetallePedidos detallePedidos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_detalle_pedidos_Update";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", detallePedidos.Idpedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", detallePedidos.Idproducto);
                    sqlCommand.Parameters.AddWithValue("@precio", detallePedidos.Precio);
                    sqlCommand.Parameters.AddWithValue("@cantidad", detallePedidos.Cantidad);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool remove(Int32 idpedido, Int32 idproducto)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_detalle_pedidos_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", idproducto);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public List<DetallePedidos> findAll(Int32 idpedido)
        {
            List<DetallePedidos> listDetallePedidos = new List<DetallePedidos>();

            string sqlQuery = "dbo.USP_detalle_pedidos_SelectAll";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        DetallePedidos resultDetallePedidos = null;
                        Productos producto = null;
                        Categorias categoria = null;

                        while (sqlDataReader.Read())
                        {
                            resultDetallePedidos = new DetallePedidos();
                            producto = new Productos();
                            categoria = new Categorias();


                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                            {
                                resultDetallePedidos.Idpedido = sqlDataReader.GetInt32(idpedido_index);
                                producto.Idproducto = resultDetallePedidos.Idproducto;
                            }

                            int idproducto_index = sqlDataReader.GetOrdinal("idproducto");
                            if (!sqlDataReader.IsDBNull(idproducto_index))
                                resultDetallePedidos.Idproducto = sqlDataReader.GetInt32(idproducto_index);

                            int precio_index = sqlDataReader.GetOrdinal("precio");
                            if (!sqlDataReader.IsDBNull(precio_index))
                                resultDetallePedidos.Precio = sqlDataReader.GetDecimal(precio_index);

                            int cantidad_index = sqlDataReader.GetOrdinal("cantidad");
                            if (!sqlDataReader.IsDBNull(cantidad_index))
                                resultDetallePedidos.Cantidad = sqlDataReader.GetInt32(cantidad_index);
                            

                            int idcategoria_index = sqlDataReader.GetOrdinal("idcategoria");
                            if (!sqlDataReader.IsDBNull(idcategoria_index))
                            {
                                producto.Idcategoria = sqlDataReader.GetInt32(idcategoria_index);
                                categoria.Idcategoria = producto.Idcategoria;
                            }

                            //producto
                            int nombre_index = sqlDataReader.GetOrdinal("nombre");
                            if (!sqlDataReader.IsDBNull(nombre_index))
                                producto.Nombre = sqlDataReader.GetString(nombre_index);

                            int presentacion_index = sqlDataReader.GetOrdinal("presentacion");
                            if (!sqlDataReader.IsDBNull(presentacion_index))
                                producto.Presentacion = sqlDataReader.GetString(presentacion_index);

                            int precioproducto_index = sqlDataReader.GetOrdinal("precioproducto");
                            if (!sqlDataReader.IsDBNull(precioproducto_index))
                                producto.Precio = sqlDataReader.GetDecimal(precioproducto_index);

                            //categoria
                            int categoria_index = sqlDataReader.GetOrdinal("categoria");
                            if (!sqlDataReader.IsDBNull(categoria_index))
                                categoria.Nombre = sqlDataReader.GetString(categoria_index);

                           
                            producto.categoria = categoria;
                            resultDetallePedidos.producto = producto;

                            listDetallePedidos.Add(resultDetallePedidos);
                        }
                    }
                }
            }

            return listDetallePedidos;
        }

        public DetallePedidos find(Int32 idpedido, Int32 idproducto)
        {
            DetallePedidos resultDetallePedidos = null;

            string sqlQuery = "dbo.USP_detalle_pedidos_SelectById";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);
                    sqlCommand.Parameters.AddWithValue("@idproducto", idproducto);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        while (sqlDataReader.Read())
                        {
                            resultDetallePedidos = new DetallePedidos();

                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                                resultDetallePedidos.Idpedido = sqlDataReader.GetInt32(idpedido_index);

                            int idproducto_index = sqlDataReader.GetOrdinal("idproducto");
                            if (!sqlDataReader.IsDBNull(idproducto_index))
                                resultDetallePedidos.Idproducto = sqlDataReader.GetInt32(idproducto_index);

                            int precio_index = sqlDataReader.GetOrdinal("precio");
                            if (!sqlDataReader.IsDBNull(precio_index))
                                resultDetallePedidos.Precio = sqlDataReader.GetDecimal(precio_index);

                            int cantidad_index = sqlDataReader.GetOrdinal("cantidad");
                            if (!sqlDataReader.IsDBNull(cantidad_index))
                                resultDetallePedidos.Cantidad = sqlDataReader.GetInt32(cantidad_index);


                        }
                    }
                }
            }

            return resultDetallePedidos;
        }

    }
}
