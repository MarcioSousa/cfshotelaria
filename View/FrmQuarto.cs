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
            CarregaClientes();
            CarregaPagamentos();
            CarregaProdutos();
            CarregaPedidos();
        }

        private void CarregaQuartos()
        {
            QuartoNegocio quartoNegocio = new QuartoNegocio();

            quartos = quartoNegocio.Quartos();

            //ORGANIZA TODOS OS QUARTOS EM ORDEM CRESCENTE
            InsertionSort(quartos);

            //CARREGA TODAS AS LISTAS DE LIMPEZAS DO OBJETO QUARTO E TAMBÉM O ALUGUEL
            for (int t = 0; t < quartos.Count; t++)
            {
                quartoNegocio.AddLimpezas(quartos[t]);
            }

            //TROCANDO CORES DOS BOTÕES PARA MOSTRAR OS QUARTOS QUE ESTÃO OCUPADOS
            List<Quarto> quartosOcupados = new List<Quarto>();
            quartosOcupados = quartoNegocio.QuartosOcupados();

            for (int u = 0; u < quartosOcupados.Count; u++)
            {
                for (int v = 0; v < quartos.Count; v++)
                {
                    if(quartosOcupados[u].Numero == quartos[v].Numero)
                    {
                        BotaoVermelho(quartos[v].Numero);
                        break;
                    }

                }
            }
        }
        private void CarregaLimpezas()
        {
            QuartoNegocio quartoNegocio = new QuartoNegocio();
            LimpezaNegocio limpezaNegocio = new LimpezaNegocio();

            limpezas = limpezaNegocio.Limpezas(quartos);

            dgvLimpeza.DataSource = limpezas;

            dgvLimpeza.Refresh();
            dgvLimpeza.Update();
        }
        private void CarregaAlugueis()
        {
            AluguelNegocio aluguelNegocio = new AluguelNegocio();

            alugueis = aluguelNegocio.Alugueis(quartos);

            for (int t = 0; t < alugueis.Count; t++)
            {
                aluguelNegocio.AddClientes(alugueis[t]);
                aluguelNegocio.AddPagamentos(alugueis[t]);
                aluguelNegocio.AddPedidos(alugueis[t]);
            }

        }
        private void CarregaClientes()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clientes = clienteNegocio.Clientes(alugueis);

        }
        private void CarregaPagamentos()
        {
            PagamentoNegocio pagamentoNegocio = new PagamentoNegocio();
            pagamentos = pagamentoNegocio.Pagamentos(alugueis);
        }
        private void CarregaPedidos()
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            pedidos = pedidoNegocio.Pedidos(alugueis);

            for (int t = 0; t < pedidos.Count; t++)
            {
                pedidoNegocio.AddItemPedidos(pedidos[t], produtos);
            }
        }
        private void CarregaProdutos()
        {
            ProdutoNegocio produtoNegocio = new ProdutoNegocio();
            produtos = produtoNegocio.Produtos();
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

//public void VerificarDados()
//{



    //quartos[0] = new Quarto(20, 80.00, "2º Andar");
    //quartos[1] = new Quarto(21, 98.00, "3º Andar");
    //quartos[2] = new Quarto(10, 85.00, "Térreo");
    //quartos[3] = new Quarto(11, 102.00, "Térreo");
    //quartos[4] = new Quarto(12, 98.00, "1º Andar");

    //limpezas[0] = new Limpeza(1, Convert.ToDateTime("16/09/2018 16:00"), quartos[0]);
    //limpezas[1] = new Limpeza(2, Convert.ToDateTime("17/09/2018 19:00"), quartos[1]);
    //limpezas[2] = new Limpeza(3, Convert.ToDateTime("14/08/2018 19:30"), quartos[0]);
    //limpezas[3] = new Limpeza(4, Convert.ToDateTime("12/08/2018 20:00"), quartos[2]);
    //limpezas[4] = new Limpeza(5, Convert.ToDateTime("19/08/2018 20:00"), quartos[0]);

    //quartos[0].Limpezas.Add(limpezas[0]);
    //quartos[0].Limpezas.Add(limpezas[2]);
    //quartos[0].Limpezas.Add(limpezas[4]);
    //quartos[1].Limpezas.Add(limpezas[1]);
    //quartos[2].Limpezas.Add(limpezas[3]);

    ////=================================================================================
    //produtos[0] = new Produto(1, "Cerveja Lata", 6.00);
    //produtos[0].Qtdeatual = 20;
    //produtos[1] = new Produto(2, "Suco", 5.50);
    //produtos[1].Qtdeatual = 10;
    //produtos[2] = new Produto(3, "Cerveja Garrafa", 13.00);
    //produtos[2].Qtdeatual = 30;
    //produtos[3] = new Produto(4, "Lanche da Manhã", 22.00);
    //produtos[4] = new Produto(5, "Almoço", 15.00);

    //entradas[0] = new Entrada(1, Convert.ToDateTime("15/09/2018"), Convert.ToDateTime("15/09/2019"), 20, produtos[0]);
    //entradas[1] = new Entrada(2, Convert.ToDateTime("11/08/2018"), Convert.ToDateTime("11/08/2019"), 20, produtos[2]);
    //entradas[2] = new Entrada(3, Convert.ToDateTime("15/08/2018"), Convert.ToDateTime("15/08/2019"), 10, produtos[2]);
    //entradas[3] = new Entrada(4, Convert.ToDateTime("16/09/2018"), Convert.ToDateTime("16/09/2019"), 30, produtos[0]);
    //entradas[4] = new Entrada(5, Convert.ToDateTime("14/08/2018"), Convert.ToDateTime("14/09/2018"), 20, produtos[1]);

    //produtos[0].Entradas.Add(entradas[3]);
    //produtos[0].Entradas.Add(entradas[0]);
    //produtos[1].Entradas.Add(entradas[4]);
    //produtos[2].Entradas.Add(entradas[1]);
    //produtos[2].Entradas.Add(entradas[2]);

    ////=================================================================================
    //aluguels[0] = new Aluguel(1, 80.00, Convert.ToDateTime("16/09/2018 20:00"), quartos[0]);
    //aluguels[1] = new Aluguel(2, 80.00, Convert.ToDateTime("19/09/2018 21:00"), quartos[1]);
    //aluguels[2] = new Aluguel(3, 102.00, Convert.ToDateTime("15/09/2018 19:00"), quartos[3]);
    //aluguels[3] = new Aluguel(4, 150.00, Convert.ToDateTime("12/08/2018 20:00"), quartos[2]);
    //aluguels[4] = new Aluguel(5, 210.00, Convert.ToDateTime("15/08/2018 20:00"), quartos[4]);

    //clientes[0] = new Cliente(1, "Marcio", "12121212", "12121233", "1111111", aluguels[0]);
    //clientes[1] = new Cliente(2, "Roberta", "1201010", "1232010", "2222222", aluguels[0]);
    //clientes[2] = new Cliente(3, "Rafael", "1200210", "989655", "1256322", aluguels[1]);
    //clientes[3] = new Cliente(4, "Leandro", "12010020", "452122232", "85655232", aluguels[2]);
    //clientes[4] = new Cliente(5, "João", "12001020", "12523200", "12002320", aluguels[3]);
    //clientes[5] = new Cliente(6, "Hugo", "10101010", "11122222", "1198556552", aluguels[4]);

    ////Alugueis com os clientes
    //aluguels[0].DataSaida = Convert.ToDateTime("19/09/2018 20:00");
    //aluguels[0].Clientes.Add(clientes[0]);
    //aluguels[0].Clientes.Add(clientes[1]);
    //aluguels[1].Clientes.Add(clientes[2]);
    //aluguels[2].Clientes.Add(clientes[3]);
    //aluguels[3].Clientes.Add(clientes[4]);
    //aluguels[4].Clientes.Add(clientes[5]);

    //pagamentos[0] = new Pagamento(1, "Crédito", Convert.ToDateTime("19/09/2018 20:00"), 120.00, aluguels[0]);
    //pagamentos[1] = new Pagamento(2, "Dinheiro", Convert.ToDateTime("19/09/2018 20:00"), 100.00, aluguels[0]);
    //pagamentos[2] = new Pagamento(3, "Dinheiro", Convert.ToDateTime("19/09/2018 20:03"), 136.50, aluguels[0]);
    //pagamentos[3] = new Pagamento(4, "Dinheiro", Convert.ToDateTime("19/09/2018 21:00"), 80.00, aluguels[1]);
    //pagamentos[4] = new Pagamento(5, "Cartão", Convert.ToDateTime("15/09/2018 22:00"), 50.00, aluguels[2]);

    //aluguels[0].Pagamentos.Add(pagamentos[0]);
    //aluguels[0].Pagamentos.Add(pagamentos[1]);
    //aluguels[0].Pagamentos.Add(pagamentos[2]);
    //aluguels[1].Pagamentos.Add(pagamentos[3]);
    //aluguels[2].Pagamentos.Add(pagamentos[4]);

    //pedidos[0] = new Pedido(1, Convert.ToDateTime("16/09/2018 20:00"), aluguels[0]);
    //pedidos[1] = new Pedido(2, Convert.ToDateTime("16/09/2018 22:00"), aluguels[0]);
    //pedidos[2] = new Pedido(3, Convert.ToDateTime("19/09/2018 23:00"), aluguels[1]);
    //pedidos[3] = new Pedido(4, Convert.ToDateTime("13/08/2018 22:00"), aluguels[3]);
    //pedidos[4] = new Pedido(5, Convert.ToDateTime("15/09/2018 20:00"), aluguels[2]);

    //aluguels[0].Pedidos.Add(pedidos[0]);
    //aluguels[0].Pedidos.Add(pedidos[1]);
    //aluguels[1].Pedidos.Add(pedidos[2]);
    //aluguels[2].Pedidos.Add(pedidos[4]);
    //aluguels[3].Pedidos.Add(pedidos[3]);

    //itemPedidos[0] = new ItemPedido(1, 2, 6.00, produtos[0], pedidos[0]);
    //itemPedidos[1] = new ItemPedido(2, 1, 6.00, produtos[0], pedidos[0]);
    //itemPedidos[2] = new ItemPedido(3, 1, 5.50, produtos[1], pedidos[0]);
    //itemPedidos[3] = new ItemPedido(4, 1, 13.00, produtos[2], pedidos[1]);
    //itemPedidos[4] = new ItemPedido(5, 3, 15.00, produtos[1], pedidos[2]);
    //itemPedidos[5] = new ItemPedido(6, 1, 22.00, produtos[3], pedidos[3]);
    //itemPedidos[6] = new ItemPedido(7, 1, 15.00, produtos[4], pedidos[4]);

    //produtos[0].ItemPedidos.Add(itemPedidos[0]);
    //produtos[0].ItemPedidos.Add(itemPedidos[1]);
    //produtos[1].ItemPedidos.Add(itemPedidos[2]);
    //produtos[1].ItemPedidos.Add(itemPedidos[4]);
    //produtos[2].ItemPedidos.Add(itemPedidos[3]);
    //produtos[3].ItemPedidos.Add(itemPedidos[5]);
    //produtos[4].ItemPedidos.Add(itemPedidos[6]);

    //pedidos[0].ItemPedidos.Add(itemPedidos[0]);
    //pedidos[0].ItemPedidos.Add(itemPedidos[1]);
    //pedidos[0].ItemPedidos.Add(itemPedidos[2]);
    //pedidos[1].ItemPedidos.Add(itemPedidos[3]);
    //pedidos[2].ItemPedidos.Add(itemPedidos[4]);
    //pedidos[3].ItemPedidos.Add(itemPedidos[5]);
    //pedidos[4].ItemPedidos.Add(itemPedidos[6]);

//}