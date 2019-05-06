
using apr.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace apr.Repository
{
    public class PedidosRepository
    {
        public bool create(Pedidos pedidos)
        {
            bool result = false;

            using (TransactionScope transactionScope = new TransactionScope())
            {
                //Insert header (Pedido)
                string sqlQuery = "dbo.USP_pedidos_Insert";

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        sqlConnection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        sqlCommand.Parameters.Add("@idpedido", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sqlCommand.Parameters.AddWithValue("@idcliente", pedidos.Idcliente);
                        sqlCommand.Parameters.AddWithValue("@fecha", pedidos.Fecha);

                        sqlCommand.ExecuteNonQuery();

                        pedidos.Idpedido = Convert.ToInt32(sqlCommand.Parameters["@idpedido"].Value);

                    }
                }

                //Insert Detail (DetallePedidos)
                foreach (var item in pedidos.detallePedidos)
                {
                    sqlQuery = "dbo.USP_detalle_pedidos_Insert";

                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                        {
                            sqlConnection.Open();
                            sqlCommand.CommandType = CommandType.StoredProcedure;

                            sqlCommand.Parameters.AddWithValue("@idpedido", pedidos.Idpedido);
                            sqlCommand.Parameters.AddWithValue("@idproducto", item.Idproducto);
                            sqlCommand.Parameters.AddWithValue("@precio", item.Precio);
                            sqlCommand.Parameters.AddWithValue("@cantidad", item.Cantidad);

                            result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                        }
                    }
                }

                transactionScope.Complete();
                result = true;
            }



            return result;
        }

        public bool edit(Pedidos pedidos)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_pedidos_Update";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", pedidos.Idpedido);
                    sqlCommand.Parameters.AddWithValue("@idcliente", pedidos.Idcliente);
                    sqlCommand.Parameters.AddWithValue("@fecha", pedidos.Fecha);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public bool remove(Int32 idpedido)
        {
            bool result = false;

            string sqlQuery = "dbo.USP_pedidos_Delete";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);

                    result = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
                }
            }

            return result;
        }

        public List<Pedidos> findAll()
        {
            List<Pedidos> listPedidos = new List<Pedidos>();

            string sqlQuery = "dbo.USP_pedidos_SelectAll";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        Pedidos resultPedidos = null;
                        Clientes cliente = null;

                        while (sqlDataReader.Read())
                        {
                            resultPedidos = new Pedidos();
                            cliente = new Clientes();

                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                                resultPedidos.Idpedido = sqlDataReader.GetInt32(idpedido_index);

                            int idcliente_index = sqlDataReader.GetOrdinal("idcliente");
                            if (!sqlDataReader.IsDBNull(idcliente_index))
                            {
                                resultPedidos.Idcliente = sqlDataReader.GetInt32(idcliente_index);
                                cliente.Idcliente = resultPedidos.Idcliente;
                            }


                            int fecha_index = sqlDataReader.GetOrdinal("fecha");
                            if (!sqlDataReader.IsDBNull(fecha_index))
                                resultPedidos.Fecha = sqlDataReader.GetDateTime(fecha_index);

                            //cliente
                            int dni_index = sqlDataReader.GetOrdinal("dni");
                            if (!sqlDataReader.IsDBNull(dni_index))
                                cliente.Dni = sqlDataReader.GetString(dni_index);

                            int nombres_index = sqlDataReader.GetOrdinal("nombres");
                            if (!sqlDataReader.IsDBNull(nombres_index))
                                cliente.Nombres = sqlDataReader.GetString(nombres_index);

                            int apellidos_index = sqlDataReader.GetOrdinal("apellidos");
                            if (!sqlDataReader.IsDBNull(apellidos_index))
                                cliente.Apellidos = sqlDataReader.GetString(apellidos_index);


                            resultPedidos.cliente = cliente;

                            listPedidos.Add(resultPedidos);
                        }
                    }
                }
            }

            return listPedidos;
        }

        public Pedidos find(Int32 idpedido)
        {
            Pedidos resultPedidos = null;

            string sqlQuery = "dbo.USP_pedidos_SelectById";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionDB.getConnectionStrings()))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idpedido", idpedido);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleResult))
                    {

                        while (sqlDataReader.Read())
                        {
                            resultPedidos = new Pedidos();

                            int idpedido_index = sqlDataReader.GetOrdinal("idpedido");
                            if (!sqlDataReader.IsDBNull(idpedido_index))
                                resultPedidos.Idpedido = sqlDataReader.GetInt32(idpedido_index);

                            int idcliente_index = sqlDataReader.GetOrdinal("idcliente");
                            if (!sqlDataReader.IsDBNull(idcliente_index))
                                resultPedidos.Idcliente = sqlDataReader.GetInt32(idcliente_index);

                            int fecha_index = sqlDataReader.GetOrdinal("fecha");
                            if (!sqlDataReader.IsDBNull(fecha_index))
                                resultPedidos.Fecha = sqlDataReader.GetDateTime(fecha_index);


                        }
                    }
                }
            }

            return resultPedidos;
        }

    }
}
