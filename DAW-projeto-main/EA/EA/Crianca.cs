namespace EA
{
    /// <summary>
    /// classe mãe.
    ///  Contém todos os métodos para instanciar uma criança.
    ///  Instancia crianças normais.
    ///  Existe um conjunto de propriedades que caracterizam qualquer criança, como sejam:
    ///  o nome da criança, a sua idade, morada, se a criança deseja o serviço de entrega expresso,
    ///  uma lista de 5 presentes desejados(cada presente tem um nome e um valor em euros),
    ///  valor em euros alocado à criança para presentes, número de pontos de mau comportamento no cadastro da criança,
    ///  número de vezes que foi apanhada a mentir, e se a criança vai para a cama a horas.
    /// </summary>
    public class Crianca
    {
        /*Campos*/

        /// <value>
        /// string que guarda nome da crianca.
        /// </value>
        private string c_nome;
        /// <value>
        ///integer que guarda idade da crianca.
        /// </value>
        private int c_idade;
        /// <value>
        /// string que guarda morada da criança.
        /// </value>
        private string c_morada;
        /// <value>
        /// booleano que guarda se criança deseja serviço expresso (entrega 2 horas antes da meia noite) ou não.
        /// </value>
        private bool c_servicoExpresso;
        /// <value>
        ///array  que guarda valores da classe Presente.Cada Presente tem como parâmetros: nome e valor.
        /// </value>
        private Presente[] c_presentesDesejados;
        /// <value>
        ///double que guarda plafond que criança tem ao ser instanciada.
        /// </value>
        ///  <remarks>
        /// É diferente em cada classe derivada pelo que é protected.
        /// </remarks>
        protected double c_plafondPresentes;
        /// <value>
        /// integer que guarda os pontos de mau comportamento que crianca recebe por cada mau comportamento.
        /// </value>
        protected int c_pontosMauComportamento;
        /// <value>
        /// integer que guarda número de mentiras que a criança diz.
        /// </value>
        /// <remarks>
        ///Alterado na classe irritante pelo que é protected.
        ///</remarks>
        protected int c_numeroMentiras;
        /// <value>
        /// booleano que guarda se crianca vai para cama a horas ou não.
        /// </value>
        private bool c_camaHoras;
        /// <value>
        ///booleano que guarda se crianca cumpriu ou nao o castigo.
        /// </value>
        /// <remarks>
        ///Apenas alterado pelo método.
        /// </remarks>
        private bool c_cumprirCastigo;
        /// <value>
        ///integer que guarda registo de cópias.
        /// </value>
        /// <remarks>
        /// Apenas alterado pelo método.
        ///</remarks>
        private int c_registoCopias;

        /*Propriedades*/
        /// <value>
        /// Propriedade do campo c_nome.
        /// Não recebe valores do código cliente
        /// </value>
        public string Nome
        {
            get { return c_nome; }
        }
        /// <value>
        /// Propriedade do campo c_idade.
        /// Permite inserir valores a partir de código cliente
        /// Valida a idade introduzida pelo código cliente, respeitando >=0 e <18
        /// </value>
        public int Idade
        {
            get { return c_idade; }
            set { if (value >= 0 && value < 18) c_idade = value; }
        }
        /// <value>
        /// Propriedade do campo c_morada
        ///  Não recebe valores do código cliente
        /// </value>
        public string Morada
        {

            get { return c_morada; }
            set { c_morada = value; }
        
        }
        /// <value>
        /// Propriedade do campo c_servicoExpresso
        /// Permite inserir valores a partir de código cliente
        /// </value>
        public bool ServicoExpresso
        {
            get { return c_servicoExpresso; }
            set { c_servicoExpresso = value; }
        }
        /// <value>
        /// Propriedade do campo c_presentesDesejados.
        /// Permite inserir valores a partir de código cliente.
        /// </value>
        public Presente[] PresentesDesejados
        {
            get { return c_presentesDesejados; }
            set { c_presentesDesejados = value; }
        }
        /// <value>
        /// Propriedade do campo c_plafondPresentes
        ///  Não recebe valores do código cliente
        /// </value>
        public double PlafondPresentes
        {
            get { return c_plafondPresentes; }
        }
        /// <value>
        ///Propiedade do campo c_pontosMauComportamento
        ///  Não recebe valores do código cliente
        /// </value>
        public int PontosMauComportamento
        { get { return c_pontosMauComportamento; } }
        /// <value>
        ///Propriedade do campo c_numero Mentiras
        /// Permite inserir valores a partir de código cliente
        /// Valida a número de mentiras introduzido pelo código cliente, respeitando >=0
        /// </value>
        public int NumeroMentiras//valida o número de mentiras introduzido
        {
            get { return c_numeroMentiras; }
            set { if (c_numeroMentiras >= 0) c_numeroMentiras = value; }
        }
        /// <value>
        /// Propriedade do campo c_CamaHoras
        /// Permite inserir valores a partir de código cliente.
        /// </value>
        public bool CamaHoras
        {
            get { return c_camaHoras; }
            set { c_camaHoras = value; }
        }
        /// <value>
        ///Propiedade do campo c_cumprirCastigo
        ///  Não recebe valores do código cliente
        /// </value>
        public bool CumprirCastigo
        {
            get { return c_cumprirCastigo; }
        }
        /// <value>
        /// Propriedade do campo c_registoCopias
        /// Recebe valores de código cliente e são validados de forma a serem >=0
        /// </value>
        public int RegistoCopias
        {
            get { return c_registoCopias; }
            set { if (c_registoCopias >= 0) c_registoCopias = value; }
        }

        /*Construtor*/

        /// <summary>
        /// É o construtor da classe Crianca. 
        /// Inicializa todos os campos e quando dados validados inicializa através de Propriedades
        /// </summary>
        /// <param name="nome">string com informação sobre nome da criança </param>
        /// <param name="idade">integer com informação sobre idade da criança. é validada pela Propriedade</param>
        /// <returns>
        /// Um objeto da classe Crianca instanciado.
        /// </returns>
        public Crianca(string nome, int idade)
        {
            c_nome = nome;// as per enunciado - obtido a partir de código cliente.
            Idade = idade;// as per enunciado - obtido a partir de código cliente. utiliza propriedade para proceder a validação de idade 
            c_morada = "";//inicializa com string vazia.
            c_servicoExpresso = false;//Enunciado: por defeito as crianças não querem serviço expresso
            c_plafondPresentes = 20; //Enunciado: valores distintos para cada classe derivada.
            c_pontosMauComportamento = 0;//inicializa a zero  
            NumeroMentiras = 0;//inicializa a zero.
            c_camaHoras = true; //Por defeito crianças vão para cama a horas.
            c_cumprirCastigo = false;//inicializa sem castigos cumpridos
            c_presentesDesejados = new Presente[5];//inicializa o array com 5 posições e valores a null.
            RegistoCopias = 0;//inicializa a zero.
        }

        /*Métodos*/

        /// <summary>
        /// Método que insere um presente no array PresentesDesejados[] através do construtor da classe Presente, Há overloading de método. 
        /// ///Preenche o array (previamente criado a null pelo construtor) na  posição definida pelo código cliente.
        /// </summary>
        /// <param name="posPresente">integer que define a posição do array onde presente vai ser inserido</param>
        /// <param name="nomePresente">string nome do presente a inserir no construtor Presente e guardado no array</param>
        /// <param name="precoPresente">double preço do presente a inserir no construtor Presente e guardado no array</param>
        /// <returns>
        /// Não devolve qualquer valor (função void)
        /// </returns>
        public void IntroduzirPresente(int posPresente, string nomePresente, double precoPresente)
        {
            Presente desejo = new Presente(nomePresente, precoPresente);
            PresentesDesejados[posPresente] = desejo;
        }
        /// <summary>
        /// Método que insere um presente no array PresentesDesejados[] através do construtor da classe Presente, Há overloading de método. 
        ///Preenche o array (previamente criado a null pelo construtor) na primeira posição não null disponível no array.
        /// Usa informação obtida a partir de parâmetros inseridos pelo código cliente (posição do array, nome e preço).
        /// </summary>
        /// <param name="nomePresente">string nome do presente a inserir no construtor Presente e guardado no array</param>
        /// <param name="precoPresente">double preço do presente a inserir no construtor Presente e guardado no array</param>
        /// <returns>
        /// Não devolve qualquer valor (função void)
        /// </returns>
        public void IntroduzirPresente(string nomePresente, double precoPresente)
        {
            for (int i = 0; i < 5; i++)
            {
                if (PresentesDesejados[i] == null)
                {
                    Presente desejo = new Presente(nomePresente, precoPresente);
                    PresentesDesejados[i] = desejo;
                    break;
                }
            }
        }
        /// <summary>
        /// Calcula o plafond base que a criança tem direito
        /// </summary>
        /// <returns>
        /// Devolve o valor (double) do PlafondBase a que cada criança tem direito 
        /// </returns>
        public double PlafondBase()
        { return PlafondPresentes + 30; }
        /// <summary>
        /// Calcula o plafond efetivo a que a criança tem direito considerando a taxa obrigatória decorrente da despesa com renas e
        /// taxa opcional referente ao serviço expresso.
        /// É virtual para permitir alterações nas classes derivadas
        /// </summary>
        /// <returns>
        /// Devolve o valor (double) de plafond efectivo a que as crianças têm direito
        /// </returns>
        public virtual double PlafondEfectivo()
        {
            if (ServicoExpresso == true)
                return PlafondBase() - 3.99 - 15;
            else
                return PlafondBase() - 3.99;
        }
        /// <summary>
        /// Calcula se criança é bem comportada considerando se vai para cama a horas e número de mentiras que diz.
        /// Incrementa, em caso de mau comportamento, os pontos de mau comportamento.
        /// É virtual para permitir alterações nas classes derivadas
        /// </summary>
        /// <returns>
        /// Devolve se a criança é bem comportada (true) ou não (false) (valor booleano).
        /// </returns>
        public virtual bool BemComportada()
        {
            if (CamaHoras == false || NumeroMentiras > 3)
            {
                c_pontosMauComportamento++;
                c_numeroMentiras = 0;
                return false;
            }
            else
            {
                c_numeroMentiras = 0;
                return true;
            }
        }
        /// <summary>
        /// Calcula se criança está ou não de castigo baseando-se no número de pontos de mau comportamento
        /// Método não acessível pelo código cliente
        /// </summary>
        /// <returns>
        /// Devolve se criança (true) ou não (false) de castigo (valor booleano).
        /// </returns>
        protected bool Castigo()
        {
            if (PontosMauComportamento > 3)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Calcula se criança é ou não contemplada com noite mágica.
        /// Caso receba noite mágica recebe um postal a dizer "HOHOHO" e não prendas
        /// É virtual para permitir que classes derivadas alterem método.
        /// </summary>
        /// <returns>
        /// Devolve se criança é (true) ou não (false) contemplada com noite mágica (valor booleano)
        /// </returns>
        public virtual bool ContempladaComNoiteMagica()
        {
            if (Castigo() == true)
                return true;
            return false;
        }
        /// <summary>
        /// Adiciona uma cópia ao número de cópias realizadas e regista se castigo foi ou não cumprido. Há overloading de método.
        /// Invoca método CumprimentoCastigos(int numerCopias)
        /// </summary>
        /// <return>
        /// Não devolve qualquer valor (função void)
        /// </return>
        public void CumprimentoCastigos()
        {
            CumprimentoCastigos(1);
        }
        /// <summary>
        /// Adiciona o número de cópias inserido pelo parâmetro dafunção ao número de cópias realizadas e regista se castigo foi ou não cumprido. Há overloading de método.
        /// </summary>
        /// <param name="numerCopias"> integer referente ao número de cópias inseridas pelo código cliente e que soma ao registo de cópias</param>
        /// <return>
        /// Não devolve qualquer valor (função void)
        /// </return>
        public void CumprimentoCastigos(int numerCopias)
        {
            if (Castigo() == true)
            {
                c_registoCopias += numerCopias;

                if (c_registoCopias >= 10)
                {
                    c_cumprirCastigo = true;
                    c_registoCopias = 0;
                }
                else c_cumprirCastigo = false;
            }
        }
        /// <summary>
        /// Calcula se o mau comportamento foi (true) ou não(false) desculpado.
        /// Permite que se desculpe apenas crianças castigadas e que tenham cumprido o castigo
        /// Coloca a zero o número de pontos de mau comportamento após castigo desculpado
        /// </summary>
        /// <returns>
        /// Devolve se criança foi(true) ou não (false) desculpada (valor booleano)
        /// </returns>
        public bool DesculparMauComportamento()
        //calcula e indica se o mau comportamento foi desculpado retirando ou não castigo caso castigo tenha sido cumprido
        {
            if (Castigo() == true && c_cumprirCastigo == true)
            {
                c_plafondPresentes = c_plafondPresentes - 10;
                c_pontosMauComportamento = 0;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Calcula qual a mensagem personalizada a imprimir no postal de Natal
        /// </summary>
        /// <returns>
        /// Devolve uma string contendo mensagem com informação sobre nome, presentes oferecidos (se aplicavel), cheque-oferta (quando PlafondEfetivo insuficiente),
        ///montante a pagar ( quando PlafondEfetivo negativo), HoHoHo (quando Noite Mágica aplicável).
        /// </returns>
        public string OferecerPresentes()
        {
            string postalFinal = "";
            double plafondEfectivo, calculoPresentes, cheque;

            plafondEfectivo = PlafondEfectivo();
            calculoPresentes = CalcularPresentes();
            postalFinal = "Olá " + Nome + "";

            if (plafondEfectivo < 0)
            {
                postalFinal += ", vais ter de pagar este valor: " + plafondEfectivo + "€";

                if (ContempladaComNoiteMagica() == true)
                {
                    postalFinal += "€. Oh Oh Oh! ;)";
                }
                else
                {
                    postalFinal += "€.";
                }
            }
            else if (ContempladaComNoiteMagica() == true)
            {
                postalFinal += ", a tua prenda é este postal: Oh Oh Oh! ;)";
            }
            else if (plafondEfectivo >= calculoPresentes && PresentesDesejados[0] != null)
            {
                string listaPresentes = "";

                for (int i = 0; i < 5; i++)
                {
                    if (PresentesDesejados[i] != null)
                    {
                        listaPresentes += PresentesDesejados[i].NomePresentes + " ";
                    }
                }
                postalFinal += ", vais receber os seguintes presentes: " + listaPresentes + ".";
            }
            else if (PresentesDesejados[0] != null)
            {
                if (plafondEfectivo > PresentesDesejados[0].PrecoPresente)
                {
                    cheque = plafondEfectivo - PresentesDesejados[0].PrecoPresente;
                    postalFinal += ", vais receber " + PresentesDesejados[0].NomePresentes + " e um cheque-oferta de " + cheque + "€!";
                }
                else
                {
                    cheque = plafondEfectivo;
                    postalFinal += ", vais receber um cheque-oferta de " + cheque + "€!";
                }
            }
            else
            {
                cheque = plafondEfectivo;
                postalFinal += ", vais receber um cheque-oferta de " + cheque + "€!";
            }
            return postalFinal;
        }
        /// <summary>
        /// Calcula o somatório dos preços dos presentes desejados pela criança e que constam no array PresentesDesejados[]
        /// Função private pois apenas é usada na classe Crianca
        /// </summary>
        /// <returns>
        /// Devolve o valor (double) do somatório dos preços dos presentes desejados pela criança
        /// </returns>
        private double CalcularPresentes()
        {
            double totalPresentes = 0;

            for (int i = 0; i < 5; i++)
            {
                if (PresentesDesejados[i] != null)
                {
                    totalPresentes += PresentesDesejados[i].PrecoPresente;
                }
            }
            return totalPresentes;
        }
    }
}