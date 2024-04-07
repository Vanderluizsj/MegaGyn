using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaGyn.Domain
{
    /// <summary>
    /// Essa é uma classe que representa um exercicio
    /// </summary>
    public class Exercicio
    {
        /// <summary>
        /// Identificador da classe
        /// </summary> 
        public int Id { get; set; }
        /// <summary>
        /// Nome do exercicio
        /// </summary>
        public string? NomeDoExercicio { get; set; }
        /// <summary>
        /// Numero de series do exercicio
        /// </summary>
        public int Series { get; set; }
        /// <summary>
        /// Numero de repetições de cada serie
        /// </summary>
        public int Repeticoes { get; set; }

        /// <summary>
        /// Metodo para imprimir as informações do objeto 
        /// </summary>
        public override string ToString()
        {
            return $" - Exercicio - \n Id:{Id} \n Nome: {NomeDoExercicio}\t Series: {Series}\t Repetições: {Repeticoes}";
        }
    }
}