
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apr.Repository
{
    public class ProductosRepository
    {
        public bool create(Productos productos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_productos_Insert";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add("@idproducto", SqlDbType.Int).Direction = ParameterDirection.Output;
                    sqlCommand.Parameters.AddWithValue("@idcategoria", productos.Idcategoria);
                    sqlCommand.Parameters.AddWithValue("@nombre", productos.Nombre);
                    sqlCommand.Parameters.AddWithValue("@presentacion", productos.Presentacion);
                    sqlCommand.Parameters.AddWithValue("@precio", productos.Precio);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool edit(Productos productos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_productos_Update";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idproducto", productos.Idproducto);
                    sqlCommand.Parameters.AddWithValue("@idcategoria", productos.Idcategoria);
                    sqlCommand.Parameters.AddWithValue("@nombre", productos.Nombre);
                    sqlCommand.Parameters.AddWithValue("@presentacion", productos.Presentacion);
                    sqlCommand.Parameters.AddWithValue("@precio", productos.Precio);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool remove(Int32 idproducto)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_productos_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idproducto", idproducto);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public List<Productos> findAll()
        {
            List<Productos> listProductos = new List<Productos>();

            string sqlQuery = "dbo.USP_productos_SelectAll";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        Productos resultProductos = null;
                        Categorias categoria = null;

                        while (sqlDataReader.Read())
                        {
                            resultProductos = new Productos();
                            categoria = new Categorias();

                            int idproducto_index = sqlDataReader.GetOrdinal("idproducto");
                            if (!sqlDataReader.IsDBNull(idproducto_index))
                                resultProductos.Idproducto = sqlDataReader.GetInt32(idproducto_index);

                            int idcategoria_index = sqlDataReader.GetOrdinal("idcategoria");
                            if (!sqlDataReader.IsDBNull(idcategoria_index))
                            {
                                resultProductos.Idcategoria = sqlDataReader.GetInt32(idcategoria_index);
                                resultProductos.categoria = categoria;
                            }

                            int nombre_index = sqlDataReader.GetOrdinal("nombre");
                            if (!sqlDataReader.IsDBNull(nombre_index))
                                resultProductos.Nombre = sqlDataReader.GetString(nombre_index);

                            int presentacion_index = sqlDataReader.GetOrdinal("presentacion");
                            if (!sqlDataReader.IsDBNull(presentacion_index))
                                resultProductos.Presentacion = sqlDataReader.GetString(presentacion_index);

                            int precio_index = sqlDataReader.GetOrdinal("precio");
                            if (!sqlDataReader.IsDBNull(precio_index))
                                resultProductos.Precio = sqlDataReader.GetDecimal(precio_index);

                            //categoria
                            int categoria_index = sqlDataReader.GetOrdinal("categoria");
                            if (!sqlDataReader.IsDBNull(categoria_index))
                                categoria.Nombre = sqlDataReader.GetString(categoria_index);


                            resultProductos.categoria = categoria;

                            listProductos.Add(resultProductos);
                        }
                    }
                }
            }

            return listProductos;
        }

        public Productos find(Int32 idproducto)
        {
            Productos resultProductos = null;

            string sqlQuery = "dbo.USP_productos_SelectById";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idproducto", idproducto);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        while (sqlDataReader.Read())
                        {
                            resultProductos = new Productos();

                            int idproducto_index = sqlDataReader.GetOrdinal("idproducto");
                            if (!sqlDataReader.IsDBNull(idproducto_index))
                                resultProductos.Idproducto = sqlDataReader.GetInt32(idproducto_index);

                            int idcategoria_index = sqlDataReader.GetOrdinal("idcategoria");
                            if (!sqlDataReader.IsDBNull(idcategoria_index))
                                resultProductos.Idcategoria = sqlDataReader.GetInt32(idcategoria_index);

                            int nombre_index = sqlDataReader.GetOrdinal("nombre");
                            if (!sqlDataReader.IsDBNull(nombre_index))
                                resultProductos.Nombre = sqlDataReader.GetString(nombre_index);

                            int presentacion_index = sqlDataReader.GetOrdinal("presentacion");
                            if (!sqlDataReader.IsDBNull(presentacion_index))
                                resultProductos.Presentacion = sqlDataReader.GetString(presentacion_index);

                            int precio_index = sqlDataReader.GetOrdinal("precio");
                            if (!sqlDataReader.IsDBNull(precio_index))
                                resultProductos.Precio = sqlDataReader.GetDecimal(precio_index);


                        }
                    }
                }
            }

            return resultProductos;
        }

        public List<Productos> findAllByIdCategoria(Int32 idcategoria)
        {
            List<Productos> listProductos = new List<Productos>();

            string sqlQuery = "dbo.USP_productos_SelectByIdCategoria";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idcategoria", idcategoria);    

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        Productos resultProductos = null;
                        Categorias categoria = null;

                        while (sqlDataReader.Read())
                        {
                            resultProductos = new Productos();
                            categoria = new Categorias();

                            int idproducto_index = sqlDataReader.GetOrdinal("idproducto");
                            if (!sqlDataReader.IsDBNull(idproducto_index))
                                resultProductos.Idproducto = sqlDataReader.GetInt32(idproducto_index);

                            int idcategoria_index = sqlDataReader.GetOrdinal("idcategoria");
                            if (!sqlDataReader.IsDBNull(idcategoria_index))
                            {
                                resultProductos.Idcategoria = sqlDataReader.GetInt32(idcategoria_index);
                                resultProductos.categoria = categoria;
                            }

                            int nombre_index = sqlDataReader.GetOrdinal("nombre");
                            if (!sqlDataReader.IsDBNull(nombre_index))
                                resultProductos.Nombre = sqlDataReader.GetString(nombre_index);

                            int presentacion_index = sqlDataReader.GetOrdinal("presentacion");
                            if (!sqlDataReader.IsDBNull(presentacion_index))
                                resultProductos.Presentacion = sqlDataReader.GetString(presentacion_index);

                            int precio_index = sqlDataReader.GetOrdinal("precio");
                            if (!sqlDataReader.IsDBNull(precio_index))
                                resultProductos.Precio = sqlDataReader.GetDecimal(precio_index);

                            //categoria
                            int categoria_index = sqlDataReader.GetOrdinal("categoria");
                            if (!sqlDataReader.IsDBNull(categoria_index))
                                categoria.Nombre = sqlDataReader.GetString(categoria_index);


                            resultProductos.categoria = categoria;

                            listProductos.Add(resultProductos);
                        }
                    }
                }
            }

            return listProductos;
        }

    }
}
