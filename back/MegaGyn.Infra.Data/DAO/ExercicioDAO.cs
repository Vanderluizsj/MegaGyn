using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MegaGyn.Domain;

namespace MegaGyn.Infra.Data.DAO
{
     /// <summary>
    /// Classe responsável por operações de acesso a dados relacionadas aos exercícios.
    /// </summary>
    public class ExercicioDAO
    {
         private string _connectionString = @"server=.\SQLexpress2;initial catalog=MEGA_GYN;integrated security=true;";
        /// <summary>
        /// Construtor padrão da classe ExercicioDAO.
        /// </summary>
        public ExercicioDAO()
        {
        }
        /// <summary>
        /// Adiciona um novo exercício ao banco de dados.
        /// </summary>
        /// <param name="novoExercicio">Objeto Exercicio a ser adicionado.</param>
        public void AdicionarExercicio(Exercicio novoExercicio)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"INSERT Exercicio VALUES (@Id, @NomeDoExercicio , @Series, @Repeticoes);";

                    //ADICIONANDO PARAMETROS
                    ConverterObjetoParaSql(novoExercicio, comando);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    //EXECUTA SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Retorna uma lista de todos os exercícios no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos Exercicio.</returns>
        public List<Exercicio> BuscaTodos()
        {
            var listaExercicio = new List<Exercicio>(); //CRIA LISTA

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
                        //ATRIBUI Exercicio BUSCADO
                        Exercicio exercicioBuscado = ConverterSqlParaObjeto(leitor);

                        //ADICIONA NA LISTA
                        listaExercicio.Add(exercicioBuscado);
                    }
                }
            }

            return listaExercicio;
        }
        /// <summary>
        /// Deleta um exercício do banco de dados.
        /// </summary>
        /// <param name="exercicioBuscado">Objeto Exercicio a ser deletado.</param>
        public void DeletarExercicio(Exercicio exercicioBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"DELETE FROM Exercicio WHERE Id = @ID_Exercicio;";

                    //ADICIONAR PARAMETROS
                    comando.Parameters.AddWithValue("@ID_Exercicio", exercicioBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Atualiza as informações de um exercício no banco de dados.
        /// </summary>
        /// <param name="exercicioBuscado">Objeto Exercicio com as informações atualizadas.</param>
        public void AtualizarExercicio(Exercicio exercicioBuscado)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    //CRIA SCRIPT
                    string sql = @"UPDATE Exercicio SET            
                                        NomeDoExercicio = @NOME,
                                        Series = @SERIES,
                                        Repeticoes = @REPETICOES
                                 WHERE Id = @ID_Exercicio;";

                    //ADICIONAR PARAMETROS
                    ConverterObjetoParaSql(exercicioBuscado, comando);
                    comando.Parameters.AddWithValue("@ID_Exercicio", exercicioBuscado.Id);

                    //ATRIBUIR SCRIPT
                    comando.CommandText = sql;

                    //EXECUTAR SCRIPT
                    comando.ExecuteNonQuery();
                }
            }
        }         
        /// <summary>
        /// Busca por exercícios com base em um texto de pesquisa.
        /// </summary>
        /// <param name="nome">Texto a ser usado como critério de pesquisa.</param>
        /// <returns>Lista de objetos Exercicio que correspondem ao critério de pesquisa.</returns>
        public List<Exercicio> BuscaPorTexto(string nome)
        {
            var listaExercicio = new List<Exercicio>(); //CRIA LISTA

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT Id, NomeDoExercicio, Series, Repeticoes 
                                  FROM Exercicio WHERE NomeDoExercicio LIKE @TEXTO;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@TEXTO", $"%{nome}%");

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI ALUNO BUSCADO
                        var exercicioBuscado = ConverterSqlParaObjeto(leitor);
                        //ADICIONA NA LISTA
                        listaExercicio.Add(exercicioBuscado);
                    }
                }
            }

            return listaExercicio;
        }
        /// <summary>
        /// Busca um exercício por seu ID único.
        /// </summary>
        /// <param name="id">ID único do exercício.</param>
        /// <returns>Objeto Exercicio correspondente ao ID fornecido.</returns>
        public Exercicio BuscarPorId(int id)
        {
            var exercicioBuscado = new Exercicio();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open(); //ABRIR CONEXÃO

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao; //CRIAR UM COMANDO

                    string sql = @"SELECT Id, NomeDoExercicio, Series, Repeticoes 
                                  FROM Exercicio WHERE Id = @ID_Exercicio;"; //CRIA SCRIPT

                    comando.Parameters.AddWithValue("@ID_Exercicio", id);

                    //ATRIBUIR SCRIPT 
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader(); //EXECUTA SCRIPT

                    while (leitor.Read())
                    {
                        //ATRIBUI ExercicioBUSCADO
                        exercicioBuscado = ConverterSqlParaObjeto(leitor);
                    }
                }
            }

            return exercicioBuscado;
        }
        
        private Exercicio ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var exercicio = new Exercicio();
            exercicio.Id = int.Parse(leitor["Id"].ToString());
            exercicio.NomeDoExercicio = leitor["NomeDoExercicio"].ToString();
            exercicio.Series = int.Parse(leitor["Series"].ToString());
            exercicio.Repeticoes = int.Parse(leitor["Repeticoes"].ToString());


            return exercicio;
        }

        private void ConverterObjetoParaSql(Exercicio exercicio, SqlCommand comando)
        {
            //ADICIONANDO PARAMETROS
            comando.Parameters.AddWithValue("@Id", exercicio.Id);
            comando.Parameters.AddWithValue("@NomeDoTreino", exercicio.NomeDoExercicio);
            comando.Parameters.AddWithValue("@Series", exercicio.Series);
            comando.Parameters.AddWithValue("@Repeticoes", exercicio.Repeticoes);
        }
    }
}