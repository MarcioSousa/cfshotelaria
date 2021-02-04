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
using Control;

namespace Hotelaria
{
    public partial class FrmQuarto : Form
    {
        bool edicao = false;

        public FrmQuarto()
        {
            InitializeComponent();
            dgvQuarto.AutoGenerateColumns = false;
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }

        private void CarregaGrid()
        {
            List<Quarto> quartos = new List<Quarto>();
            DQL dql = new DQL();

            quartos = dql.Quartos();
            dgvQuarto.Rows.Add(quartos);

            dgvQuarto.DataSource = quartos;

            dgvQuarto.Update();
            dgvQuarto.Refresh();

            limpaCampos();
        }

        private void limpaCampos()
        {
            txtLocalidade.Text = "";
            txtValorDiaria.Text = "";
            txtNumero.Text = "";
            txtNumero.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DML dml = new DML();

            if (txtNumero.Text != "" && txtValorDiaria.Text != "" & txtLocalidade.Text != "")
            {
                if (edicao)
                {
                    Quarto quarto = new Quarto();
                    quarto.Numero = Convert.ToInt32(txtNumero.Text);
                    quarto.ValorDiaria = Convert.ToDouble(txtValorDiaria.Text);
                    quarto.Localidade = txtLocalidade.Text;

                    dml.QuartoAlterar(quarto);

                    edicao = false;
                }
                else
                {
                    Quarto quarto = new Quarto();
                    quarto.Numero = Convert.ToInt32(txtNumero.Text);
                    quarto.ValorDiaria = Convert.ToDouble(txtValorDiaria.Text);
                    quarto.Localidade = txtLocalidade.Text;

                    dml.QuartoInserir(quarto);
                }

                dgvQuarto.DataSource = null;
                CarregaGrid();

            }
            else
            {
                if (txtNumero.Text.Trim() == "")
                {
                    epNumero.SetError(txtNumero, "Preencha com o número do quarto.");
                    txtNumero.Focus();
                }
                else if (txtValorDiaria.Text.Trim() == "")
                {
                    epNumero.SetError(txtValorDiaria, "Preencha com o Valor da Diária.");
                    txtValorDiaria.Focus();
                }
                else
                {
                    epNumero.SetError(txtLocalidade, "Preencha com a Localidade do quarto.");
                    txtLocalidade.Focus();
                }
            }


      
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            iniciarcadastro();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            edicao = true;
            txtNumero.Text = dgvQuarto.Rows[dgvQuarto.CurrentRow.Index].Cells[0].Value.ToString();
            txtValorDiaria.Text = Convert.ToDouble(dgvQuarto.Rows[dgvQuarto.CurrentRow.Index].Cells[1].Value).ToString("C2").Replace("R$", "");
            txtLocalidade.Text = dgvQuarto.Rows[dgvQuarto.CurrentRow.Index].Cells[2].Value.ToString();
            txtNumero.Focus();
        }

        private void iniciarcadastro()
        {
            gbxDados.Visible = true;
            btnAlterar.Visible = false;
            btnExcluir.Visible = false;
            dgvQuarto.Enabled = false;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            epNumero.Clear();
        }

        private void txtValorDiaria_TextChanged(object sender, EventArgs e)
        {
            epNumero.Clear();
        }

        private void txtLocalidade_TextChanged(object sender, EventArgs e)
        {
            epNumero.Clear();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == (char)Keys.Back)
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                txtNumero.Text = "";
                epNumero.SetError(txtNumero, "Digite um número inteiro válido." + ex.Message);
            }
        }

        private void txtValorDiaria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if(e.KeyChar == ',')
            {
                e.Handled = false;
            }
            if(e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DML dml = new DML();
            Quarto quarto = new Quarto();
            quarto.Numero = Convert.ToInt32(dgvQuarto.Rows[dgvQuarto.CurrentRow.Index].Cells[0].Value);
            dml.QuartoExcluir(quarto);
            MessageBox.Show("Quarto Excluído com Sucesso!");
            dgvQuarto.DataSource = null; 
            CarregaGrid();
        }
    }
}
