using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MegaGyn.Domain;

namespace MegaGyn.Infra.Data.DAO
{
    /// <summary>
    /// Classe responsável por operações de acesso a dados relacionadas aos treinos.
    /// </summary>
    public class TreinoDAO
    {
         private string _connectionString = @"server=.\SQLexpress2;initial catalog=MEGA_GYN;integrated security=true;";
        /// <summary>
        /// Construtor padrão da classe TreinoDAO.
        /// </summary>
        public TreinoDAO()
        {
        }
        /// <summary>
        /// Adiciona um novo treino ao banco de dados.
        /// </summary>
        /// <param name="novoTreino">Objeto Treino a ser adicionado.</param>
        public void AdicionarTreino(Treino novoTreino)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"INSERT Treino VALUES (@Id, @NomeDoTreino, @IdExercicio);";

                    //ADICIONANDO PARAMETROS
                    ConverterObjetoParaSql(novoTreino, comando);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    //EXECUTA SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
         /// <summary>
        /// Retorna uma lista de todos os treinos no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos Treino.</returns>
        public List<Treino> BuscaTodos()
        {
            var listaTreino = new List<Treino>(); //CRIA LISTA

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
                        //ATRIBUI Treino BUSCADO
                        Treino treinoBuscado = ConverterSqlParaObjeto(leitor);

                        //ADICIONA NA LISTA
                        listaTreino.Add(treinoBuscado);
                    }
                }
            }

            return listaTreino;
        }
        /// <summary>
        /// Deleta um treino do banco de dados.
        /// </summary>
        /// <param name="treinoBuscado">Objeto Treino a ser deletado.</param>
        public void DeletarTreino(Treino treinoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"DELETE FROM Treino WHERE Id = @ID_Treino;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@ID_Treino", treinoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Atualiza as informações de um treino no banco de dados.
        /// </summary>
        /// <param name="treinoBuscado">Objeto Treino com as informações atualizadas.</param>
        public void AtualizarTreino(Treino treinoBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE Treino SET            
                                        NomeDoTreino = @NomeDoTreino,
                                        IdExercicio = @IdExercicio
                                 WHERE Id = @Id_Treino;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(treinoBuscado, comando);
                    comando.Parameters.AddWithValue("@Id", treinoBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }         
        /// <summary>
        /// Busca por treinos com base em um texto de pesquisa.
        /// </summary>
        /// <param name="nome">Texto a ser usado como critério de pesquisa.</param>
        /// <returns>Lista de objetos Treino que correspondem ao critério de pesquisa.</returns>
        public List<Treino> BuscaPorTexto(string nome)
        {
            var listaTreino = new List<Treino>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT Id, NomeDoTreino, IdExercicio
                                  FROM Treino WHERE NomeDoTreino LIKE @TEXTO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@TEXTO", $"%{nome}%");

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI Treino BUSCADO
                        var treinoBuscado = ConverterSqlParaObjeto(leitor);
                        //ADICIONA NA LISTA
                        listaTreino.Add(treinoBuscado);
                    }
                }
            }

            return listaTreino;
        }
        /// <summary>
        /// Busca um treino por seu ID único.
        /// </summary>
        /// <param name="id">ID único do treino.</param>
        /// <returns>Objeto Treino correspondente ao ID fornecido.</returns>
        public Treino BuscarPorId(int id)
        {
            var treinoBuscado = new Treino();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT Id, NomeDoTreino, IdExercicio 
                                  FROM Treino WHERE Id = @ID_Treino;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@ID_Treino", id);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI treino BUSCADO
                        treinoBuscado = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return treinoBuscado;
        }

        private Treino ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var treino = new Treino();
            treino.Id = int.Parse(leitor["Id"].ToString());
            treino.NomeDoTreino = leitor["NomeDoTreino"].ToString();
            treino.IdExercicio = int.Parse(leitor["IdExercicio"].ToString());

            return treino;
        }

        private void ConverterObjetoParaSql(Treino treino, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
            comando.Parameters.AddWithValue("@Id", treino.Id);
            comando.Parameters.AddWithValue("@NomeDoTreino", treino.NomeDoTreino);
            comando.Parameters.AddWithValue("@IdExercicio", treino.IdExercicio);
        }
    }
}