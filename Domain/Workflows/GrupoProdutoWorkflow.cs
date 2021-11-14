using System;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.UoW;

namespace UStart.Domain.Workflows
{
    public class GrupoProdutoWorkflow : WorkflowBase
    {
        private readonly IGrupoProdutoRepository _grupoProdutoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GrupoProdutoWorkflow(IGrupoProdutoRepository GrupoProdutoRepository, IUnitOfWork unitOfWork)
        {
            _grupoProdutoRepository = GrupoProdutoRepository;
            _unitOfWork = unitOfWork;
        }

        public GrupoProduto Add(GrupoProdutoCommand command)
        {
            var GrupoProduto = new GrupoProduto(command);
            _grupoProdutoRepository.Add(GrupoProduto);
            _unitOfWork.Commit();

            return GrupoProduto;
        }

        public void Update(Guid id, GrupoProdutoCommand command)
        {
            var contaCliente = _grupoProdutoRepository.ConsultarPorId(id);
            if (contaCliente != null)
            {
                contaCliente.Update(command);
                _grupoProdutoRepository.Update(contaCliente);
                _unitOfWork.Commit();
            }
            else
            {
                AddError("Grupo Produto", "Grupo Produto não encontrado", id);
            }
        }

        public void Delete(Guid id)
        {
            try
            {

                var grupoProduto = _grupoProdutoRepository.ConsultarPorId(id);
                if (grupoProduto == null)
                {
                    AddError("Grupo Produto", "Grupo produto de dados não encontrado", id);
                }
                if (!IsValid())
                {
                    return;
                }

                _grupoProdutoRepository.Delete(grupoProduto);
                _unitOfWork.Commit();
            }
            catch (System.Exception exp)
            {
                if (this.isDevelopment())
                    AddException("Grupo Produto", exp);
                else throw;
            }
        }
    }
}