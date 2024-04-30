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
    /// Controlador para lidar com operações relacionadas aos alunos.
    /// </summary>
    [ApiController]
    [Route("api/aluno")]
    public class AlunoController : ControllerBase
    {
        private IAlunoRepository _alunoRepository = new AlunoRepository();

        public AlunoController()
        {
            _alunoRepository = new AlunoRepository();
        }
        /// <summary>
        /// Adiciona um novo aluno.
        /// </summary>
        /// <param name="aluno">O aluno a ser adicionado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPost]
        public IActionResult AdicionarAluno([FromBody] Aluno aluno)
        {
            try{
                
                _alunoRepository.Adicionar(aluno);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
         /// <summary>
        /// Busca todos os alunos.
        /// </summary>
        /// <returns>Uma lista de todos os alunos.</returns>
        [HttpGet]
        [Route("alunos")]
        public IActionResult BuscarTodos()
        {
            try
            {
                return Ok(_alunoRepository.BuscarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Busca um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno.</param>
        /// <returns>O aluno encontrado.</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var aluno = _alunoRepository.BuscarPorId(id);
                if (aluno == null)
                {
                    return NotFound("O aluno não foi encontrado!");
                }

                return StatusCode(200, aluno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Atualiza as informações de um aluno.
        /// </summary>
        /// <param name="editado">O aluno com as informações atualizadas.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpPut]
        [Route("alunos")]
        public IActionResult Atualizar([FromBody]Aluno editado)
        {
            try
            {
                //var clienteBuscado = editado.Cpf;
                _alunoRepository.Atualizar(editado.Id);
                return StatusCode(200, editado);
            }
            catch (Exception e)
            {
                return StatusCode(400);
            }
        }       
        /// <summary>
        /// Deleta um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno a ser deletado.</param>
        /// <returns>O resultado da operação.</returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var alunoEncontrado = _alunoRepository.BuscarPorId(id);
                if (alunoEncontrado == null)
                {
                    return NotFound();
                }
                _alunoRepository.Deletar(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }          
            
        }
    }
}
