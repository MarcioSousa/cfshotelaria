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
        int numeroAntigo;

        public FrmQuarto()
        {
            InitializeComponent();
            dgvQuarto.AutoGenerateColumns = false;
        }
        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        private void VerificaCampos()
        {
            if (dgvQuarto.Rows.Count != 0)
            {
                btnAlterar.Enabled = true;
                btnExcluir.Enabled = true;
            }
            else
            {
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
            }
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
            VerificaCampos();
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

            try
            {
                if (txtNumero.Text != "" && txtValorDiaria.Text != "" & txtLocalidade.Text != "")
                {
                    Quarto quarto = new Quarto();
                    quarto.Numero = Convert.ToInt32(txtNumero.Text);
                    quarto.ValorDiaria = Convert.ToDouble(txtValorDiaria.Text);
                    quarto.Localidade = txtLocalidade.Text;

                    if (edicao)
                    {
                        MessageBox.Show(dml.QuartoAlterar(quarto, numeroAntigo), "Alterado com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnAlterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        edicao = false;

                        numeroAntigo = 0;
                    }
                    else
                    {
                        if (dml.QuartoInserir(quarto) != "1")
                        {
                            MessageBox.Show("Erro ao fazer a inserção!", "Não cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

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
            catch (Exception ex)
            {
                MessageBox.Show("Verifique os valores cadastrados!\n" + ex.Message, "Não Registrado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            numeroAntigo = Convert.ToInt32(txtNumero.Text);
            txtNumero.Focus();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
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
            if (e.KeyChar == ',')
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DML dml = new DML();
            Quarto quarto = new Quarto();
            quarto.Numero = Convert.ToInt32(dgvQuarto.Rows[dgvQuarto.CurrentRow.Index].Cells[0].Value);


            if (MessageBox.Show("Deseja realmente excluir o registro selecionado?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dml.QuartoExcluir(quarto);
                    MessageBox.Show("Quarto Excluído com Sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a exclusão!\n" + ex.Message, "Cancelado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvQuarto.DataSource = null;
                CarregaGrid();
            }

        }

    }
}
