
using System;
using System.Collections.Generic;
using apr.Entities;
using apr.Repository;

namespace apr.Business
{
    public class ProductosBll
    {

        public bool create(Productos productos)
        {
            return new ProductosRepository().create(productos);
        }

        public bool edit(Productos productos)
        {
            return new ProductosRepository().edit(productos);
        }

        public bool remove(Int32 idproducto)
        {
            return new ProductosRepository().remove(idproducto);
        }

        public List<Productos> findAll()
        {
            return new ProductosRepository().findAll();
        }

        public Productos find(Int32 idproducto)
        {
            return new ProductosRepository().find(idproducto);
        }

        public List<Productos> findAllByIdCategoria(Int32 idcategoria)
        {
            return new ProductosRepository().findAllByIdCategoria(idcategoria);
        }
    }
}
