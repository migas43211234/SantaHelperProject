using System;
using System.Windows.Forms;
using WMPLib;

namespace EA
{
    /// <summary> 
    /// Objetivo:sistema de informação de suporte ao trabalho do Pai Natal, capaz de o apoiar na selecção e atribuição de presentes às crianças de todo o mundo.
    /// A Aplicação é capaz de lidar com tipo de criancas normais, fofinhas, irritantes e insuportáveis.
    /// Form com 4 tabs: inserir crianca, inserir presentes, avaliar comportamento e castigos e Alterar Dados/Postal de Natal
    /// Se outros tipos forem criados deve proceder-se à atualização da app 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Música de abertura da app
        /// </summary>
        WindowsMediaPlayer introSong = new WindowsMediaPlayer();
        /// <summary>
        /// Cria array com 10 crianças de qualquer tipo - Polimorfismo. 
        /// Caso se pretenda alterar número de posições do array tem de se rever mensagens/funcionalidade dos métodos/botoes
        /// </summary>
        Crianca[] criancas = new Crianca[10];
        /// <value>
        /// integer que guarda posição no indice em que crianca é guardada.
        /// É variavel global para permitir funcionamento do painel inserir crianca
        /// </value>
        int indice;
        /// <value>
        ///  integer que guarda posição no indice em que crianca está guardada.
        /// É variavel global para permitir funcionamento do painel alterar dados
        /// </value>
        int indiceAlterarDados;
        /// <value>
        ///  integer que guarda posição no indice em que presente está guardado.
        /// É variavel global para permitir funcionamento do painel alteração de presentes
        /// </value>
        int indiceAlterarPresentes;
        /// <value>
        ///  integer que guarda posição no indice em que presente está guardado.
        /// É variavel global para permitir funcionamento do painel oferecer presentes
        /// </value>
        int indiceOferecerPresentes;

        public Form1()
        {
            InitializeComponent();
            ///música introdutória
          introSong.URL = "OhOhOh.wav";

            ///para permitir que primeiro passo na app seja inserir criancas no array
            RetirarAcessoTotal();
        }

        private void Form1_load(object sender, EventArgs e)
        {
            introSong.controls.play();
        }
        /// <summary>
        /// Botão que permite sair da aplicação.
        /// Tem mensagem para garantir que utilizador quer terminar aplicação
        /// Contém informação autores de projeto.
        /// </summary>
        private void btnSair_Click_1(object sender, EventArgs e)
        {
            MessageBoxButtons botoes = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Pai Natal, queres sair da Aplicação?", "Sair", botoes, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Projecto realizado por: Catia, Rui e Miguel.", "Santa's Helper App");
                this.Close();
            }
        }
        /// <summary>
        ///  Retira acesso a TAB inserir presentes, comportamento/castigo e Alterar DDados/Postal de Natal para que sejam acessíveis apenas após inserida crianca
        ///  caso se adicione tabs deve-se adicionar neste método para assegurar que há acesso apenas após inserida pelo menos 1 crianca
        /// </summary>
        private void RetirarAcessoTotal()
        {
            gbIntroduzirPresentesDesejados.Enabled = false;
            gbIntroduzirPresentes.Enabled = false;
            gbComportamentoCastigo.Enabled = false;
            gbCumprirCastigo.Enabled = false;
            gbNoiteMagica.Enabled = false;
            gbDesculpar.Enabled = false;
            gbAlterarDados.Enabled = false;
            gbAlterarPresentes.Enabled = false;
            gbAvaliarComportamento.Enabled = false;
            gbOferecerPresentes.Enabled = false;
        }

        /*TAB Inserir Crianças*/

        /// <summary>
        /// Incrementa indice de array crianca e atualiza  caixa texto de índice de criança na TAB Inserir Crianças.
        ///  é sempre que invocado após o constructor de qualquer tipo de crianças
        ///</summary>
        private void AuxiliarContructor()
        {
            indice++;
            txtIndiceIntroduzir.Text = Convert.ToString(indice);
        }
        /// <summary>
        /// Testa condiçoes de inserção de dados na caixa texto nome e idade de crianca na TAB Inserir Crianças. 
        /// Utilizado na TAB inserir crianca gerando string distinta para cada condição
        /// Deverá ser atualizado de acordo com diferentes condições de validação para idade e nome de crianca
        /// </summary>
        /// <returns>
        /// Devolve uma string (diferenciada) de aviso no caso de dados inseridos não sejam validados </returns>
        private string TestarInputs()
        {
            string Resultado = "";
            if (txtNomeCrianca.Text == "")
            {
                Resultado += "Nome de criança vazio... ";
            }
            if (txtIdadeCrianca.Text == "")
            {
                Resultado += "Valor de idade incorrecto... ";
            }
            else
            {
                if (Convert.ToInt16(txtIdadeCrianca.Text) < 0 || Convert.ToInt16(txtIdadeCrianca.Text) >= 18)
                {
                    Resultado += " Apenas consideramos crianças com idades entre 0 e 17 anos. ";
                }
            }
            return Resultado;
        }
        /// <summary>
        /// Testa condiçoes de inserção de dados na caixa texto nº de birras e duração de birras na TAB Inserir Crianças gerando string distinta para cada condição
        /// Deverá ser atualizado de acordo com diferentes condições de validação para nº/duração de birras de irritante/insuportavel
        /// </summary>
        /// <returns>
        /// Devolve uma string (diferenciada) de aviso no caso de dados inseridos não sejam validados </returns>
        private string TestarInputsIrritantes()
        {
            if (txtNumeroBirras.Text == "")
            {
                return "NumeroBirrasErrado";
            }
            else if (Convert.ToDouble(txtNumeroBirras.Text) <= 0)
            {
                return "NumeroBirrasErrado";
            }
            else if (txtDuracaoBirras.Text == "")
            {
                return "CriancaIrritanteSemDuracao";
            }
            else if (Convert.ToDouble(txtDuracaoBirras.Text) > 0)
            {
                return "CriancaIrritanteComDuracao";
            }
            return "";
        }
        /// <summary>
        /// Testa condiçoes de inserção de dados na caixa texto numero de birras e média de birras na TAB Inserir Crianças gerando string distinta para cada condição
        /// </summary>
        /// <returns>
        /// Devolve uma string de aviso no caso de caixas de texto vazias Nome ou idade crianca na TAB inserir crianca
        /// </returns>
        private string TestarInputsInsuportaveis()
        {
            if (txtNumeroBirras.Text == "")
            {
                return "NumeroBirrasErrado";
            }
            else if (Convert.ToDouble(txtNumeroBirras.Text) <= 0)
            {
                return "NumeroBirrasErrado";
            }
            else if (txtDuracaoBirras.Text == "")
            {
                return "CriancaInsuportavelSemDuracao";
            }
            else if (Convert.ToDouble(txtDuracaoBirras.Text) > 0)
            {
                return "CriancaInsuportavelComDuracao";
            }
            return "";
        }
        /// <summary>
        /// Método que retira acesso ao gb Las Terribles (Irritantes e Insuportaveis) na TAB Inserir Crianças
        /// </summary>   
        /// <returns>
        /// Não devolve qualquer valor (função void)
        /// </returns>
        private void RetirarAcessoLasTerribles()
        {
            gbLasTerribles.Enabled = false;
            txtNumeroBirras.Enabled = false;
            txtDuracaoBirras.Enabled = false;
        }
        /// <summary>
        /// Método que dá acesso ao gb Las Terribles (Irritantes e Insuportaveis) na TAB Inserir Crianças.
        /// </summary>   
        ///  <returns>
        /// Não devolve qualquer valor (função void)
        /// </returns>
        private void DarAcessoLasTerribles()
        {
            gbLasTerribles.Enabled = true;
            txtNumeroBirras.Enabled = true;
            txtDuracaoBirras.Enabled = true;
        }
        /// <summary>
        /// Radiobutton normal escolhido retira acesso a introdução dados específicos Insuportaveis/Irritantes na TAB Inserir Crianças
        /// </summary>
        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNormal.Checked == true)
            {
                RetirarAcessoLasTerribles();
            }
        }
        /// <summary>
        /// Radiobutton fofinha escolhido retira acesso a introdução dados específicos Insuportaveis/Irritantes na TAB Inserir Crianças
        /// </summary>
        private void rbFofinha_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFofinha.Checked == true)
            {
                RetirarAcessoLasTerribles();
            }
        }
        /// <summary>
        /// Radiobutton Irritante escolhido dá acesso a introdução dados específicos Insuportaveis/Irritantes na TAB Inserir Crianças
        /// </summary>
        private void rbIrritante_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIrritante.Checked == true)
            {
                DarAcessoLasTerribles();
            }
        }
        /// <summary>
        /// Radiobutton Insuportável escolhido dá acesso a introdução dados específicos Insuportaveis/Irritantes na TAB Inserir Crianças
        /// </summary>
        private void rbInsuportavel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbInsuportavel.Checked == true)
            {
                DarAcessoLasTerribles();
            }
        }
        /// <summary>
        /// Botão que instancia objeto da classe crianca/fofinha/irritante/insuportável na TAB Inserir Crianças
        /// utilizador introduz parametros de construtor 
        /// Apenas permite inserir parametros específicos do construtor da classe específica de crianca seleccionada
        /// Preenche Array crianca[10] com valores inseridos no formulario
        /// Mensagens de erro para garantir validação de dados
        /// </summary>       
        private void btInserirCrianca_Click(object sender, EventArgs e)
        {
            try
            {
                string switchCrianca, testarInputs = TestarInputs();

                ///Mensagem de erro se dados introduzidos nas caixas de texto nome e idade não válidos.
                ///Recorre a método TestarInputs que testa e devolve string a inserir na mensagem
                if (testarInputs != "")
                {
                    MessageBoxButtons btnarrayCheio = MessageBoxButtons.OK;
                    DialogResult result2 = MessageBox.Show("Pai Natal... " + testarInputs + "", "ATENÇÃO!!!", btnarrayCheio, MessageBoxIcon.Warning);
                }
                else
                {
                    string nomeCrianca = txtNomeCrianca.Text;
                    int idadeCrianca = Convert.ToInt16(txtIdadeCrianca.Text);

                    if (rbNormal.Checked == true)
                    {
                        switchCrianca = "CriancaNormal";
                    }
                    else if (rbFofinha.Checked == true)
                    {
                        switchCrianca = "CriancaFofinha";
                    }
                    else if (rbIrritante.Checked == true)//sugestão:  else if (rbIrritante.Checked == true ||rbInsuportavel.Checked == true ) e retirar 174 a 185
                    {
                        string testarBirras = TestarInputsIrritantes();
                        ///Mensagem de erro se dados introduzidos nas caixas de texto nº/média birras não válidos.
                        ///Recorre a método TestarInputsIrritantes que testa e devolve string a inserir no switch e permitir opção distinta para cada condição
                        if (testarBirras != "")
                        {
                            switchCrianca = testarBirras;
                        }
                        else
                        {
                            switchCrianca = "duracaoBirraErrada";
                        }
                    }
                    else if (rbInsuportavel.Checked == true)
                    {
                        string testarBirras = TestarInputsInsuportaveis();

                        if (testarBirras != "")
                        {
                            switchCrianca = testarBirras;
                        }
                        else
                        {
                            switchCrianca = "duracaoBirraErrada";
                        }
                    }
                    else
                    {
                        switchCrianca = "default";
                    }

                    switch (switchCrianca)
                    {
                        case "CriancaNormal":
                            Crianca CriancaNormal = new Crianca(nomeCrianca, idadeCrianca);
                            criancas[indice] = CriancaNormal;
                            AuxiliarContructor();
                            break;

                        case "CriancaFofinha":
                            Fofinha CriancaFofinha = new Fofinha(nomeCrianca, idadeCrianca);
                            criancas[indice] = CriancaFofinha;
                            AuxiliarContructor();
                            break;

                        case "CriancaIrritanteSemDuracao":
                            Irritante CriancaIrritante30 = new Irritante(nomeCrianca, idadeCrianca, Convert.ToInt16(txtNumeroBirras.Text));
                            criancas[indice] = CriancaIrritante30;
                            AuxiliarContructor();
                            break;

                        case "CriancaIrritanteComDuracao":
                            Irritante CriancaIrritante = new Irritante(nomeCrianca, idadeCrianca, Convert.ToInt16(txtNumeroBirras.Text), Convert.ToDouble(txtDuracaoBirras.Text));
                            criancas[indice] = CriancaIrritante;
                            AuxiliarContructor();
                            break;

                        case "CriancaInsuportavelSemDuracao":
                            Insuportavel CriancaInsuportavel30 = new Insuportavel(nomeCrianca, idadeCrianca, Convert.ToInt16(txtNumeroBirras.Text));
                            criancas[indice] = CriancaInsuportavel30;
                            AuxiliarContructor();
                            break;

                        case "CriancaInsuportavelComDuracao":
                            Insuportavel CriancaInsuportavel = new Insuportavel(nomeCrianca, idadeCrianca, Convert.ToInt16(txtNumeroBirras.Text), Convert.ToDouble(txtDuracaoBirras.Text));
                            criancas[indice] = CriancaInsuportavel;
                            AuxiliarContructor();
                            break;

                        case "NumeroBirrasErrado":
                            MessageBoxButtons btnnumeroBirra = MessageBoxButtons.OK;
                            DialogResult result = MessageBox.Show("Pai Natal... Como é possivel uma criança destas não fazer birras?", "ATENÇÂO!!!", btnnumeroBirra, MessageBoxIcon.Warning);
                            break;
                        case "duracaoBirraErrada":
                            MessageBoxButtons btnduracaoBirra = MessageBoxButtons.OK;
                            DialogResult result2 = MessageBox.Show("Pai Natal... Como é possivel uma criança fazer uma birra com esta duração? Se não sabes a duração não metes nada!", "ATENÇÂO!!!", btnduracaoBirra, MessageBoxIcon.Warning);
                            break;
                        case "default":
                            MessageBoxButtons btnvaloresErrados = MessageBoxButtons.OK;
                            DialogResult result3 = MessageBox.Show("Pai Natal... Pai Natal... Meteste os valores errados!", "ATENÇÃO!!!", btnvaloresErrados, MessageBoxIcon.Warning);
                            break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxButtons catchError = MessageBoxButtons.OK;
                DialogResult result4 = MessageBox.Show("Pai Natal... Pai Natal... Explodiste com a app!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
            }
            if (indice == 10)
            {
                btnInserirCrianca.Enabled = false;
            }
            ///para que se possam obter informação sobre crianças introduzidas apenas depois de introduzir crianças na TAB Inserir Crianças
            gbIntroduzirPresentes.Enabled = true;
            gbComportamentoCastigo.Enabled = true;
            gbAlterarDados.Enabled = true;
            gbAlterarPresentes.Enabled = true;
            gbOferecerPresentes.Enabled = true;
            gbAlterarDados.Visible = true;
        }


        /*TAB Inserir Presentes*/

        /// <summary>
        /// Método que disponibiliza acesso a botão/caixas de texto para adicionar presentes na TAB Inserir Presentes
        /// </summary>
        ///<return>
        ///Não devolve qualquer valor (função void)
        ///</return>
        private void DarAcessoAdicionarPresente()
        {
            txtNomePresente.Enabled = true;
            txtPrecoPresente.Enabled = true;
            btnAdicionarPresente.Enabled = true;
        }
        /// <summary>
        /// Método que retira o acesso a botão/caixas de texto para adicionar presentes na TAB Inserir Presentes
        /// </summary>
        ///<return>
        ///Não devolve qualquer valor (função void)
        ///</return>
        private void SemAcessoAdicionarPresente()
        {
            btnAdicionarPresente.Enabled = false;
            txtNomePresente.Enabled = false;
            txtPrecoPresente.Enabled = false;
        }
        /// <summary>
        /// Método que limpa dados de presentes na TAB Inserir Presentes
        /// após limpar restitui acesso acesso botao/cx texto para adicionar presentes
        /// </summary>
        ///<return>
        ///Não devolve qualquer valor (função void)
        ///</return>
        private void LimparTbPresentes()
        {
            txtIndicePresente.Text = "0";
            txtPrecoPresente.Text = "";
            txtNomePresente.Text = "";
            txtCarta.Text = "";

            DarAcessoAdicionarPresente();
        }
        /// <summary>
        /// Método que preenche caixa de texto carta para pai natal com dados de presentes inseridos na TAB Inserir Presentes
        /// vai sendo preenchida a medida que dados sao inseridos
        /// </summary>
        /// <return>
        ///Não devolve qualquer valor (função void)
        ///</return>
        private void CartaPaiNatal()
        {
            string listaPresentes = "Querido Pai Natal, os presentes que escolhi foram: " + "";
            int indiceCrianca = Convert.ToInt16(txtIndiceEscolherCrianca.Text);
            for (int i = 0; i < 5; i++)
            {
                if (criancas[indiceCrianca].PresentesDesejados[i] != null)
                {
                    if (i < 4)
                        listaPresentes += criancas[indiceCrianca].PresentesDesejados[i].NomePresentes + "(" + Convert.ToString(criancas[indiceCrianca].PresentesDesejados[i].PrecoPresente) + "€)" + ", ";
                    if (i == 4)
                        listaPresentes += criancas[indiceCrianca].PresentesDesejados[i].NomePresentes + "(" + Convert.ToString(criancas[indiceCrianca].PresentesDesejados[i].PrecoPresente) + "€)" + ".";
                }
                txtCarta.Text = listaPresentes;
            }
        }
        /// <summary>
        /// Botão que insere presente no array PresentesDesejados[] da classe crianca na TAB Inserir Presentes
        /// Recorre ao método IntroduzirPresente(string nomePresente, double precoPresente) da classe crianca para instanciar
        /// e inserir objeto no array.
        /// incrementa posição de array e assegura que apenas são inseridos 5 presentes (máximo do array)
        /// Obriga inserção de 5 presentes pois apenas incrementa indice de crianca após inserção de 5 presentes.
        /// </summary>
        private void btnAdicionarPresente_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    int posPresente = Convert.ToInt16(txtIndicePresente.Text);
                    string nomePresente = txtNomePresente.Text;
                    double precoPresente = Convert.ToDouble(txtPrecoPresente.Text);
                    int indiceCrianca = Convert.ToInt16(txtIndiceEscolherCrianca.Text);

                    if (criancas[indiceCrianca] == null)
                    {
                        btnAdicionarPresente.Enabled = false;
                        MessageBoxButtons catchError = MessageBoxButtons.OK;
                        DialogResult result30 = MessageBox.Show("Pai Natal... Apenas podes inserir presentes em crianças já inseridas!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (posPresente == 5)
                        {
                            SemAcessoAdicionarPresente();
                            MessageBoxButtons catchError = MessageBoxButtons.OK;
                            DialogResult result8 = MessageBox.Show("Pai Natal... Apenas podem ser inseridos 5 presentes!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
                            SubirIndiceCriancaPresente();
                            LimparTbPresentes();
                            LimparIdentificadorCrianca();
                            btnIndentificarCrianca.Enabled = true;
                        }
                        else
                        {
                            DarAcessoAdicionarPresente();
                            criancas[indiceCrianca].IntroduzirPresente(nomePresente, precoPresente);
                            posPresente++;
                            txtIndicePresente.Text = Convert.ToString(posPresente);

                            CartaPaiNatal();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBoxButtons catchError = MessageBoxButtons.OK;
                    DialogResult result8 = MessageBox.Show("Pai Natal, tens de identificar a criança e inserir dados corretos dos 5 presentes: nome e preço acima de 0€!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
                }
            }
        }
        /// <summary>
        /// Botão que identifica crianca para a qual se pretende adicionar presentes e mostra informação nome e idade na TAB Inserir Presentes
        /// Apenas após identificada crianca é que se permite adicionar presentes
        /// Apenas após adicionar 5 presentes é que se permite novo acesso a botão identificar crianca
        /// </summary>
        private void btnIndentificarCrianca_Click(object sender, EventArgs e)
        {
            LimparTbPresentes();
            int indiceCrianca = Convert.ToInt16(txtIndiceEscolherCrianca.Text);

            if (criancas[indiceCrianca] == null)
            {
                gbIntroduzirPresentesDesejados.Enabled = false;

                MessageBoxButtons catchError = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show("Pai Natal... Apenas se pode obter informação de crianças já inseridas e com índice inferior a 10!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
            }
            else
            {
                string nomeCrianca = criancas[indiceCrianca].Nome;
                int idadeCrianca = criancas[indiceCrianca].Idade;

                txtNomeCrianca_Presente.Text = nomeCrianca;
                txtIdade_Presente.Text = Convert.ToString(idadeCrianca);

                gbIntroduzirPresentesDesejados.Enabled = true;
                btnIndentificarCrianca.Enabled = false;
            }
        }
        private void LimparIdentificadorCrianca()
        {
            txtNomeCrianca_Presente.Text = "";
            txtIdade_Presente.Text = "";
        }
        /// <summary>
        /// Método que incrementa o índice de crianca e atualiza a caixa de texto de índice de criança na TAB Inserir Presentes
        /// </summary>
        private void SubirIndiceCriancaPresente()
        {
            int indiceCrianca = Convert.ToInt16(txtIndiceEscolherCrianca.Text);
            if (indiceCrianca == 9)
            {
                MessageBoxButtons catchError = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show("Pai Natal... Apenas se pode obter informação de crianças já inseridas e com índice inferior a 10!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
            }
            if (indiceCrianca < 9)
                indiceCrianca++;
            txtIndiceEscolherCrianca.Text = Convert.ToString(indiceCrianca);
            if (criancas[indiceCrianca] == null)
            {
                MessageBoxButtons catchError = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show("Pai Natal... Apenas se pode obter informação de crianças já inseridas e com índice inferior a 10!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
            }
        }

        /*TAB Comportamento e Castigos*/

        /// <summary>
        /// Método que limpa caixas de texto de TAB Comportamento e Castigos
        /// </summary>
        private void LimparFormCastigo()
        {
            txtAvaliaComportamento.Text = "";
            txtCastigo.Text = "";
            txtNoiteMagica.Text = "";
            txtNumeroCopias.Text = "";
            txtNumeroCopiasRegistadas.Text = "";
            txtDesculpar.Text = "";
        }
        /// <summary>
        /// Botão que incrementa índice de crianca a identificar na TAB Comportamento e Castigos
        /// Apenas permite identificar criancas inseridas (objetos instanciados) e que respeitem limite máximo do array
        /// Atualiza caixa de texto com novo índice.
        /// </summary>
        private void btnSubirCriancaComportamento_Click(object sender, EventArgs e)
        {
            int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);

            if (indiceCrianca < 9)
                if (criancas[indiceCrianca + 1] == null)
                {
                    MessageBoxButtons catchError = MessageBoxButtons.OK;
                    DialogResult result10 = MessageBox.Show("Pai Natal... Apenas se pode obter informação de crianças já inseridas e com índice inferior a 10!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
                }
                else
                {
                    indiceCrianca++;
                    txtIndiceCriancaComportamento.Text = Convert.ToString(indiceCrianca);
                }
            if (indiceCrianca == 9)
            {
                MessageBoxButtons catchError = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show("Pai Natal... Apenas se pode obter informação de crianças já inseridas e com índice inferior a 10!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Botão que decresce índice de crianca a identificar na TAB Comportamento e Castigos. 
        /// Garante que índice não desce abaixo do seu valor mínimo.
        /// Atualiza caixa de texto com novo índice .
        /// </summary>
        private void btnDescerCriancaComportamento_Click(object sender, EventArgs e)
        {
            int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);

            if (indiceCrianca > 0)
            {
                indiceCrianca--;
                txtIndiceCriancaComportamento.Text = Convert.ToString(indiceCrianca);
            }
        }
        /// <summary>
        /// Botão que identifica criança para qual comportamento será avaliado, cópias serão registadas, castigo eventualmente desculpado e
        /// noite mágica avaliada na TAB Comportamento e Castigos
        ///Quando pressionado limpa dados de avaliação de castigo anterior e disponibiliza acesso a gb avaliarComportamento e gb NoiteMagica
        /// </summary>
        private void btnCriancaComportamento_Click(object sender, EventArgs e)
        {
            LimparFormCastigo();

            try
            {
                gbAvaliarComportamento.Enabled = true;
                gbNoiteMagica.Enabled = true;

                int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);
                string nomeCrianca = criancas[indiceCrianca].Nome;
                int idadeCrianca = criancas[indiceCrianca].Idade;

                txtNomeComportamento.Text = nomeCrianca;
                txtIdadeComportamento.Text = Convert.ToString(idadeCrianca);
            }
            catch (Exception)
            {
                MessageBoxButtons catchError = MessageBoxButtons.OK;
                DialogResult result10 = MessageBox.Show("Pai Natal, tens de identificar a criança!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Botao que invoca método BemComportada() e preenche caixa texto com informação obtida(Bem/Mal comportada) na TAB Comportamento e Castigos
        /// Se mal comportada permite acesso a gb Cumprir Castigo e Desculpar Mau Comportamento
        /// </summary>
        private void btnAvaliaComportamento_Click(object sender, EventArgs e)
        {
            int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);
            txtDesculpar.Text = "";
            if (criancas[indiceCrianca].BemComportada() == true)
            {
                txtAvaliaComportamento.Text = "Bem Comportada";
            }
            else
            {
                txtAvaliaComportamento.Text = "Mal Comportada";

            }
            if (criancas[indiceCrianca].PontosMauComportamento > 3)
            {
                txtCastigo.Text = "Está de Castigo";
                gbCumprirCastigo.Enabled = true;
                gbDesculpar.Enabled = true;
            }
            else
                txtCastigo.Text = "Não está de Castigo";
        }
        /// <summary>
        /// Botão que invoca metodo ContempladaComNoiteMagica() e insere informação em caixa de texto na TAB Comportamento e Castigos
        /// Informa utilizador se crianca tem ou não Noite Mágica
        /// </summary>
        private void btnNoiteMagica_Click_1(object sender, EventArgs e)
        {
            int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);

            if (criancas[indiceCrianca].ContempladaComNoiteMagica() == true)
                txtNoiteMagica.Text = "Terá Noite Mágica!";
            if (criancas[indiceCrianca].ContempladaComNoiteMagica() == false)
                txtNoiteMagica.Text = "Não terá Noite Mágica!";
        }
        /// <summary>
        /// Botão que invoca método CumprimentoCastigos() e insere informação sobre número de cópias realizadas até então em caixa de texto.
        /// Usado na TAB Comportamento e Castigos
        /// Caso utilizador pretenda registar cópias em criança não castigada irá informar utilizador que apenas crianças castigadas poderão registar
        /// número de cópias.
        /// </summary>
        private void btnCumprirCastigo1_Click(object sender, EventArgs e)
        {
            int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);
            int registoCopias = criancas[indiceCrianca].RegistoCopias;

            criancas[indiceCrianca].CumprimentoCastigos();

            if (criancas[indiceCrianca].CumprirCastigo == false)
            {
                txtNumeroCopiasRegistadas.Text = Convert.ToString(criancas[indiceCrianca].RegistoCopias);
                if (criancas[indiceCrianca].RegistoCopias == registoCopias)
                {
                    MessageBoxButtons catcErrors = MessageBoxButtons.OK;
                    DialogResult result13 = MessageBox.Show("Pai Natal... Apenas crianças castigadas podem registar número de cópias!", "ATENÇÃO!!!", catcErrors, MessageBoxIcon.Warning);
                }
            }
            if (criancas[indiceCrianca].CumprirCastigo == true)
            {
                gbCumprirCastigo.Enabled = false;
                txtNumeroCopiasRegistadas.Text = Convert.ToString(criancas[indiceCrianca].RegistoCopias);
                txtNumeroCopias.Text = "";
                MessageBoxButtons catcErrors = MessageBoxButtons.OK;
                DialogResult result13 = MessageBox.Show("Pai Natal... A criança cumpriu castigo!Verifica se pretendes desculpar Mau Comportamento clicando no botão correspondente", "ATENÇÃO!!!", catcErrors, MessageBoxIcon.Warning);

            }


        }
        /// <summary>
        /// Botão que invoca metodo CumprimentoCastigos(int numCopias) e insere informação em caixa de texto que regista somatório de número de cópias na TAB Comportamento e Castigos
        /// Informa utilizador caso se pretenda adicionar cópias sem tal ser possível por condição do método
        /// Apenas permite introdução de número positivo de cópias
        /// </summary>
        private void btnCumprirCastigoX_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);
                int copias = Convert.ToInt16(txtNumeroCopias.Text);
                int registoCopias = criancas[indiceCrianca].RegistoCopias;

                if (copias > 0)
                {
                    criancas[indiceCrianca].CumprimentoCastigos(copias);
                    if (criancas[indiceCrianca].CumprirCastigo == false)
                    {
                        txtNumeroCopiasRegistadas.Text = Convert.ToString(criancas[indiceCrianca].RegistoCopias);


                        if (criancas[indiceCrianca].RegistoCopias == registoCopias)
                        {
                            MessageBoxButtons catcErrors = MessageBoxButtons.OK;
                            DialogResult result10 = MessageBox.Show("Pai Natal... Apenas crianças castigadas podem registar número de cópias!", "ATENÇÃO!!!", catcErrors, MessageBoxIcon.Warning);
                        }
                    }
                    if (criancas[indiceCrianca].CumprirCastigo == true)
                    {
                        gbCumprirCastigo.Enabled = false;
                        gbDesculpar.Enabled = true;
                        txtNumeroCopiasRegistadas.Text = Convert.ToString(criancas[indiceCrianca].RegistoCopias);
                        txtNumeroCopias.Text = "";
                        MessageBoxButtons catcErrors = MessageBoxButtons.OK;
                        DialogResult result13 = MessageBox.Show("Pai Natal... A criança cumpriu castigo!Verifica se pretendes desculpar Mau Comportamento clicando no botão correspondente", "ATENÇÃO!!!", catcErrors, MessageBoxIcon.Warning);

                    }
                }
                if (copias == 0)
                {
                    MessageBoxButtons catchErrors = MessageBoxButtons.OK;
                    DialogResult result10 = MessageBox.Show("Pai Natal... O número de cópias tem de ser superior a 0!", "ATENÇÃO!!!", catchErrors, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBoxButtons catchError = MessageBoxButtons.OK;
                DialogResult result7 = MessageBox.Show("Pai Natal... tens de inserir número de cópias realizadas!", "ATENÇÃO!!!", catchError, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Botão que invoca método DesculparMauComportamento() e devolve informação a utilizador se crianca foi (True) ou não (false) desculpada na TAB Comportamento e Castigos
        /// Caso criança não possa ser desculpada (situação em que não está de castigo ou ainda não realizou número de cópias suficientes) irá demonstrar mensagem
        /// em caixa de texto Desculpar
        /// </summary>
        private void btnDesculparMauComportamento_Click(object sender, EventArgs e)
        {
            int indiceCrianca = Convert.ToInt16(txtIndiceCriancaComportamento.Text);

            if (criancas[indiceCrianca].DesculparMauComportamento() == true)
            {
                txtDesculpar.Text = "Criança Desculpada";
                txtCastigo.Text = "Não está de Castigo";
                gbDesculpar.Enabled = false;

            }
        }

        /*Postal Natal e Alterar Dados Criança*/

        /// <summary>
        /// Método que testa se caixas de texto preco (valor/se é vazia) e nome de presente (se vazio) com variável do tipo MessageBoxButtons - diferenciados para cada if.
        /// Usado na Postal Natal e Alterar Dados Criança
        /// caso validados introduz dados no array de presentes e indisponibiliza acesso a botão altera presentes
        /// </summary>
        private void AlterarPresentes()
        {
            try
            {
                if (txtAlterarNomePresente.Text == "")
                {
                    MessageBoxButtons btnPresente = MessageBoxButtons.OK;
                    DialogResult result33 = MessageBox.Show("Pai Natal... Enganaste no nome...", "ATENÇÃO!!!", btnPresente, MessageBoxIcon.Warning);
                }
                else if (txtAlterarPrecoPresente.Text == "")
                {
                    MessageBoxButtons btnPresente = MessageBoxButtons.OK;
                    DialogResult result34 = MessageBox.Show("Pai Natal... Esqueceste do preço...", "ATENÇÃO!!!", btnPresente, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDouble(txtAlterarPrecoPresente.Text) <= 0)
                {
                    MessageBoxButtons btnPresente = MessageBoxButtons.OK;
                    DialogResult result35 = MessageBox.Show("Pai Natal... Este preço não é valido...", "ATENÇÃO!!!", btnPresente, MessageBoxIcon.Warning);
                }
                else
                {
                    criancas[indiceAlterarDados].IntroduzirPresente(Convert.ToInt16(txtIndiceAlterarPresentes.Text), txtAlterarNomePresente.Text, Convert.ToDouble(txtAlterarPrecoPresente.Text));
                    btnAlterarPresentes.Enabled = false;
                    btnSelecionarPresente.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBoxButtons catchPresente = MessageBoxButtons.OK;
                DialogResult result36 = MessageBox.Show("Pai Natal, ias estrangando isto!", "ATENÇÃO!!!", catchPresente, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Método que atualiza todas as caixas de texto da TAB Postal Natal e Alterar Dados Criança com dados de campos de objeto criancas[]
        /// da posição escolhida pelo utilizador na TAB Postal Natal e Alterar Dados Criança.
        /// Disponibiliza acesso/visibilidade de caixas de texto/labels de acordo com tipo de criança
        /// </summary>
        private void AtualizarAlterarDados()
        {
            txtMorada.Enabled = true;
            txtNome.Text = criancas[indiceAlterarDados].Nome;
            txtIdade.Text = criancas[indiceAlterarDados].Idade.ToString();
            txtMorada.Text = criancas[indiceAlterarDados].Morada;

            if (criancas[indiceAlterarDados].ServicoExpresso == true)
            {
                cbServicoExpresso.Text = "Tem";
            }
            else
            {
                cbServicoExpresso.Text = "Não tem";
            }

            txtPlafondEfetivo.Text = criancas[indiceAlterarDados].PlafondPresentes.ToString() + "€";
            txtPlafondBase.Text = Convert.ToString(criancas[indiceAlterarDados].PlafondBase()) + "€";
            txtPontosMauComportamento.Text = criancas[indiceAlterarDados].PontosMauComportamento.ToString();
            txtNumMentiras.Text = criancas[indiceAlterarDados].NumeroMentiras.ToString();

            if (criancas[indiceAlterarDados].CumprirCastigo == true)
            {
                txtCumprirCastigo.Text = "Sim";
            }
            else
            {
                txtCumprirCastigo.Text = "Não";
            }

            txtRegistoCopias.Text = criancas[indiceAlterarDados].RegistoCopias.ToString();

            if (criancas[indiceAlterarDados].CamaHoras == true)
            {

                cbCamaHoras.Text = "Vai";

            }
            else
            {

                cbCamaHoras.Text = "Não vai";

            }

            if (criancas[indiceAlterarDados] is Crianca)
            {

                txtTipoCrianca.Text = "Criança Normal";
                if (criancas[indiceAlterarDados] is Crianca)
                {

                    cbSopaToda.Enabled = false;
                    cbArrumaQuarto.Enabled = false;
                    txtNumBirras.Enabled = false;
                    txtDadoDuracaoBirras.Enabled = false;
                    cbPalavroes.Enabled = false;

                }

            }
            
            if (criancas[indiceAlterarDados] is Fofinha)
            {

                Fofinha novaFofinha;

                txtTipoCrianca.Text = "Criança Fofinha";

                if (criancas[indiceAlterarDados] is Fofinha)
                {

                    cbArrumaQuarto.Enabled = true;
                    cbCamaHoras.Enabled = true;
                    cbSopaToda.Enabled = true;
                    txtNumBirras.Enabled = false;
                    cbPalavroes.Enabled = false;
                    txtDadoDuracaoBirras.Enabled = false;

                }
                else
                {

                    cbArrumaQuarto.Enabled = false;
                    cbSopaToda.Enabled = false;

                }

                novaFofinha = (Fofinha)criancas[indiceAlterarDados];
                if (novaFofinha.ComeSopa == true)
                {
                    cbSopaToda.Text = "Sim";
                }
                else
                {
                    cbSopaToda.Text = "Não";
                }
                if (novaFofinha.ArrumaQuarto == true)
                {
                    cbArrumaQuarto.Text = "Sim";
                }
                else
                {
                    cbArrumaQuarto.Text = "Não";
                }

            }

            if (criancas[indiceAlterarDados] is Irritante)
            {
                Irritante novaIrritante;

                txtTipoCrianca.Text = "Criança Irritante";

                if (criancas[indiceAlterarDados] is Irritante)
                {
                    txtNumBirras.Enabled = true;
                    txtDadoDuracaoBirras.Enabled = true;
                }
                else
                {
                    txtDadoDuracaoBirras.Enabled = false;
                    txtNumBirras.Enabled = false;
                    cbSopaToda.Enabled = false;
                    cbArrumaQuarto.Enabled = false;
                }
                

                novaIrritante = (Irritante)criancas[indiceAlterarDados];

                if (novaIrritante.MediaBirras > 0)
                {
                    txtDadoDuracaoBirras.Text = novaIrritante.MediaBirras.ToString();
                }
                if (novaIrritante.NumeroBirras > 0)
                {

                    txtNumBirras.Text = novaIrritante.NumeroBirras.ToString();

                }

            }

            if (criancas[indiceAlterarDados] is Insuportavel)
            {
                Insuportavel novaInsuportavel;

                txtTipoCrianca.Text = "Criança Insuportavel";

                if (criancas[indiceAlterarDados] is Insuportavel)
                {
                    txtDadoDuracaoBirras.Enabled = true;
                    txtNumBirras.Enabled = true;
                    cbPalavroes.Enabled = true;
                }
                else
                {

                    txtDadoDuracaoBirras.Enabled = false;
                    txtNumBirras.Enabled = false;
                    cbPalavroes.Enabled = false;

                }

                novaInsuportavel = (Insuportavel)criancas[indiceAlterarDados];

                if (novaInsuportavel.MediaBirras > 0)
                {

                    txtDadoDuracaoBirras.Text = novaInsuportavel.MediaBirras.ToString();

                }
                if (novaInsuportavel.NumeroBirras > 0)
                {

                    txtNumBirras.Text = novaInsuportavel.NumeroBirras.ToString();

                }
                if (novaInsuportavel.Palavroes == true)
                {

                    cbPalavroes.Text = "Sim";

                }
                else
                {

                    cbPalavroes.Text = "Não";

                }
            }

        }
        /// <summary>
        ///Ao pressionar TAB Postal Natal e Alterar Dados Criança atualiza dados para posição que se encontra na caixa de texto do índice de criança cujos dados se pretende alterar
        /// Caso não hajam crianças inseridas alerta utilizador de que terá de inserir crianças primeiro
        /// </summary>
        /// 
        private void tpAlterarEOferecer_Enter_1(object sender, EventArgs e)
        {
            if (criancas[indiceAlterarDados] == null)
            {
                MessageBoxButtons catchAO = MessageBoxButtons.OK;
                DialogResult result39 = MessageBox.Show("Pai Natal... Tens de inserir uma criança primeiro!", "ATENÇÃO!!!", catchAO, MessageBoxIcon.Warning);
            }
            else
            {
                AtualizarAlterarDados();
            }
        }

        /// <summary>
        /// Botão que incrementa o índice do array e invoca método AtualizarAlterarDAdos() na  TAB Postal Natal e Alterar Dados Criança
        /// Tem condições que asseguram validade do índice, garantindo que apenas lê dados de uma criança previamente inserida no array
        /// </summary>
        private void btnSeguinte_Click_1(object sender, EventArgs e)
        {
            if (indiceAlterarDados == 9)
            {

                AtualizarAlterarDados();

            }
            else if (criancas[indiceAlterarDados + 1] == null)
            {
                MessageBoxButtons btnAlterar = MessageBoxButtons.OK;
                DialogResult result41 = MessageBox.Show("Pai Natal... Essa memoria... Não meteste esta criança...", "ATENÇÃO!!!", btnAlterar, MessageBoxIcon.Warning);
            }
            else
            {
                indiceAlterarDados++;
                txtIndiceAlterarDados.Text = indiceAlterarDados.ToString();
                AtualizarAlterarDados();

            }
        }
        /// <summary>
        /// Botão que decresce índice e invoca método AtualizarAlterarDAdos() na  TAB Postal Natal e Alterar Dados Criança
        /// assegura que indice não desce abaixo do mínimo de índice
        /// </summary>
        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (indiceAlterarDados == 0)
            {

                AtualizarAlterarDados();

            }
            else
            {

                indiceAlterarDados--;
                txtIndiceAlterarDados.Text = indiceAlterarDados.ToString();
                AtualizarAlterarDados();

            }
        }
        /// <summary>
        /// Botão que incrementa índice de presentes guardado no array e invoca metodo AtualizarAlterarDados() na  TAB Postal Natal e Alterar Dados Criança
        /// Assegura que não ultrapassa o número de posições do array e valida dados introduzidos de idade e se caixa de texto mentiras preenchido
        /// </summary>
        private void btnAlterarCrianca_Click(object sender, EventArgs e)
        {
            try
            {
                int numMentiras = Convert.ToInt16(txtNumMentiras.Text);
                int idadeCriança = Convert.ToInt16(txtIdade.Text);
                

                if (idadeCriança > 0 && idadeCriança < 18)
                {
                    criancas[indiceAlterarDados].Idade = idadeCriança;
                }
                else
                {
                    MessageBoxButtons botoes = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show("Pai Natal... O campo Idade tem de devolver uma idade entre 0 e 17 anos!!", "ATENÇÂO!!!", botoes, MessageBoxIcon.Warning);
                }

                criancas[indiceAlterarDados].Morada = txtMorada.Text;

                if (cbServicoExpresso.Text == "Tem")
                {
                    criancas[indiceAlterarDados].ServicoExpresso = true;
                }
                else
                {
                    criancas[indiceAlterarDados].ServicoExpresso = false;
                }

                if (numMentiras >= 0)
                {
                    criancas[indiceAlterarDados].NumeroMentiras = numMentiras;
                }
                else
                {
                    MessageBoxButtons botoes = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show("Pai Natal... O campo Número de Mentiras tem de devolver um número inteiro ou válido!!", "ATENÇÂO!!!", botoes, MessageBoxIcon.Warning);
                }

                if (cbCamaHoras.Text == "Vai")
                {
                    criancas[indiceAlterarDados].CamaHoras = true;
                }
                else
                {
                    criancas[indiceAlterarDados].CamaHoras = false;
                }

                if (criancas[indiceAlterarDados] is Fofinha)
                {

                    Fofinha alterarFofinha;
                    alterarFofinha = (Fofinha)criancas[indiceAlterarDados];

                    if (cbSopaToda.Text == "Sim")
                    {
                        alterarFofinha.ComeSopa = true;
                    }
                    else
                    {
                        alterarFofinha.ComeSopa = false;
                    }

                    if (cbArrumaQuarto.Text == "Sim")
                    {
                        alterarFofinha.ArrumaQuarto = true;
                    }
                    else
                    {
                        alterarFofinha.ArrumaQuarto = false;
                    }

                }

                if (criancas[indiceAlterarDados] is Irritante)
                {
                    Irritante alterarIrritante;
                    alterarIrritante = (Irritante)criancas[indiceAlterarDados];
                    int numBirras = Convert.ToInt16(txtNumBirras.Text);
                    double mediaBirras = Convert.ToDouble(txtDadoDuracaoBirras.Text);
                    if (numBirras >= 0)
                    {

                        alterarIrritante.NumeroBirras = numBirras;

                    }
                    else
                    {
                        alterarIrritante.NumeroBirras = 0;
                    }

                    if (mediaBirras >= 0)
                    {
                        alterarIrritante.MediaBirras = mediaBirras;
                    }
                    else
                    {
                        alterarIrritante.MediaBirras = 0;
                    }
                }

                if (criancas[indiceAlterarDados] is Insuportavel)
                {

                    Insuportavel alterarInsuportavel;
                    alterarInsuportavel = (Insuportavel)criancas[indiceAlterarDados];
                    int numBirras = Convert.ToInt16(txtNumBirras.Text);
                    double mediaBirras = Convert.ToDouble(txtDadoDuracaoBirras.Text);

                    if (numBirras >= 0)
                    {

                        alterarInsuportavel.NumeroBirras = numBirras;

                    }
                    else
                    {
                        alterarInsuportavel.NumeroBirras = 0;
                    }

                    if (mediaBirras >= 0)
                    {
                        alterarInsuportavel.MediaBirras = mediaBirras;
                    }
                    else
                    {
                        alterarInsuportavel.MediaBirras = 0;
                    }

                    if (cbPalavroes.Text == "Sim")
                    {

                        alterarInsuportavel.Palavroes = true;

                    }
                    else
                    {
                        alterarInsuportavel.Palavroes = false;
                    }

                }
                

                AtualizarAlterarDados();

            }
            catch (Exception)
            {
                MessageBoxButtons catchAlterar = MessageBoxButtons.OK;
                DialogResult result36 = MessageBox.Show("Pai Natal... Ias estrangando isto!", "ATENÇÃO!!!", catchAlterar, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        ///Botão que incrementa índice do array presentes e atualiza índice.Assegura que não sobe acima de índice máximo do array
        ///Utilizado na  TAB Postal Natal e Alterar Dados Criança
        /// </summary>
        private void btnSeguintePresentes_Click(object sender, EventArgs e)
        {
            if (indiceAlterarPresentes == 4)
            { }
            else
            {
                indiceAlterarPresentes++;
                txtIndiceAlterarPresentes.Text = Convert.ToString(indiceAlterarPresentes);
            }
        }
        /// <summary>
        ///Botão que decresce índice do array presentes e atualiza caixa de texto correspondente.
        ///Assegura que não desce abaixo índice mínimo do array. Utilizado na  TAB Postal Natal e Alterar Dados Criança
        /// </summary>
        private void btnAnteriorPresentes_Click(object sender, EventArgs e)
        {
            if (indiceAlterarPresentes == 0)
            { }
            else
            {
                indiceAlterarPresentes--;
                txtIndiceAlterarPresentes.Text = Convert.ToString(indiceAlterarPresentes);
            }
        }
        /// <summary>
        /// Botão que invoca o método AlterarPresentes() e disponibiliza acesso a botões que alteram índice de criança e índice de presente   
        /// utilizado na  TAB Postal Natal e Alterar Dados Criança
        /// </summary>
        private void btnAlterarPresentes_Click(object sender, EventArgs e)
        {
            AlterarPresentes();
            btnAnterior.Enabled = true;
            btnSeguinte.Enabled = true;
            btnAnteriorPresentes.Enabled = true;
            btnSeguintePresentes.Enabled = true;
        }
        /// <summary>
        /// Botão que seleciona presente cujo índice se encontra na caixa de texto índice de presente.
        /// Mostra dados de presente em caixa de texto nome e presente.
        /// Altera e guarda dados de presente guardado no array. Utilizado na  TAB Postal Natal e Alterar Dados Criança
        /// </summary>
        private void btnSelecionarPresente_Click(object sender, EventArgs e)
        {
            try
            {
                if (criancas[indiceAlterarDados].PresentesDesejados[Convert.ToInt16(txtIndiceAlterarPresentes.Text)] == null)
                {
                    MessageBoxButtons btnPostal = MessageBoxButtons.OK;
                    DialogResult result32 = MessageBox.Show("Pai Natal... Essa memoria... Não meteste este presente...", "ATENÇÂO!!!", btnPostal, MessageBoxIcon.Warning);
                }
                else
                {
                    btnAlterarPresentes.Enabled = true;

                    txtAlterarNomePresente.Text = criancas[indiceAlterarDados].PresentesDesejados[Convert.ToInt16(txtIndiceAlterarPresentes.Text)].NomePresentes;
                    txtAlterarPrecoPresente.Text = Convert.ToString(criancas[indiceAlterarDados].PresentesDesejados[Convert.ToInt16(txtIndiceAlterarPresentes.Text)].PrecoPresente);
                    btnSelecionarPresente.Enabled = false;

                    btnAnterior.Enabled = false;
                    btnSeguinte.Enabled = false;
                    btnAnteriorPresentes.Enabled = false;
                    btnSeguintePresentes.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBoxButtons btnSelect = MessageBoxButtons.OK;
                DialogResult result29 = MessageBox.Show("Pai Natal... Andas a ser criativo...", "ATENÇÃO!!!", btnSelect, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Botão que invoca método OferecerPresentes() e insere informação de postal de natal em caixa de texto na  TAB Postal Natal e Alterar Dados Criança
        /// </summary>
        private void btnCriarPostal_Click(object sender, EventArgs e)
        {
            txtPostalDeNatal.Text = criancas[indiceOferecerPresentes].OferecerPresentes();
        }
        /// <summary>
        /// Botão que diminui índice que identifica posição no array de presente cujos dados serão alterados na  TAB Postal Natal e Alterar Dados Criança
        /// Assegura que não desce abaixo valor mínimo de índice
        /// </summary>
        private void btnDescerIndiceOferecer_Click(object sender, EventArgs e)
        {
            if (indiceOferecerPresentes == 0)
            { }
            else
            {
                indiceOferecerPresentes--;
                txtIndiceOferecerPresentes.Text = Convert.ToString(indiceOferecerPresentes);
            }
        }
        /// <summary>
        /// Botão que incrementa índice de criança para a qual se irá obter o postal de natal.
        /// Utilizado na  TAB Postal Natal e Alterar Dados Criança
        ///Assegura que não desce abaixo valor máximo de índice
        /// </summary>
        private void btnSubirIndiceOferecer_Click(object sender, EventArgs e)
        {
            if (indiceOferecerPresentes == 9)
            { }
            else if (criancas[indiceOferecerPresentes + 1] == null)
            {
                MessageBoxButtons btnPostal = MessageBoxButtons.OK;
                DialogResult result31 = MessageBox.Show("Pai Natal... Essa memoria... Não meteste esta criança...", "ATENÇÃO!!!", btnPostal, MessageBoxIcon.Warning);
            }
            else
            {
                indiceOferecerPresentes++;
                txtIndiceOferecerPresentes.Text = Convert.ToString(indiceOferecerPresentes);
            }
        }
    }
}