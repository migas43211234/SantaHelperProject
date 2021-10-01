namespace EA
{

    /// <summary>
    /// classe derivada da classe mãe Crianca.
    /// Instancia criança fofinha.
    /// Além de todas as propriedades de crianca para fofinhas guarda-se ainda informação sobre se a criança arruma o quarto e se come a sopa toda.
    /// </summary>
    class Fofinha : Crianca
    {
        /*Campos*/

        /// <value>
        /// booleano que guarda se crianca arruma ou nao o quarto.
        /// </value>
        private bool f_arrumaQuarto;
        /// <value>
        /// booleano que guarda se crianca come ou não a sopa toda.
        /// </value>
        private bool f_comeSopa;

        /*Propriedades*/
        /// <value>
        ///Propriedade do campo f_arrumaQuarto.
        ///Permite receber valores a partir de código cliente
        /// </value>
        public bool ArrumaQuarto
        {
            get { return f_arrumaQuarto; }
            set { f_arrumaQuarto = value; }
        }
        /// <value>
        ///Propriedade do campo f_comeSopa.
        ///Permite receber valores a partir de código cliente
        /// </value>
        public bool ComeSopa
        {
            get { return f_comeSopa; }
            set { f_comeSopa = value; }
        }

        /*Construtor*/

        /// <summary>
        /// Construtor da classe fofinha
        ///Inicializa os campos c_plafondPresentes com valor distinto de classe mãe
        ///inicializa campos específicos da classe com true
        /// </summary>
        /// <param name="nome"> string com informação sobre nome da criança. Herda da base classe mãe Crianca </param>
        /// <param name="idade">integer com informação sobre idade da criança. é validada pela Propriedade. Herda da Base classe mãe Crianca</param>
        /// <return>
        /// Um objeto da classe fofinha instanciado.
        /// </return>
        public Fofinha(string nome, int idade) : base(nome, idade)
        {
            c_plafondPresentes = 40;
            f_arrumaQuarto = true;
            f_comeSopa = true;
        }

        /*Metodos*/

        /// <summary>
        /// Calcula se Crianca é bom comportada.É override.
        /// utiliza base de classe mãe Crianca e considera campos específicos da classe derivada
        /// </summary>
        /// <returns>
        /// Devolve se criança é (true) ou não (false) bem comportada (Valor Booleano).
        /// </returns>
        public override bool BemComportada()
        {
            if (base.BemComportada() == false)
            {
                return false;
            }
            else
            {
                if (ComeSopa == false && ArrumaQuarto == false)
                {
                    c_pontosMauComportamento++;
                    return false;
                }
                else return true;
            }
        }
        /// <summary>
        /// Calcula se criança é ou não contemplada com Noite Magica. É override
        ///Se criança é contemplada com noite mágica recebe postal "HoHoHo" e não prendas
        /// Considera que Fofinhas nunca têm Noite Mágica.
        ///  </summary>
        /// <returns>
        /// Devolve valor sempre false para contemplada com noite mágica por ser da classe fofinha pois nunca tem noite mágica. (Valor booleano).</returns>
        public override bool ContempladaComNoiteMagica()
        {
            return false;
        }
    }
}
