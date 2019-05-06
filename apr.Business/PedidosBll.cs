
using System;
using System.Collections.Generic;
using apr.Entities;
using apr.Repository;

namespace apr.Business
{
    public class PedidosBll
    {

        public bool create(Pedidos pedidos)
        {
            return new PedidosRepository().create(pedidos);
        }

        public bool edit(Pedidos pedidos)
        {
            return new PedidosRepository().edit(pedidos);
        }

        public bool remove(Int32 idpedido)
        {
            return new PedidosRepository().remove(idpedido);
        }

        public List<Pedidos> findAll()
        {
            return new PedidosRepository().findAll();
        }

        public Pedidos find(Int32 idpedido)
        {
            return new PedidosRepository().find(idpedido);
        }

    }
}
