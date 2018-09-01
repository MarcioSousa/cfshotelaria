using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FrmSplashScreen : Form
    {
        public FrmSplashScreen()
        {
            InitializeComponent();
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
            decimal a, b;

            ProgressBar1.Visible = false;

            for (a = 0; a <= 1; a++)
            {
                b = a / 1;
                Opacity = Convert.ToDouble(b);
                Refresh();
            }

            Timer1.Enabled = true;
            Timer1.Interval = 5000;

            Timer2.Enabled = true;
            Timer2.Interval = 2000;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Hide();
            Timer1.Enabled = false;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            ProgressBar1.Visible = true;

            Timer2.Enabled = false;

            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 300;
            ProgressBar1.Value = 50;


            //Colocar algo para verificar se tem acesso ao banco de dados.
            //ClienteNegocio clienteNegocios = new ClienteNegocio();
            //ClienteColecao clienteColecao = clienteNegocios.Consultar("");

            ProgressBar1.Value = 299;
            Controls.Add(ProgressBar1);

        }
    }
}