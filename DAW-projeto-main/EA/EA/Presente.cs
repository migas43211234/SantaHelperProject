using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA
{
    /// <summary>
    /// Classe Presente
    /// Contém todos os métodos para instanciar um presente.
    /// cada presente tem um nome e um valor em euros
    /// </summary>
    public class Presente
    {
        /*Campos*/

        /// <value>
        /// String que guarda o nome do presente que criança deseja 
        /// </value>
        private string p_nomePresente;
        /// <value>
        /// Double que guarda o preço do presente que criança deseja
        /// </value>
        private double p_precoPresente;

        /*Propriedades*/

        /// <value>
        /// Propriedade do campo p_nomePresente
        /// Não recebe valores do código cliente
        /// </value>
        public string NomePresentes
        {
            get { return p_nomePresente; }
        }
        /// <value>
        /// Propriedade do campo p_precoPresente.
        ///  Não recebe valores do código cliente
        /// </value>
        public double PrecoPresente
        {
            get { return p_precoPresente; }
        }

        /*Construtor*/

        /// <summary>
        /// É o construtor da classe Presente. 
        /// Inicializa todos os campos com parâmetros obtidos pelo código cliente.
        /// </summary>
        /// <param name="nomeDosPresentes">string com informação sobre nome do presente </param>
        /// <param name="valorPresentes">double com valor de preço do presente. Inserido na Propriedade para proceder a validação</param>
        ///  ///  <returns>
        /// Um objeto da classe Presente instanciado.
        /// </returns>
        public Presente(string nomeDosPresentes, double valorPresentes)

        {
            p_nomePresente = nomeDosPresentes;
            p_precoPresente = valorPresentes;
        }
    }
}
