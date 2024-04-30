using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaGyn.Domain;
using MegaGyn.Domain.Repositories;
using MegaGyn.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace MegaGyn.API.Controllers
{
    /// <summary>
    /// Controlador para lidar com operações relacionadas aos exercícios.
    /// </summary>
    [ApiController]
    [Route("api/exercicio")]
    public class ExercicioController : ControllerBase
    {
        private IExercicioRepository _exercicioRepository = new ExercicioRepository();

        public ExercicioController()
        {
            _exercicioRepository = new ExercicioRepository();
        }
        /// <summary>
        /// Adiciona um novo exercício.
        /// </summary>
        /// <param name="exercicio">O exercício a ser adicionado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPost]
        public IActionResult AdicionarExercicio([FromBody] Exercicio exercicio)
        {
            _exercicioRepository.Adicionar(exercicio);
            return Ok();
        }
        /// <summary>
        /// Busca um exercício pelo ID.
        /// </summary>
        /// <param name="id">O ID do exercício.</param>
        /// <returns>O exercício encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var exercicio = _exercicioRepository.BuscarPorId(id);
            if (exercicio == null)
            {
                return NotFound();
            }
            return Ok(exercicio);
        }
        /// <summary>
        /// Atualiza as informações de um exercício.
        /// </summary>
        /// <param name="editado">O exercício com as informações atualizadas.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody]Exercicio editado)
        {
            try
            {
                _exercicioRepository.Atualizar(editado.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500,  e.Message);
            }
        }
        /// <summary>
        /// Busca todos os exercícios.
        /// </summary>
        /// <returns>Uma lista de todos os exercícios.</returns>
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var exercicios = _exercicioRepository.BuscarTodos();
            return Ok(exercicios);
        }
        /// <summary>
        /// Deleta um exercício pelo ID.
        /// </summary>
        /// <param name="id">O ID do exercício a ser deletado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var exercicioEncontrado = _exercicioRepository.BuscarPorId(id);
            if (exercicioEncontrado == null)
            {
                return NotFound();
            }
            _exercicioRepository.Deletar(id);
            return Ok();
        }
    }
}
