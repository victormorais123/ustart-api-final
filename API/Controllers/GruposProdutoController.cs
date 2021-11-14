using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Workflows;

namespace UStart.API.Controllers
{
    /// <summary>
    /// Exemplo de controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/grupo-produto")]
    [Authorize]
    public class GrupoProdutoController : ControllerBase
    {
        private readonly IGrupoProdutoRepository _grupoProdutoRepository;
        private readonly GrupoProdutoWorkflow _grupoProdutoWorkflow;
        public GrupoProdutoController(
            IGrupoProdutoRepository grupoProdutoRepository, 
            GrupoProdutoWorkflow grupoProdutoWorkflow)
        {
            _grupoProdutoRepository = grupoProdutoRepository;
            _grupoProdutoWorkflow = grupoProdutoWorkflow;
        }

        /// <summary>
        /// Consultar todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult GetGruposProdutos([FromQuery]string pesquisa)
        {
            return Ok(_grupoProdutoRepository.Pesquisar(pesquisa));
        }

        /// <summary>
        /// Consultar apenas um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]    
        [Route("{id}")]    
        public IActionResult GetGrupoProduto([FromRoute] Guid id)
        {
            return Ok(_grupoProdutoRepository.ConsultarPorId(id));
        }

        /// <summary>
        /// Adicionar (insert) um grupo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]            
        public IActionResult AdicionarGrupoProduto([FromBody] GrupoProdutoCommand command)
        {
            _grupoProdutoWorkflow.Add(command);
            if (_grupoProdutoWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_grupoProdutoWorkflow.GetErrors());
        }

        /// <summary>
        /// Atualizar (update) um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut] 
        [Route("{id}")]           
        public IActionResult AtualizarGrupoProduto([FromRoute] Guid id, [FromBody] GrupoProdutoCommand command)
        {
            _grupoProdutoWorkflow.Update(id, command);
            if (_grupoProdutoWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_grupoProdutoWorkflow.GetErrors());
        }

        /// <summary>
        /// Excluir um grupo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]            
        public IActionResult DeletarGrupoProduto([FromRoute] Guid id)
        {
            _grupoProdutoWorkflow.Delete(id);
            if (_grupoProdutoWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_grupoProdutoWorkflow.GetErrors());
        }


    }
}
