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

namespace View
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmSplashScreen splashScreen = new FrmSplashScreen();
            splashScreen.ShowDialog();
            FrmAcesso acesso = new FrmAcesso();
            acesso.ShowDialog();

            if (!acesso.abrirPrincipal)
            {
                this.Close();
            }
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            //Clientes
            Cliente[] clientes = new Cliente[5];
            clientes[0] = new Cliente(1, "Roberto", "12121212", "12121233", "1111111");
            clientes[1] = new Cliente(2, "Marcio", "1201010", "1232010", "2222222");
            clientes[2] = new Cliente(3, "Roberta", "1200210", "989655", "1256322");
            clientes[3] = new Cliente(4, "Anderson", "12010020", "452122232", "85655232");
            clientes[4] = new Cliente(5, "Leandro", "12001020", "12523200", "12002320");

            //Quartos
            Quarto[] quartos = new Quarto[5];
            quartos[0] = new Quarto(1, 13, 60.00);
            quartos[1] = new Quarto(2, 21, 85.00);
            quartos[2] = new Quarto(3, 12, 60.00);
            quartos[3] = new Quarto(4, 13, 60.00);
            quartos[4] = new Quarto(5, 21, 85.00);

            //Pagamentos
            Pagamento[] pagamentos = new Pagamento[3];
            pagamentos[0] = new Pagamento(1, "Cartão", Convert.ToDateTime("11/04/2015 12:00"), 100.00);
            pagamentos[1] = new Pagamento(2, "Dinheiro", Convert.ToDateTime("11/04/2015 12:00"), 67.00);
            pagamentos[2] = new Pagamento(3, "Cartão", Convert.ToDateTime("15/03/2015 08:00"), 121.00);

            //Pedidos
            Pedido[] pedidos = new Pedido[3];
            pedidos[0] = new Pedido(1, Convert.ToDateTime("11/04/2015 06:00"));
            pedidos[1] = new Pedido(2, Convert.ToDateTime("11/04/2015 09:00"));
            pedidos[2] = new Pedido(3, Convert.ToDateTime("14/05/2015 17:00"));

            //ItemPedidos
            ItemPedido[] itemPedidos = new ItemPedido[6];
            itemPedidos[0] = new ItemPedido(1, 1, 10.00);
            itemPedidos[1] = new ItemPedido(2, 1, 10.00);
            itemPedidos[2] = new ItemPedido(3, 3, 12.00);
            itemPedidos[3] = new ItemPedido(4, 1, 12.00);
            itemPedidos[4] = new ItemPedido(5, 2, 13.00);
            itemPedidos[5] = new ItemPedido(6, 3, 12.00);

            //Produtos
            Produto[] produtos = new Produto[3];
            produtos[0] = new Produto(1, "Café", 12.00, 30);
            produtos[1] = new Produto(2, "Almoço", 10.00, 20);
            produtos[2] = new Produto(3, "Sobremesa", 13.00, 30);

            //Entrada
            Entrada[] entradas = new Entrada[2];
            entradas[0] = new Entrada(1, Convert.ToDateTime("10/03/2015"), Convert.ToDateTime("13/09/2015"), 30);
            entradas[1] = new Entrada(2, Convert.ToDateTime("01/01/2015"), Convert.ToDateTime("01/01/2019"), 30);

            //Cliente e Quarto
            clientes[0].Quarto = quartos[0];
            clientes[1].Quarto = quartos[0];
            clientes[2].Quarto = quartos[1];
            clientes[3].Quarto = quartos[1];
            clientes[4].Quarto = quartos[2];

            //Pagamentos e Quarto
            pagamentos[0].Quarto = quartos[0];
            pagamentos[1].Quarto = quartos[0];
            pagamentos[2].Quarto = quartos[1];

            //Pedido e Quarto
            pedidos[0].Quarto = quartos[0];
            pedidos[1].Quarto = quartos[0];
            pedidos[2].Quarto = quartos[1];

            //ItemPedido e Pedido
            itemPedidos[0].Pedido = pedidos[0];
            itemPedidos[1].Pedido = pedidos[0];
            itemPedidos[2].Pedido = pedidos[0];
            itemPedidos[3].Pedido = pedidos[1];
            itemPedidos[4].Pedido = pedidos[1];
            itemPedidos[5].Pedido = pedidos[2];

            //ItemPedido e Produto
            itemPedidos[0].Produto = produtos[1];
            itemPedidos[1].Produto = produtos[1];
            itemPedidos[2].Produto = produtos[0];
            itemPedidos[3].Produto = produtos[0];
            itemPedidos[4].Produto = produtos[2];
            itemPedidos[5].Produto = produtos[0];

            //Entrada e Produto
            entradas[0].Produto = produtos[1];
            entradas[1].Produto = produtos[0];

            //Quarto e Cliente
            for (int x = 0; x < quartos.Count(); x++)
            {
                for (int y = 0; y < clientes.Count(); y++)
                {
                    if (quartos[x].Codigo == clientes[y].Quarto.Codigo)
                    {
                        quartos[x].Clientes.Add(clientes[y]);
                    }
                }
            }

            //Quarto e Pagamento
            for (int x = 0; x < quartos.Count(); x++)
            {
                for (int y = 0; y < pagamentos.Count(); y++)
                {
                    if (quartos[x].Codigo == pagamentos[y].Quarto.Codigo)
                    {
                        quartos[x].Pagamentos.Add(pagamentos[y]);
                    }
                }
            }

            //Quarto e Pedido
            for (int x = 0; x < quartos.Count(); x++)
            {
                for (int y = 0; y < pedidos.Count(); y++)
                {
                    if (quartos[x].Codigo == pedidos[y].Quarto.Codigo)
                    {
                        quartos[x].Pedidos.Add(pedidos[y]);
                    }
                }
            }

            //Pedido e ItemPedido
            for (int x = 0; x < pedidos.Count(); x++)
            {
                for (int y = 0; y < itemPedidos.Count(); y++)
                {
                    if (pedidos[x].Codigo == itemPedidos[y].Pedido.Codigo)
                    {
                        pedidos[x].ItemPedidos.Add(itemPedidos[y]);
                    }
                }
            }

            //Produto e ItemPedido
            for (int x = 0; x < produtos.Count(); x++)
            {
                for (int y = 0; y < itemPedidos.Count(); y++)
                {
                    if (produtos[x].Codigo == itemPedidos[y].Produto.Codigo)
                    {
                        produtos[x].ItemPedidos.Add(itemPedidos[y]);
                    }
                }
            }

            //Entrada e Produto
            for (int x = 0; x < entradas.Count(); x++)
            {
                for (int y = 0; y < produtos.Count(); y++)
                {
                    if (entradas[x].Produto.Codigo == produtos[y].Codigo)
                    {
                        produtos[y].Entradas.Add(entradas[y]);
                    }
                }
            }

            //===============================================
            //===============================================
            for (int u = 0; u < clientes.Count(); u++)
            {
                MessageBox.Show(clientes[u].ToString());
            }

            for (int u = 0; u < quartos.Count(); u++)
            {
                MessageBox.Show(quartos[u].ToString());
            }

            for (int u = 0; u < pagamentos.Count(); u++)
            {
                MessageBox.Show(pagamentos[u].ToString());
            }

            for(int u = 0; u < pedidos.Count(); u++)
            {
                MessageBox.Show(pedidos[u].ToString());
            }

            for (int u = 0; u < itemPedidos.Count(); u++)
            {
                MessageBox.Show(itemPedidos[u].ToString());
            }

            for (int u = 0; u < produtos.Count(); u++)
            {
                MessageBox.Show(produtos[u].ToString());
            }

            for (int u = 0; u < entradas.Count(); u++)
            {
                MessageBox.Show(entradas[u].ToString());
            }

        }

    }
}