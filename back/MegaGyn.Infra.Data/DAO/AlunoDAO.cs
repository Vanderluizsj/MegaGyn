using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MegaGyn.Domain;

namespace MegaGyn.Infra.Data.DAO
{
    /// <summary>
    /// Classe responsável por operações de acesso a dados relacionadas aos alunos.
    /// </summary>
    public class AlunoDAO
    {
         private string _connectionString = @"server=.\SQLexpress2;initial catalog=MEGA_GYN;integrated security=true;";

        /// <summary>
        /// Construtor padrão da classe AlunoDAO.
        /// </summary>
        public AlunoDAO()
        {
        }

        /// <summary>
        /// Adiciona um novo aluno ao banco de dados.
        /// </summary>
        /// <param name="novoAluno">Objeto Aluno a ser adicionado.</param>
        public void AdicionarAluno(Aluno novoAluno)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"INSERT ALUNO VALUES (@ID, @NOME, @IDTREINO);";

                    //ADICIONANDO PARAMETROS
                    ConverterObjetoParaSql(novoAluno, comando);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    //EXECUTA SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Retorna uma lista de todos os alunos no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos Aluno.</returns>
        public List<Aluno> BuscaTodos()
        {
            var listaAluno = new List<Aluno>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME;"; //CRIA SCRIPT

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI ALUNO BUSCADO
                        Aluno alunoBuscado = ConverterSqlParaObjeto(leitor);

                        //ADICIONA NA LISTA
                        listaAluno.Add(alunoBuscado);
                    }
                }
            }

            return listaAluno;
        }
        /// <summary>
        /// Deleta um aluno do banco de dados.
        /// </summary>
        /// <param name="alunoBuscado">Objeto Aluno a ser deletado.</param>
        public void DeletarAluno(Aluno alunoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"DELETE FROM ALUNO WHERE ID = @ID_ALUNO;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@ID_ALUNO", alunoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Atualiza as informações de um aluno no banco de dados.
        /// </summary>
        /// <param name="alunoBuscado">Objeto Aluno com as informações atualizadas.</param>
        public void AtualizarAluno(Aluno alunoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE ALUNO SET            
                                        NOME = @NOME,
                                        IDTREINO = @IDTREINO
                                 WHERE ID = @ID_ALUNO;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(alunoBuscado, comando);
                    comando.Parameters.AddWithValue("@CPF_ALUNO", alunoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }         
        /// <summary>
        /// Busca por alunos com base em um texto de pesquisa.
        /// </summary>
        /// <param name="nome">Texto a ser usado como critério de pesquisa.</param>
        /// <returns>Lista de objetos Aluno que correspondem ao critério de pesquisa.</returns>
        public List<Aluno> BuscaPorTexto(string nome)
        {
            var listaAluno = new List<Aluno>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME, IDTREINO 
                                  FROM ALUNO WHERE NOME LIKE @TEXTO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@TEXTO", $"%{nome}%");

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI ALUNO BUSCADO
                        var alunoBuscado = ConverterSqlParaObjeto(leitor);
                        //ADICIONA NA LISTA
                        listaAluno.Add(alunoBuscado);
                    }
                }
            }

            return listaAluno;
        }
        /// <summary>
        /// Busca um aluno por seu ID único.
        /// </summary>
        /// <param name="id">ID único do aluno.</param>
        /// <returns>Objeto Aluno correspondente ao ID fornecido.</returns>
        public Aluno BuscarPorId(int id)
        {
            var alunoBuscado = new Aluno();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT ID, NOME, IDTREINO 
                                  FROM ALUNO WHERE ID = @ID_ALUNO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@ID_ALUNO", id);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI ALUNO BUSCADO
                        alunoBuscado = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return alunoBuscado;
        }

        private Aluno ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var aluno = new Aluno();
            aluno.Id = int.Parse(leitor["ID"].ToString());
            aluno.Nome = leitor["NOME"].ToString();
            aluno.IdTreino = int.Parse(leitor["IDTREINO"].ToString());

            return aluno;
        }

        private void ConverterObjetoParaSql(Aluno aluno, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
            comando.Parameters.AddWithValue("@ID", aluno.Id);
            comando.Parameters.AddWithValue("@NOME", aluno.Nome);
            comando.Parameters.AddWithValue("@IDTREINO", aluno.IdTreino);
        }
    }
}