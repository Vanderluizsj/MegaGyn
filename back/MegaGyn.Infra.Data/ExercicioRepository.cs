using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaGyn.Domain;
using MegaGyn.Domain.Repostories;
using MegaGyn.Infra.Data.DAO;

namespace MegaGyn.Infra.Data
{
    /// <summary>
    /// Implementação do repositório de exercícios.
    /// </summary>
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly ExercicioDAO _exercicioDao;
         /// <summary>
        /// Construtor padrão que inicializa o ExercicioDAO.
        /// </summary>
        public ExercicioRepository()
        {
            _exercicioDao = new ExercicioDAO();
        }
        /// <summary>
        /// Adiciona um novo exercício.
        /// </summary>
        /// <param name="exercicio">O exercício a ser adicionado.</param>
        public void Adicionar(Exercicio exercicio)
        {
            _exercicioDao.AdicionarExercicio(exercicio);
        }
        /// <summary>
        /// Busca um exercício pelo ID.
        /// </summary>
        /// <param name="id">O ID do exercício a ser buscado.</param>
        /// <returns>O exercício encontrado.</returns>
        public Exercicio BuscarPorId(int id)
        {
            return _exercicioDao.BuscarPorId(id);
        }     
        /// <summary>
        /// Atualiza as informações de um exercício.
        /// </summary>
        /// <param name="id">O ID do exercício a ser atualizado.</param>   
        public void Atualizar(int id)
        {
            var exercicioEncontrado = _exercicioDao.BuscarPorId(id);
            _exercicioDao.AtualizarExercicio(exercicioEncontrado);
        }
        /// <summary>
        /// Busca todos os exercícios.
        /// </summary>
        /// <returns>Uma lista de todos os exercícios.</returns>
        public List<Exercicio> BuscarTodos()
        {
            return _exercicioDao.BuscaTodos();
        }
        /// <summary>
        /// Deleta um exercício pelo ID.
        /// </summary>
        /// <param name="id">O ID do exercício a ser deletado.</param>
        public void Deletar(int id)
        {
            var exercicioEncontrado = _exercicioDao.BuscarPorId(id);

            _exercicioDao.DeletarExercicio(exercicioEncontrado);
        } 
    }
}