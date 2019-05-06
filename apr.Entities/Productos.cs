
using System;


namespace apr.Entities
{
    public class Productos
    {

        public Int32 Idproducto { get; set; }
        public Int32 Idcategoria { get; set; }
        public String Nombre { get; set; }
        public String Presentacion { get; set; }
        public Decimal Precio { get; set; }
        public virtual Categorias categoria { get; set; }

    }
}
