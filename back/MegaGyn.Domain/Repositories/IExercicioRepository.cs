using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaGyn.Domain.Repositories
{
    /// <summary>
    /// Interface para o repositório de exercicios.
    /// </summary>
    public interface IExercicioRepository
    {
         /// <summary>
        /// Adiciona um novo exercício.
        /// </summary>
        /// <param name="exercicio">O exercício a ser adicionado.</param>
        void Adicionar(Exercicio exercicio);
        /// <summary>
        /// Atualiza as informações de um exercício.
        /// </summary>
        /// <param name="id">O ID do exercício a ser atualizado.</param>
        void Atualizar(int id);
        /// <summary>
        /// Deleta um exercício pelo ID.
        /// </summary>
        /// <param name="id">O ID do exercício a ser deletado.</param>
        void Deletar(int id);
         /// <summary>
        /// Busca todos os exercícios.
        /// </summary>
        /// <returns>Uma lista de todos os exercícios.</returns>
        List<Exercicio> BuscarTodos();
        /// <summary>
        /// Busca um exercício pelo ID.
        /// </summary>
        /// <param name="id">O ID do exercício a ser buscado.</param>
        /// <returns>O exercício encontrado.</returns>
        Exercicio BuscarPorId(int id);        
    }
}