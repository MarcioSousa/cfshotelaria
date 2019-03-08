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
    public partial class FrmPrincipal : Form
    {
        //List<Limpeza> limpezas = new List<Limpeza>();
        //List<Quarto> quartos = new List<Quarto>();
        //List<Aluguel> aluguels = new List<Aluguel>();
        //List<Cliente> clientes = new List<Cliente>();
        //List<Pagamento> pagamentos = new List<Pagamento>();
        //List<Pedido> pedidos = new List<Pedido>();
        //List<Produto> produtos = new List<Produto>();
        //List<Entrada> entradas = new List<Entrada>();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //FrmSplashScreen splashScreen = new FrmSplashScreen();
            //splashScreen.ShowDialog();
            //FrmAcesso acesso = new FrmAcesso();
            //acesso.ShowDialog();

            //if (!acesso.abrirPrincipal)
            //{
            //    this.Close();
            //}

            //QuartoNegocio quartoNegocio = new QuartoNegocio();

            //quartos[0] = new Quarto(20, 80.00, "2º Andar");
            //quartos[1] = new Quarto(21, 98.00, "3º Andar");
            //quartos[2] = new Quarto(10, 85.00, "Térreo");
            //quartos[3] = new Quarto(11, 102.00, "Térreo");
            //quartos[4] = new Quarto(12, 98.00, "1º Andar");

            //limpezas[0] = new Limpeza(1, DateTime.Now, quartos[0]);
            //limpezas[1] = new Limpeza(2, DateTime.Now, quartos[1]);
            //limpezas[2] = new Limpeza(3, DateTime.Now, quartos[0]);
            //limpezas[3] = new Limpeza(4, DateTime.Now, quartos[2]);
            //limpezas[4] = new Limpeza(5, DateTime.Now, quartos[0]);

            //quartos[0].Limpezas.Add(limpezas[0]);
            ////ou
            //quartoNegocio.AddLimpezas(quartos[0]);
            





        }

        private void picQuarto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAluguel aluguel = new FrmAluguel();
                aluguel.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PicEstoque_Click(object sender, EventArgs e)
        {
            FrmEstoque frmEstoque = new FrmEstoque();
            frmEstoque.ShowDialog();
        }

        private void PicEstatistica_Click(object sender, EventArgs e)
        {
            FrmEstatistica frmEstatistica = new FrmEstatistica();
            frmEstatistica.ShowDialog();
        }
    }
}




//}                 private void btnProduto_Click(object sender, EventArgs e)
//        {
//            for (int t = 0; t < produtos.Count(); t++)
//            {
//                MessageBox.Show(produtos[t].ToString());
//            }
//        }


        //private void btnLimpeza_Click(object sender, EventArgs e)
        //{
        //    for (int t = 0; t < limpezas.Count(); t++)
        //    {
        //        MessageBox.Show(limpezas[t].ToString());
        //    }
        //}
        //private void btnPagamento_Click(object sender, EventArgs e)
        //{
        //    for (int t = 0; t < pagamentos.Count(); t++)
        //    {
        //        MessageBox.Show(pagamentos[t].ToString());
        //    }
        //}
        //private void btnEntrada_Click(object sender, EventArgs e)
        //{
        //    for (int t = 0; t < entradas.Count(); t++)
        //    {
        //        MessageBox.Show(entradas[t].ToString());
        //    }
        //}
        //private void btnQuarto_Click(object sender, EventArgs e)
        //{
        //    for (int t = 0; t < quartos.Count(); t++)
        //    {
        //        MessageBox.Show(quartos[t].ToString());
        //    }
        //}
        //private void btnAluguel_Click(object sender, EventArgs e)
        //{
        //    for (int t = 0; t < aluguels.Count(); t++)
        //    {
        //        MessageBox.Show(aluguels[t].ToString());
        //    }
        //}
        //private void btnCliente_Click(object sender, EventArgs e)
        //{
        //    for (int t = 0; t < clientes.Count(); t++)
        //    {
        //        MessageBox.Show(clientes[t].ToString());
        //    }
        //}
        //private void btnPedido_Click(object sender, EventArgs e)
        //{
        //    for (int t = 0; t < pedidos.Count(); t++)
        //    {
        //        MessageBox.Show(pedidos[t].ToString());
        //    }
        //}      
//Limpeza[] limpezas = new Limpeza[5];
        //Quarto[] quartos = new Quarto[5];
        //Aluguel[] aluguels = new Aluguel[5];
        //Cliente[] clientes = new Cliente[6];
        //Pagamento[] pagamentos = new Pagamento[5];
        //Pedido[] pedidos = new Pedido[5];
        //Produto[] produtos = new Produto[5];
        //Entrada[] entradas = new Entrada[5];
////=================================================================================
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

            //pagamentos[0] = new Pagamento(1, "Crédito", Convert.ToDateTime("19/09/2018 20:00"), 120.00,aluguels[0]);
            //pagamentos[1] = new Pagamento(2, "Dinheiro", Convert.ToDateTime("19/09/2018 20:00"), 100.00,aluguels[0]);
            //pagamentos[2] = new Pagamento(3, "Dinheiro", Convert.ToDateTime("19/09/2018 20:03"), 136.50,aluguels[0]);
            //pagamentos[3] = new Pagamento(4, "Dinheiro", Convert.ToDateTime("19/09/2018 21:00"), 80.00,aluguels[1]);
            //pagamentos[4] = new Pagamento(5, "Cartão", Convert.ToDateTime("15/09/2018 22:00"), 50.00,aluguels[2]);

            //aluguels[0].Pagamentos.Add(pagamentos[0]);
            //aluguels[0].Pagamentos.Add(pagamentos[1]);
            //aluguels[0].Pagamentos.Add(pagamentos[2]);
            //aluguels[1].Pagamentos.Add(pagamentos[3]);
            //aluguels[2].Pagamentos.Add(pagamentos[4]);


            //aluguels[0].Pedidos.Add(pedidos[0]);
            //aluguels[0].Pedidos.Add(pedidos[1]);
            //aluguels[1].Pedidos.Add(pedidos[2]);
            //aluguels[2].Pedidos.Add(pedidos[4]);
            //aluguels[3].Pedidos.Add(pedidos[3]);