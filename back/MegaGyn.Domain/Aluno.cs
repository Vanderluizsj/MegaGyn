using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaGyn.Domain
{
    /// <summary>
    /// Essa é uma classe que representa um aluno
    /// </summary>
    public class Aluno
    {
        /// <summary>
        /// Identificador da classe
        /// </summary> 
        public int Id { get; set; }
        /// <summary>
        /// Nome do aluno
        /// </summary> 
        public string? Nome{ get; set; }
        /// <summary>
        /// Id do treino
        /// </summary> 
        public int IdTreino{ get; set; }
        /// <summary>
        /// Lista com os treinos do aluno
        /// </summary> 
        public List<Treino>? Treinos { get; set; }
        /// <summary>
        /// Metodo para imprimir as informações do aluno
        /// </summary> 
        public override string ToString()
        {
            return $" - Aluno- \n Id:{Id}\n Nome: {Nome}\n {Treinos}";
        }


    }
}