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
    public partial class FrmCliente : Form
    {
        List<Cliente> clientes;

        public FrmCliente(List<Cliente> clientes)
        {
            InitializeComponent();
            this.clientes = clientes;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            if (clientes.Count != 0)
            {
                MessageBox.Show(clientes[0].Aluguel.Codigo.ToString());
                LblAluguel.Text = "Aluguel Nº " + clientes[0].Aluguel.Codigo.ToString();
            }

            for (int t = 0; t < clientes.Count; t++)
            {
                DgvCliente.Rows.Add(clientes[t].Aluguel.Codigo.ToString(), clientes[t].Codigo.ToString(), clientes[t].Nome.ToString(), clientes[t].Rg.ToString(), clientes[t].Cpf.ToString(), clientes[t].Contato.ToString());
            }

        }

        private void DgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtCodigo.Text = DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[1].Value.ToString();
            TxtNome.Text = DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[2].Value.ToString();
            TxtRg.Text = DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[3].Value.ToString();
            TxtCpf.Text = DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[4].Value.ToString();
            TxtContato.Text = DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[5].Value.ToString();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            AbrirBotoes();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            AbrirBotoes();
        }

        public void AbrirBotoes()
        {
            DgvCliente.Enabled = false;

            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;

            BtnLimpar.Enabled = true;
            BtnFinalizar.Enabled = true;

            BtnExcluir.Enabled = false;
            BtnFinalizar.Enabled = false;
        }

        public void LimparCampos()
        {
            TxtNome.Text = "";
            TxtRg.Text = "";
            TxtCpf.Text = "";
            TxtContato.Text = "";
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            if(LblAluguel.Text == "Aluguel Nº ")
            {

            }
        }
    }
}
