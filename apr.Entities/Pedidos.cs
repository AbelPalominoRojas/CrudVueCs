
using System;
using System.Collections.Generic;

namespace apr.Entities
{
    public class Pedidos
    {

        public Int32 Idpedido { get; set; }
        public Int32 Idcliente { get; set; }
        public DateTime Fecha { get; set; }

        public virtual String FechaString { get { return (Fecha != null ? Fecha.ToShortDateString() : ""); } }
        public virtual Clientes cliente { get; set; }
        public List<DetallePedidos> detallePedidos { get; set; }
    }
}
