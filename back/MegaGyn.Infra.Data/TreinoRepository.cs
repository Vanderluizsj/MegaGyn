using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaGyn.Domain;
using MegaGyn.Domain.Repositories;
using MegaGyn.Infra.Data.DAO;

namespace MegaGyn.Infra.Data
{
    /// <summary>
    /// Implementação do repositório de treinos.
    /// </summary>
    public class TreinoRepository : ITreinoRepository
    {
         private readonly TreinoDAO _treinoDao;
         /// <summary>
        /// Construtor padrão que inicializa o TreinoDAO.
        /// </summary>
        public TreinoRepository()
        {
            _treinoDao = new TreinoDAO();
        }
        /// <summary>
        /// Adiciona um novo treino.
        /// </summary>
        /// <param name="treino">O treino a ser adicionado.</param>
        public void Adicionar(Treino treino)
        {
            _treinoDao.AdicionarTreino(treino);
        }
        
        /// <summary>
        /// Busca um treino pelo ID.
        /// </summary>
        /// <param name="id">O ID do treino a ser buscado.</param>
        /// <returns>O treino encontrado.</returns>
        public Treino BuscarPorId(int id)
        {
            return _treinoDao.BuscarPorId(id);
        }       
        /// <summary>
        /// Atualiza as informações de um treino.
        /// </summary>
        /// <param name="id">O ID do treino a ser atualizado.</param> 
        public void Atualizar(int id)
        {
            var treinoEncontrado = _treinoDao.BuscarPorId(id);
            _treinoDao.AtualizarTreino(treinoEncontrado);
        }
        /// <summary>
        /// Busca todos os treinos.
        /// </summary>
        /// <returns>Uma lista de todos os treinos.</returns>
        public List<Treino> BuscarTodos()
        {
            return _treinoDao.BuscaTodos();
        }
        /// <summary>
        /// Deleta um treino pelo ID.
        /// </summary>
        /// <param name="id">O ID do treino a ser deletado.</param>
        public void Deletar(int id)
        {
            var treinoEncontrado = _treinoDao.BuscarPorId(id);

            _treinoDao.DeletarTreino(treinoEncontrado);
        }
    }
}