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
    /// Implementação do repositório de alunos.
    /// </summary>
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoDAO _alunoDao;
        /// <summary>
        /// Construtor padrão que inicializa o AlunoDAO.
        /// </summary>
        public AlunoRepository()
        {
            _alunoDao = new AlunoDAO();
        }
        /// <summary>
        /// Adiciona um novo aluno.
        /// </summary>
        /// <param name="aluno">O aluno a ser adicionado.</param>
        public void Adicionar(Aluno aluno)
        {
            _alunoDao.AdicionarAluno(aluno);
            
        }
        /// <summary>
        /// Busca todos os alunos.
        /// </summary>
        /// <returns>Uma lista de todos os alunos.</returns>
        public List<Aluno> BuscarTodos()
        {
            return _alunoDao.BuscaTodos();
        }
        /// <summary>
        /// Busca um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno a ser buscado.</param>
        /// <returns>O aluno encontrado.</returns>
        public Aluno BuscarPorId(int id)
        {          

            return _alunoDao.BuscarPorId(id);
        }
        /// <summary>
        /// Atualiza as informações de um aluno.
        /// </summary>
        /// <param name="id">O ID do aluno a ser atualizado.</param>        
        public void Atualizar(int id)
        {
            var alunoEncontrado = _alunoDao.BuscarPorId(id);
            _alunoDao.AtualizarAluno(alunoEncontrado);
        }
        
        /// <summary>
        /// Deleta um aluno pelo ID.
        /// </summary>
        /// <param name="id">O ID do aluno a ser deletado.</param>
        public void Deletar(int id)
        {
            var alunoEncontrado = _alunoDao.BuscarPorId(id);

            _alunoDao.DeletarAluno(alunoEncontrado);
        }
        
    }

}