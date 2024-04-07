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
    /// Controlador para lidar com operações relacionadas aos alunos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        /// <summary>
        /// Adiciona um novo aluno.
        /// </summary>
        /// <param name="aluno">O aluno a ser adicionado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPost]
        public IActionResult AdicionarAluno([FromBody] Aluno aluno)
        {
            _alunoRepository.Adicionar(aluno);
            return Ok();
        }
        /// <summary>
        /// Busca um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno.</param>
        /// <returns>O aluno encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var aluno = _alunoRepository.BuscarPorId(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }
        /// <summary>
        /// Atualiza as informações de um aluno.
        /// </summary>
        /// <param name="editado">O aluno com as informações atualizadas.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPut]
        public IActionResult Atualizar([FromBody]Aluno editado)
        {
            try
            {
                //var clienteBuscado = editado.Cpf;
                _alunoRepository.Atualizar(editado.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Busca todos os alunos.
        /// </summary>
        /// <returns>Uma lista de todos os alunos.</returns>
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            var alunos = _alunoRepository.BuscarTodos();
            return Ok(alunos);
        }
        /// <summary>
        /// Deleta um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno a ser deletado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var alunoEncontrado = _alunoRepository.BuscarPorId(id);
            if (alunoEncontrado == null)
            {
                return NotFound();
            }
            _alunoRepository.Deletar(id);
            return Ok();
        }
    }
}
