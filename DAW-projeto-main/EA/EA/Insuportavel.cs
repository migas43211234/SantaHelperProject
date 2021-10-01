using System;

namespace EA
{
    /// <summary>
    ///classe derivada da classe Irritante.
    /// Instancia criança insuportavel.
    ///  Para as crianças insuportáveis armazena-se ainda, para além de propriedades de crianca e irritantes, se a criança diz palavrões.
    /// </summary>
    class Insuportavel : Irritante
    {
        /*Campos*/

        /// <value>
        /// booleano que guarda se criança diz ou não palavrões
        /// </value>
        private bool in_palavroes;

        /*Propriedades*/
        /// <value>
        /// Propriedade do campo in_palavroes
        ///Permite receber valores a partir de código cliente
        /// </value>
        public bool Palavroes
        {
            get { return in_palavroes; }
            set { in_palavroes = value; }
        }
        /*Construtor*/
        /// <summary>
        /// /// Construtor da classe irritante. Há overload com outros construtor.
        ///Inicializa os campos c_plafondPresentes com valor distinto de classe Crianca
        ///inicializa campo específico da classe com valor obtido a partir do código cliente
        /// </summary>
        /// <param name="nome"> string com informação sobre nome da criança. Herda da base classe mãe Crianca </param>
        /// <param name="idade">integer com informação sobre idade da criança. é validada pela Propriedade. Herda da Base classe mãe Crianca</param>
        /// <param name="numBirras">integer com informação sobre número de birras. É validado pela Propriedade. Herda da base classe mãe irritante</param>
        /// <param name="mediaDasBirras">double com informação sobre duração média de birras. É validado pela Propriedade. Herda da base classe mãe irritante</param>
        ///  <returns>
        /// Um objeto da classe Insuportavel instanciado.
        /// </returns>
        public Insuportavel(string nome, int idade, int numBirras, double mediaDasBirras) : base(nome, idade, numBirras, mediaDasBirras)
        {
            c_plafondPresentes = 0;
            in_palavroes = true;
        }
        /// <summary>
        ///Construtor da classe insuportável. Há overload com outros construtor.
        ///Inicializa os campos c_plafondPresentes com valor distinto de classe mãe
        ///inicializa Número de Birras com valores obtidos a partir do código cliente´.
        ///Média de birras inicializado com valor definido no construtor.
        /// </summary>
        /// <param name="nome"> string com informação sobre nome da criança. Herda da base classe mãe Crianca </param>
        /// <param name="idade">integer com informação sobre idade da criança. É validada pela Propriedade. Herda da Base classe mãe Crianca</param>
        /// <param name="numBirras">integer com informação sobre número de birras. É validado pela Propriedade.erda da base classe mãe irritante</param>
        /// <returns>
        /// Um objeto da classe Insuportavel instanciado.
        /// </returns>
        public Insuportavel(string nome, int idade, int numBirras) : base(nome, idade, numBirras)
        {
            c_plafondPresentes = 0;
            in_palavroes = true;
        }

        /*Métodos*/
        /// <summary>
        /// Calcula o plafond efetivo a que a criança tem direito considerando a taxa obrigatória decorrente da despesa com renas,
        /// taxa opcional referente ao serviço expresso e idade da crianca.
        /// É override pois é distinto da classe mãe
        /// </summary>
        /// <returns>
        /// Devolve o valor (double) de plafond efectivo a que as crianças têm direito
        /// </returns>
        public override double PlafondEfectivo()
        {
            double valorDeduzir = 2 * Idade;
            return base.PlafondEfectivo() - valorDeduzir;
        }
        /// <summary>
        /// Calcula se criança é ou não contemplada com Noite Magica. É override
        ///Se criança é contemplada com noite mágica recebe postal "HoHoHo" e não prendas
        /// </summary>
        /// <returns>
        /// Devolve se crianca irritante é ou não contemplada com noite mágica. Valor booleano.</returns>
        public override bool ContempladaComNoiteMagica()
        {
            if (Castigo() == true || Palavroes == true)
                return true;
            return false;
        }

    }
}

