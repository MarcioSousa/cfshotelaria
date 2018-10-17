using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Negocio;

namespace View
{
    public partial class FrmQuarto : Form
    {
        List<Limpeza> limpezas = new List<Limpeza>();
        List<Quarto> quartos = new List<Quarto>();
        List<Aluguel> alugueis = new List<Aluguel>();
        List<Cliente> clientes = new List<Cliente>();
        List<Pagamento> pagamentos = new List<Pagamento>();
        List<Pedido> pedidos = new List<Pedido>();
        List<ItemPedido> itemPedidos = new List<ItemPedido>();
        List<Produto> produtos = new List<Produto>();

        public FrmQuarto()
        {
            InitializeComponent();
            dgvLimpeza.AutoGenerateColumns = false;
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            CarregaQuartos();
            CarregaLimpezas();
            CarregaAlugueis();
        }

        public void CarregaQuartos()
        {
            QuartoNegocio quartoNegocio = new QuartoNegocio();


            quartos = quartoNegocio.Quartos();

            //ORGANIZA TODOS OS QUARTOS EM ORDEM CRESCENTE
            InsertionSort(quartos);

            //CARREGA TODAS AS LISTAS DE LIMPEZAS DO OBJETO QUARTO E TAMBÉM O ALUGUEL
            for (int t = 0; t < quartos.Count; t++)
            {
                quartoNegocio.AddLimpezas(quartos[t]);

                //if (aluguelNegocio.AluguelQuarto(quartos[t]).Codigo != 0)
                //{
                //    BotaoVermelho(t + 1);
                //}
            }
        }
        public void CarregaLimpezas()
        {
            QuartoNegocio quartoNegocio = new QuartoNegocio();
            LimpezaNegocio limpezaNegocio = new LimpezaNegocio();

            limpezas = limpezaNegocio.Limpezas(quartos);

            dgvLimpeza.DataSource = limpezas;

            //for (int t = 0; t < quartos.Count; t++)
            //{
            //    quartoNegocio.AddLimpezasQuarto(quartos[t]);
            //}

            dgvLimpeza.Refresh();
            dgvLimpeza.Update();
        }
        private void CarregaAlugueis()
        {
            AluguelNegocio aluguelNegocio = new AluguelNegocio();

            alugueis = aluguelNegocio.Alugueis(quartos);

            //QuartoNegocio quartoNegocio = new QuartoNegocio();


            //quartos = quartoNegocio.Quartos();

            ////ORGANIZA TODOS OS QUARTOS EM ORDEM CRESCENTE
            //InsertionSort(quartos);

            ////CARREGA TODAS AS LISTAS DE LIMPEZAS DO OBJETO QUARTO E TAMBÉM O ALUGUEL
            //for (int t = 0; t < quartos.Count; t++)
            //{
            //    quartoNegocio.AddQuartoLimpezas(quartos[t]);

            //    //if (aluguelNegocio.AluguelQuarto(quartos[t]).Codigo != 0)
            //    //{
            //    //    BotaoVermelho(t + 1);
            //    //}
            //}
        }




        private void BotaoVermelho(int numeroBotao)
        {
            if (numeroBotao == 1)
            {
                BtnQuarto1.BackColor = Color.Red;
            }
            else if (numeroBotao == 2)
            {
                BtnQuarto2.BackColor = Color.Red;
            }
            else if (numeroBotao == 3)
            {
                BtnQuarto3.BackColor = Color.Red;
            }
            else if (numeroBotao == 4)
            {
                BtnQuarto4.BackColor = Color.Red;
            }
            else if (numeroBotao == 5)
            {
                BtnQuarto5.BackColor = Color.Red;
            }
            else if (numeroBotao == 6)
            {
                BtnQuarto6.BackColor = Color.Red;
            }
            else if (numeroBotao == 7)
            {
                BtnQuarto7.BackColor = Color.Red;
            }
            else if (numeroBotao == 8)
            {
                BtnQuarto8.BackColor = Color.Red;
            }
            else if (numeroBotao == 9)
            {
                BtnQuarto9.BackColor = Color.Red;
            }
            else if (numeroBotao == 10)
            {
                BtnQuarto10.BackColor = Color.Red;
            }
            else if (numeroBotao == 11)
            {
                BtnQuarto11.BackColor = Color.Red;
            }
            else if (numeroBotao == 12)
            {
                BtnQuarto12.BackColor = Color.Red;
            }
            else if (numeroBotao == 13)
            {
                BtnQuarto13.BackColor = Color.Red;
            }
            else if (numeroBotao == 14)
            {
                BtnQuarto14.BackColor = Color.Red;
            }
            else if (numeroBotao == 15)
            {
                BtnQuarto15.BackColor = Color.Red;
            }
            else if (numeroBotao == 16)
            {
                BtnQuarto16.BackColor = Color.Red;
            }
            else if (numeroBotao == 17)
            {
                BtnQuarto17.BackColor = Color.Red;
            }
            else if (numeroBotao == 18)
            {
                BtnQuarto18.BackColor = Color.Red;
            }
            else if (numeroBotao == 19)
            {
                BtnQuarto19.BackColor = Color.Red;
            }
            else if (numeroBotao == 20)
            {
                BtnQuarto20.BackColor = Color.Red;
            }
            else if (numeroBotao == 21)
            {
                BtnQuarto21.BackColor = Color.Red;
            }
            else if (numeroBotao == 22)
            {
                BtnQuarto22.BackColor = Color.Red;
            }
            else if (numeroBotao == 23)
            {
                BtnQuarto23.BackColor = Color.Red;
            }
            else if (numeroBotao == 24)
            {
                BtnQuarto24.BackColor = Color.Red;
            }
            else if (numeroBotao == 25)
            {
                BtnQuarto25.BackColor = Color.Red;
            }
            else if (numeroBotao == 26)
            {
                BtnQuarto26.BackColor = Color.Red;
            }
            else if (numeroBotao == 27)
            {
                BtnQuarto27.BackColor = Color.Red;
            }
            else if (numeroBotao == 28)
            {
                BtnQuarto28.BackColor = Color.Red;
            }
            else if (numeroBotao == 29)
            {
                BtnQuarto29.BackColor = Color.Red;
            }
            else if (numeroBotao == 30)
            {
                BtnQuarto30.BackColor = Color.Red;
            }
            else if (numeroBotao == 31)
            {
                BtnQuarto31.BackColor = Color.Red;
            }
            else if (numeroBotao == 32)
            {
                BtnQuarto32.BackColor = Color.Red;
            }
            else if (numeroBotao == 33)
            {
                BtnQuarto33.BackColor = Color.Red;
            }
            else if (numeroBotao == 34)
            {
                BtnQuarto34.BackColor = Color.Red;
            }
            else if (numeroBotao == 35)
            {
                BtnQuarto35.BackColor = Color.Red;
            }
            else if (numeroBotao == 36)
            {
                BtnQuarto36.BackColor = Color.Red;
            }
            else if (numeroBotao == 37)
            {
                BtnQuarto37.BackColor = Color.Red;
            }
            else if (numeroBotao == 38)
            {
                BtnQuarto38.BackColor = Color.Red;
            }
            else if (numeroBotao == 39)
            {
                BtnQuarto39.BackColor = Color.Red;
            }
            else if (numeroBotao == 40)
            {
                BtnQuarto40.BackColor = Color.Red;
            }
            else if (numeroBotao == 41)
            {
                BtnQuarto41.BackColor = Color.Red;
            }
            else if (numeroBotao == 42)
            {
                BtnQuarto42.BackColor = Color.Red;
            }
            else if (numeroBotao == 43)
            {
                BtnQuarto43.BackColor = Color.Red;
            }
            else if (numeroBotao == 44)
            {
                BtnQuarto44.BackColor = Color.Red;
            }
            else if (numeroBotao == 45)
            {
                BtnQuarto45.BackColor = Color.Red;
            }
        }

        private List<Quarto> InsertionSort(List<Quarto> quartos)
        {
            for (int i = 0; i < quartos.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (quartos[j - 1].Numero > quartos[j].Numero)
                    {
                        Quarto quartoTemp = new Quarto(quartos[j - 1].Numero, quartos[j - 1].ValorDiaria, quartos[j - 1].Localidade);
                        quartos[j - 1] = quartos[j];
                        quartos[j] = quartoTemp;
                    }
                }
            }
            return quartos;
        }



        private void CarregaCampos(int numeroQuarto, int qtdeQuarto)
        {
            for (int t = 0; t < qtdeQuarto; t++)
            {
                if (quartos[t].Numero == numeroQuarto)
                {
                    LblNumero.Text = quartos[t].Numero.ToString();
                    LblValorQuarto.Text = quartos[t].ValorDiaria.ToString("C");
                    LblLocalizacao.Text = quartos[t].Localidade.ToString();

                    //CARREGA ALUGUEL DO QUARTO SELECIONADO
                    AluguelNegocio aluguelNegocio = new AluguelNegocio();
                    //aluguel = aluguelNegocio.AluguelQuarto(quartos[t]);

                    //if (aluguel.Codigo != 0)
                    //{
                    //    if (aluguel.DataSaida is null)
                    //    {
                    //        LblDia.Text = aluguel.DataChegada.ToString("dd/MM/yyyy");
                    //        LblHorario.Text = aluguel.DataChegada.ToString("HH:mm:ss");
                    //        LblSituacao.Text = "Ocupado";
                    //    }
                    //    else
                    //    {
                    //        LblDia.Text = "";
                    //        LblHorario.Text = "";
                    //        LblSituacao.Text = "Livre";
                    //    }
                    //}
                    //else
                    //{
                    //    LblDia.Text = "";
                    //    LblHorario.Text = "";
                    //    LblSituacao.Text = "Livre";
                    //}
                    break;
                }
            }
        }




        /// <summary>
        /// BOTÕES DO FORMULÁRIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnQuarto1_Click(object sender, EventArgs e)
        {
            CarregaCampos(1, quartos.Count);
        }
        private void BtnQuarto2_Click(object sender, EventArgs e)
        {
            CarregaCampos(2, quartos.Count);
        }
        private void BtnQuarto3_Click(object sender, EventArgs e)
        {
            CarregaCampos(3, quartos.Count);
        }
        private void BtnQuarto4_Click(object sender, EventArgs e)
        {
            CarregaCampos(4, quartos.Count);
        }
        private void BtnQuarto5_Click(object sender, EventArgs e)
        {
            CarregaCampos(5, quartos.Count);
        }
        private void BtnQuarto6_Click(object sender, EventArgs e)
        {
            CarregaCampos(6, quartos.Count);
        }
        private void BtnQuarto7_Click(object sender, EventArgs e)
        {
            CarregaCampos(7, quartos.Count);
        }
        private void BtnQuarto8_Click(object sender, EventArgs e)
        {
            CarregaCampos(8, quartos.Count);
        }
        private void BtnQuarto9_Click(object sender, EventArgs e)
        {
            CarregaCampos(9, quartos.Count);
        }
        private void BtnQuarto10_Click(object sender, EventArgs e)
        {
            CarregaCampos(10, quartos.Count);
        }
        private void BtnQuarto11_Click(object sender, EventArgs e)
        {
            CarregaCampos(11, quartos.Count);
        }
        private void BtnQuarto12_Click(object sender, EventArgs e)
        {
            CarregaCampos(12, quartos.Count);
        }
        private void BtnQuarto13_Click(object sender, EventArgs e)
        {
            CarregaCampos(13, quartos.Count);
        }
        private void BtnQuarto14_Click(object sender, EventArgs e)
        {
            CarregaCampos(14, quartos.Count);
        }
        private void BtnQuarto15_Click(object sender, EventArgs e)
        {
            CarregaCampos(15, quartos.Count);
        }
        private void BtnQuarto16_Click(object sender, EventArgs e)
        {
            CarregaCampos(16, quartos.Count);
        }
        private void BtnQuarto17_Click(object sender, EventArgs e)
        {
            CarregaCampos(17, quartos.Count);
        }
        private void BtnQuarto18_Click(object sender, EventArgs e)
        {
            CarregaCampos(18, quartos.Count);
        }
        private void BtnQuarto19_Click(object sender, EventArgs e)
        {
            CarregaCampos(19, quartos.Count);
        }
        private void BtnQuarto20_Click(object sender, EventArgs e)
        {
            CarregaCampos(20, quartos.Count);
        }
        private void BtnQuarto21_Click(object sender, EventArgs e)
        {
            CarregaCampos(21, quartos.Count);
        }
        private void BtnQuarto22_Click(object sender, EventArgs e)
        {
            CarregaCampos(22, quartos.Count);
        }
        private void BtnQuarto23_Click(object sender, EventArgs e)
        {
            CarregaCampos(23, quartos.Count);
        }
        private void BtnQuarto24_Click(object sender, EventArgs e)
        {
            CarregaCampos(24, quartos.Count);
        }
        private void BtnQuarto25_Click(object sender, EventArgs e)
        {
            CarregaCampos(25, quartos.Count);
        }
        private void BtnQuarto26_Click(object sender, EventArgs e)
        {
            CarregaCampos(26, quartos.Count);
        }
        private void BtnQuarto27_Click(object sender, EventArgs e)
        {
            CarregaCampos(27, quartos.Count);
        }
        private void BtnQuarto28_Click(object sender, EventArgs e)
        {
            CarregaCampos(28, quartos.Count);
        }
        private void BtnQuarto29_Click(object sender, EventArgs e)
        {
            CarregaCampos(29, quartos.Count);
        }
        private void BtnQuarto30_Click(object sender, EventArgs e)
        {
            CarregaCampos(30, quartos.Count);
        }
        private void BtnQuarto31_Click(object sender, EventArgs e)
        {
            CarregaCampos(31, quartos.Count);
        }
        private void BtnQuarto32_Click(object sender, EventArgs e)
        {
            CarregaCampos(32, quartos.Count);
        }
        private void BtnQuarto33_Click(object sender, EventArgs e)
        {
            CarregaCampos(33, quartos.Count);
        }
        private void BtnQuarto34_Click(object sender, EventArgs e)
        {
            CarregaCampos(34, quartos.Count);
        }
        private void BtnQuarto35_Click(object sender, EventArgs e)
        {
            CarregaCampos(35, quartos.Count);
        }
        private void BtnQuarto36_Click(object sender, EventArgs e)
        {
            CarregaCampos(36, quartos.Count);
        }
        private void BtnQuarto37_Click(object sender, EventArgs e)
        {
            CarregaCampos(37, quartos.Count);
        }
        private void BtnQuarto38_Click(object sender, EventArgs e)
        {
            CarregaCampos(38, quartos.Count);
        }
        private void BtnQuarto39_Click(object sender, EventArgs e)
        {
            CarregaCampos(39, quartos.Count);
        }
        private void BtnQuarto40_Click(object sender, EventArgs e)
        {
            CarregaCampos(40, quartos.Count);
        }
        private void BtnQuarto41_Click(object sender, EventArgs e)
        {
            CarregaCampos(41, quartos.Count);
        }
        private void BtnQuarto42_Click(object sender, EventArgs e)
        {
            CarregaCampos(42, quartos.Count);
        }
        private void BtnQuarto43_Click(object sender, EventArgs e)
        {
            CarregaCampos(43, quartos.Count);
        }
        private void BtnQuarto44_Click(object sender, EventArgs e)
        {
            CarregaCampos(44, quartos.Count);
        }
        private void BtnQuarto45_Click(object sender, EventArgs e)
        {
            CarregaCampos(45, quartos.Count);
        }

    }
}