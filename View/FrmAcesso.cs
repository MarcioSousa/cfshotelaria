using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace View
{
    public partial class FrmAcesso : Form
    {
        public bool abrirPrincipal = true;

        public FrmAcesso()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            abrirPrincipal = false;
            this.Close();
        }

        private void BtnAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Favor entrar em contato!");
        }

        private void BtnAcessar_Click(object sender, EventArgs e)
        {
            if (TxtAcesso.Text == "" && TxtSenha.Text == "")
            {
                abrirPrincipal = true;
                this.Close();
            }
        }

    }
}