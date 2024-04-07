using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaGyn.Domain;
using MegaGyn.Domain.Repostories;
using Microsoft.AspNetCore.Mvc;

namespace MegaGyn.API.Controllers
{
     /// <summary>
    /// Controlador para lidar com operações relacionadas aos treinos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class treinoController : ControllerBase
    {
        private readonly ITreinoRepository _treinoRepository;

        public treinoController(ITreinoRepository treinoRepository)
        {
            _treinoRepository = treinoRepository;
        }
        /// <summary>
        /// Adiciona um novo treino.
        /// </summary>
        /// <param name="treino">O treino a ser adicionado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPost]
        public IActionResult Adicionartreino([FromBody] Treino treino)
        {
            _treinoRepository.Adicionar(treino);
            return Ok();
        }
        /// <summary>
        /// Busca um treino pelo ID.
        /// </summary>
        /// <param name="id">O ID do treino.</param>
        /// <returns>O treino encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var treino = _treinoRepository.BuscarPorId(id);
            if (treino == null)
            {
                return NotFound();
            }
            return Ok(treino);
        }
        /// <summary>
        /// Atualiza as informações de um treino.
        /// </summary>
        /// <param name="editado">O treino com as informações atualizadas.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody]Treino editado)
        {
            try
            {
                _treinoRepository.Atualizar(editado.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500,  e.Message);
            }
        }
        /// <summary>
        /// Busca todos os treinos.
        /// </summary>
        /// <returns>Uma lista de todos os treinos.</returns>
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var treinos = _treinoRepository.BuscarTodos();
            return Ok(treinos);
        }
        /// <summary>
        /// Deleta um treino pelo ID.
        /// </summary>
        /// <param name="id">O ID do treino a ser deletado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var treinoEncontrado = _treinoRepository.BuscarPorId(id);
            if (treinoEncontrado == null)
            {
                return NotFound();
            }
            _treinoRepository.Deletar(id);
            return Ok();
        }
    }
}
