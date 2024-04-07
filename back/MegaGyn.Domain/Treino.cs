using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaGyn.Domain
{
    /// <summary>
    /// Essa é uma classe que representa um treino
    /// </summary>
    public class Treino
    {
        /// <summary>
        /// Identificador da classe
        /// </summary> 
        public int Id { get; set; }
        /// <summary>
        /// Nome do treino
        /// </summary> 
        public string? NomeDoTreino { get; set; }
         /// <summary>
        /// Id do exercicio
        /// </summary> 
        public int IdExercicio{ get; set; }
        /// <summary>
        /// Lista com os exercicios do treino
        /// </summary>
        public List<Exercicio>? Exercicios { get; set; }
        /// <summary>
        /// Metodo para imprimir as informações do treino
        /// </summary> 
        public override string ToString()
        {
            return $" - Treino - \n Id:{Id}\n Nome: {NomeDoTreino}\n {Exercicios}";
        }


    }
}