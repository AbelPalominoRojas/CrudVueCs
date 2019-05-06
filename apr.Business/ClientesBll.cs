
using System;
using System.Collections.Generic;
using apr.Entities;
using apr.Repository;

namespace apr.Business
{
    public class ClientesBll
    {

        public bool create(Clientes clientes)
        {
            return new ClientesRepository().create(clientes);
        }

        public bool edit(Clientes clientes)
        {
            return new ClientesRepository().edit(clientes);
        }

        public bool remove(Int32 idcliente)
        {
            return new ClientesRepository().remove(idcliente);
        }

        public List<Clientes> findAll()
        {
            return new ClientesRepository().findAll();
        }

        public Clientes find(Int32 idcliente)
        {
            return new ClientesRepository().find(idcliente);
        }

    }
}
