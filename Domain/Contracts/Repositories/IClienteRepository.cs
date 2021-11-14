using System;
using System.Collections.Generic;
using UStart.Domain.Entities;

namespace UStart.Domain.Contracts.Repositories
{
    public interface IClienteRepository
    {
        void Add(Cliente Cliente);
        Cliente ConsultarPorId(Guid id);
        void Delete(Cliente Cliente);
        IEnumerable<Cliente> Pesquisar(string pesquisa);
        IEnumerable<Cliente> RetornarTodos();
        void Update(Cliente Cliente);
    }
}
