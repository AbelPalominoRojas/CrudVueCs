
using System;


namespace apr.Entities
{
    public class DetallePedidos
    {

        public Int32 Idpedido { get; set; }
        public Int32 Idproducto { get; set; }
        public Decimal Precio { get; set; }
        public Int32 Cantidad { get; set; }
        public virtual Productos producto { get; set; }

    }
}
