using System;
using System.Collections.Generic;
using UStart.Domain.Entities;

namespace UStart.Domain.Contracts.Repositories
{
    public interface IGrupoProdutoRepository
    {
        void Add(GrupoProduto GrupoProduto);
        GrupoProduto ConsultarPorId(Guid id);
        void Delete(GrupoProduto grupoProduto);
        IEnumerable<GrupoProduto> Pesquisar(string pesquisa);
        IEnumerable<GrupoProduto> RetornarTodos();
        void Update(GrupoProduto GrupoProduto);
    }
}
