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
    [Route("api/v{version:apiVersion}/cliente")]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ClienteWorkflow _clienteWorkflow;
        public ClienteController(
            IClienteRepository clienteRepository, 
            ClienteWorkflow clienteWorkflow)
        {
            _clienteRepository = clienteRepository;
            _clienteWorkflow = clienteWorkflow;
        }

        /// <summary>
        /// Consultar todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get()
        {
            return Ok(_clienteRepository.RetornarTodos());
        }

        /// <summary>
        /// Consultar apenas um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]    
        [Route("{id}")]    
        public IActionResult GetPorId([FromRoute] Guid id)
        {
            return Ok(_clienteRepository.ConsultarPorId(id));
        }

        /// <summary>
        /// Adicionar (insert) um grupo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]            
        public IActionResult Adicionar([FromBody] ClienteCommand command)
        {
            _clienteWorkflow.Add(command);
            if (_clienteWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_clienteWorkflow.GetErrors());
        }

        /// <summary>
        /// Atualizar (update) um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut] 
        [Route("{id}")]           
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] ClienteCommand command)
        {
            _clienteWorkflow.Update(id, command);
            if (_clienteWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_clienteWorkflow.GetErrors());
        }

        /// <summary>
        /// Excluir um grupo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]            
        public IActionResult Deletar([FromRoute] Guid id)
        {
            _clienteWorkflow.Delete(id);
            if (_clienteWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_clienteWorkflow.GetErrors());
        }


    }
}
