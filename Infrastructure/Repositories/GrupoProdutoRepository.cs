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
    public class GrupoProdutoRepository : IGrupoProdutoRepository
    {
        private readonly UStartContext _context;

        public GrupoProdutoRepository(UStartContext context)
        {
            _context = context;
        }

        public GrupoProduto ConsultarPorId(Guid id)
        {
            return _context.GrupoProdutos
                .FirstOrDefault(u => u.Id == id);
        }

        public void Add(GrupoProduto GrupoProduto)
        {
            _context.GrupoProdutos.Add(GrupoProduto);
        }

        public void Update(GrupoProduto GrupoProduto)
        {
            _context.GrupoProdutos.Update(GrupoProduto);
        }

        public virtual void Delete(GrupoProduto grupoProduto)
        {
            if (_context.Entry(grupoProduto).State == EntityState.Detached)
            {
                _context.GrupoProdutos.Attach(grupoProduto);
            }
            _context.GrupoProdutos.Remove(grupoProduto);
        }

        public IEnumerable<GrupoProduto> RetornarTodos()
        {
            return _context.GrupoProdutos.ToList();
        }

        public IEnumerable<GrupoProduto> Pesquisar(string pesquisa)
        {
            pesquisa = pesquisa != null ? pesquisa.ToLower() : string.Empty;
            
            return _context
            .GrupoProdutos
            .Where(x => x.Descricao.ToLower().Contains(pesquisa))
            .ToList();
        }
    }
}
