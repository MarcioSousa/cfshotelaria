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

        private void pbxQuarto1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("teste");
        }
    }
}