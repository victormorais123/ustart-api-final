using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UStart.Domain.Contracts.Entities;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.Results;
using UStart.Infrastructure.Context;

namespace UStart.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly UStartContext _context;

        public ClienteRepository(UStartContext context)
        {
            _context = context;
        }

        public Cliente ConsultarPorId(Guid id)
        {
            return _context.Clientes
                .FirstOrDefault(u => u.Id == id);
        }

        public void Add(Cliente Cliente)
        {
            _context.Clientes.Add(Cliente);
        }

        public void Update(Cliente Cliente)
        {
            _context.Clientes.Update(Cliente);
        }

        public virtual void Delete(Cliente Cliente)
        {
            if (_context.Entry(Cliente).State == EntityState.Detached)
            {
                _context.Clientes.Attach(Cliente);
            }
            _context.Clientes.Remove(Cliente);
        }

        public IEnumerable<Cliente> RetornarTodos()
        {
            return _context
                .Clientes                
                .ToList();
        }
        public IEnumerable<Cliente> Pesquisar(string pesquisa)
        {
            pesquisa = pesquisa != null ?  pesquisa.ToLower() : "";
            return _context
            .Clientes
            .Where(x => x.Nome.ToLower().Contains(pesquisa))
            .ToList();
        }
    }
}
