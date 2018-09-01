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

        private void button1_Click(object sender, EventArgs e)
        {
            //Produto produto1 = new Produto(1, "Café",12.00, 30);
            //Produto produto2 = new Produto(2, "Almoço", 10.00, 20);
            //Produto produto3 = new Produto(3, "Sobremesa", 13.00, 20);

            //produto1.Entradas.Add(new Entrada(2, Convert.ToDateTime("01/01/2015"), Convert.ToDateTime("01/01/2019"), 30));
            //produto2.Entradas.Add(new Entrada(1, Convert.ToDateTime("10/03/2015"), Convert.ToDateTime("13/09/2015"), 30));

            //MessageBox.Show(produto1.Entradas[0].Codigo.ToString());

            ////////////////////////////////////////////////////////////////////////////////////

            Produto[] produtos = new Produto[3];
            produtos[0] = new Produto(1, "Café", 12.00, 30);
            produtos[1] = new Produto(2, "Almoço", 10.00, 20);
            produtos[2] = new Produto(3, "Sobremesa", 13.00, 20);

            produtos[0].Entradas.Add(new Entrada(5, Convert.ToDateTime("01/01/2015"), Convert.ToDateTime("01/01/2019"), 30));
            produtos[1].Entradas.Add(new Entrada(1, Convert.ToDateTime("10/03/2015"), Convert.ToDateTime("13/09/2015"), 30));

            for (int t = 0; t < produtos.Count(); t++)
            {
                MessageBox.Show(produtos[t].Codigo.ToString() + " - " +
                   produtos[t].Nome.ToString() + " - " +
                   produtos[t].Valor.ToString("N2") + " - " +
                   produtos[t].Qtdeatual.ToString());
                if (produtos[t].Entradas.Count != 0)
                {
                    for (int u = 0; u < produtos[t].Entradas.Count; u++)
                    {
                        MessageBox.Show(produtos[t].Entradas[u].Codigo.ToString() + " - " +
                            produtos[t].Entradas[u].DataEntrada.ToString() + " - " +
                            produtos[t].Entradas[u].DataVencimento.ToString() + " - " +
                            produtos[t].Entradas[u].Qtde.ToString());
                    }
                }
            }
        }
    }
}