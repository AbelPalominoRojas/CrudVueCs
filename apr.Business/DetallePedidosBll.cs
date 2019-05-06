
using System;
using System.Collections.Generic;
using apr.Entities;
using apr.Repository;

namespace apr.Business
{
    public class DetallePedidosBll
    {

        public bool create(DetallePedidos detallePedidos)
        {
            return new DetallePedidosRepository().create(detallePedidos);
        }

        public bool edit(DetallePedidos detallePedidos)
        {
            return new DetallePedidosRepository().edit(detallePedidos);
        }

        public bool remove(Int32 idpedido,Int32 idproducto)
        {
            return new DetallePedidosRepository().remove(idpedido,idproducto);
        }

        public List<DetallePedidos> findAll(Int32 idpedido)
        {
            return new DetallePedidosRepository().findAll(idpedido);
        }

        public DetallePedidos find(Int32 idpedido,Int32 idproducto)
        {
            return new DetallePedidosRepository().find(idpedido,idproducto);
        }

    }
}
