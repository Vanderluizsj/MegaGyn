using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaGyn.Domain.Repositories
{
    /// <summary>
    /// Interface para o repositório de alunos.
    /// </summary>
    public interface IAlunoRepository
    {
        /// <summary>
        /// Adiciona um novo aluno.
        /// </summary>
        /// <param name="aluno">O aluno a ser adicionado.</param>
        void Adicionar(Aluno aluno);
        /// <summary>
        /// Atualiza as informações de um aluno.
        /// </summary>
        /// <param name="id">O ID do aluno a ser atualizado.</param>
        void Atualizar(int id);
         /// <summary>
        /// Deleta um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno a ser deletado.</param>
        void Deletar(int id);
        /// <summary>
        /// Busca todos os alunos.
        /// </summary>
        /// <returns>Uma lista de todos os alunos.</returns>
        List<Aluno> BuscarTodos();
        /// <summary>
        /// Busca um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno a ser buscado.</param>
        /// <returns>O aluno encontrado.</returns>
        Aluno BuscarPorId(int id);        
    }
}