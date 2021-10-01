namespace EA
{
    /// <summary>
    ///classe derivada da classe mãe Crianca.
    /// Instancia criança irritante.
    /// crianças irritantes e às crianças insuportáveis,
    /// armazena-se o número de birras que a criança fez e a duração média de cada birra em minutos.
    /// </summary>
    public class Irritante : Crianca
    {
        /*Campos*/
        /// <value>
        /// integer que guarda número de birras da criança.
        /// </value>
        private int ir_numeroBirras;
        /// <value>
        ///double que guarda duração média das birras da criança.
        /// </value>
        private double ir_mediaBirras;

        /*Propriedades*/
        /// <value>
        /// Propriedade do campo ir_numeroBirras
        ///Permite receber valores a partir de código cliente e valida o número de birras introduzido >=0
        /// </value>
        public int NumeroBirras//valida o número de birras introduzida
        {
            get { return ir_numeroBirras; }
            set { if (ir_numeroBirras >= 0) ir_numeroBirras = value; }
        }
        /// <value>
        /// Propriedade do campo ir_mediaBirras
        ///Permite receber valores a partir de código cliente e valida a duração média de birras introduzida >=0
        /// </value>
        public double MediaBirras
        {
            get { return ir_mediaBirras; }
            set { if (ir_mediaBirras >= 0) ir_mediaBirras = value; }
        }

        /*Construtor*/
        /// <summary>
        // <summary>
        /// Construtor da classe irritante. Há overload com outros construtor.
        ///Inicializa os campos c_plafondPresentes com valor distinto de classe mãe
        ///inicializa campos específicos da classe com valores obtidos a partir do código cliente
        /// </summary>
        /// <param name="nome"> string com informação sobre nome da criança. Herda da base classe mãe Crianca </param>
        /// <param name="idade">integer com informação sobre idade da criança. é validada pela Propriedade. Herda da Base classe mãe Crianca</param>
        /// <param name="numBirras">integer com informação sobre número de birras. É validado pela Propriedade</param>
        /// <param name="mediaDasBirras">double com informação sobre duração média de birras. É validado pela Propriedade</param>
        public Irritante(string nome, int idade, int numBirras, double mediaDasBirras) : base(nome, idade)
        {
            c_plafondPresentes = 10;
            NumeroBirras = numBirras;//utiliza propriedade para proceder a validação de Número de Birras  
            MediaBirras = mediaDasBirras;//utiliza propriedade para proceder a validação de média de Birras
        }
        /// <summary>
        ///Construtor da classe irritante. Há overload com outros construtor.
        ///Inicializa os campos c_plafondPresentes com valor distinto de classe mãe
        ///inicializa Número de Birras com valores obtidos a partir do código cliente´.
        ///Média de birras inicializado com valor definido no construtor.
        /// </summary>
        /// <param name="nome"> string com informação sobre nome da criança. Herda da base classe mãe Crianca </param>
        /// <param name="idade">integer com informação sobre idade da criança. É validada pela Propriedade. Herda da Base classe mãe Crianca</param>
        /// <param name="numBirras">integer com informação sobre número de birras. É validado pela Propriedade</param>
        /// /// <returns>
        /// Um objeto da classe Irritante instanciado.
        /// </returns>
        public Irritante(string nome, int idade, int numBirras) : base(nome, idade)
        {
            c_plafondPresentes = 10;
            NumeroBirras = numBirras;
            MediaBirras = 30;
        }

        /*Métodos*/

        /// <summary>
        /// Calcula se Crianca é bem comportada.É override.
        /// Invoca base de classe mãe Crianca e considera campos específicos da classe derivada
        /// </summary>
        /// <returns>
        /// Devolve se criança é (true) ou não(false) bem comportada. (Valor Booleano)
        /// </returns>
        public override bool BemComportada()
        {
            bool bomComportamento = false;
            if (base.BemComportada() == false)
            {
                bomComportamento = false;

            }
            else
            {
                if (MediaBirras > 120)
                {
                    c_pontosMauComportamento++;
                    bomComportamento = false;
                }
                else
                {
                    bomComportamento = true;
                }
            }
            NumeroBirras = 0;
            MediaBirras = 0;
            return bomComportamento;
        }
        /// <summary>
        /// Calcula se criança é ou não contemplada com Noite Magica. É override
        ///Se criança é contemplada com noite mágica recebe postal "HoHoHo" e não prendas
        /// Invoca base de classe mãe Crianca e considera campos específicos da classe derivada
        ///  </summary>
        /// <returns>
        /// Devolve se crianca irritante é (true) ou não (false) contemplada com noite mágica. (Valor booleano).</returns>
        public override bool ContempladaComNoiteMagica()
        {
            if (base.ContempladaComNoiteMagica() == true)
                return true;
            else
            {
                if (Idade > 6)
                    return true;
            }
            return false;
        }
    }
}

