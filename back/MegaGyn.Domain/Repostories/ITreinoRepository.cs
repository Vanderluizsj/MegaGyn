using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaGyn.Domain.Repostories
{
     /// <summary>
    /// Interface para o repositório de treinos.
    /// </summary>
    public interface ITreinoRepository
    {
        /// <summary>
        /// Adiciona um novo treino.
        /// </summary>
        /// <param name="treino">O treino a ser adicionado.</param>
        void Adicionar(Treino treino);

        /// <summary>
        /// Atualiza as informações de um treino.
        /// </summary>
        /// <param name="id">O ID do treino a ser atualizado.</param>
        void Atualizar(int id);

        /// <summary>
        /// Deleta um treino pelo ID.
        /// </summary>
        /// <param name="id">O ID do treino a ser deletado.</param>
        void Deletar(int id);

        /// <summary>
        /// Busca todos os treinos.
        /// </summary>
        /// <returns>Uma lista de todos os treinos.</returns>
        List<Treino> BuscarTodos();

        /// <summary>
        /// Busca um treino pelo ID.
        /// </summary>
        /// <param name="id">O ID do treino a ser buscado.</param>
        /// <returns>O treino encontrado.</returns>
        Treino BuscarPorId(int id);
    }
}