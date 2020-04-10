using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Model;

namespace View
{
    public partial class FrmQuarto : Form
    {

        public FrmQuarto()
        {
            InitializeComponent();
            DgvQuarto.AutoGenerateColumns = false;
        }
        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            CarregaQuartos();

            if (DgvQuarto.Rows.Count == 0)
            {
                BtnExcluir.Enabled = false;
                BtnEditar.Enabled = false;
            }
            else
            {
                BtnExcluir.Enabled = true;
                BtnEditar.Enabled = true;
            }
        }
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtNumero.TextLength != 0 && TxtValorDiaria.TextLength != 0)
                {
                    if (TxtNumero.Enabled == true)
                    {
                        //NOVO QUARTO
                        bool achouCodigo = false;
                        if (DgvQuarto.Rows.Count != 0)
                        {

                            for (int t = 0; t < DgvQuarto.Rows.Count; t++)
                            {
                                if (Convert.ToInt32(DgvQuarto.Rows[t].Cells[0].Value) == Convert.ToInt32(TxtNumero.Text))
                                {
                                    achouCodigo = true;
                                    MessageBox.Show("Já tem um quarto com esse número, coloque um outro número no quarto!", "Número Repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    TxtNumero.Focus();
                                    break;
                                }
                                achouCodigo = false;
                            }
                            if (achouCodigo == false)
                            {
                                Quarto quarto = new Quarto(Convert.ToInt32(TxtNumero.Text), Convert.ToDouble(TxtValorDiaria.Text), TxtLocalidade.Text);
                                QuartoNegocio quartoNegocio = new QuartoNegocio();
                                quartoNegocio.Inserir(quarto);
                                CarregaQuartos();
                                LimpaCampos();
                                TxtNumero.Focus();
                            }
                        }
                        else
                        {
                            Quarto quarto = new Quarto(Convert.ToInt32(TxtNumero.Text), Convert.ToDouble(TxtValorDiaria.Text), TxtLocalidade.Text);
                            QuartoNegocio quartoNegocio = new QuartoNegocio();
                            quartoNegocio.Inserir(quarto);
                            CarregaQuartos();
                            LimpaCampos();
                            TxtNumero.Focus();
                        }
                    }
                    else
                    {//EDITA QUARTO CADASTRADO
                        Quarto quarto = new Quarto(Convert.ToInt32(TxtNumero.Text), Convert.ToDouble(TxtValorDiaria.Text), TxtLocalidade.Text);
                        QuartoNegocio quartoNegocio = new QuartoNegocio();
                        quartoNegocio.Alterar(quarto);
                        CarregaQuartos();
                        FechaCampos();
                        CarregaCampos();
                        BtnNovo.Focus();
                        BtnAdicionar.Text = "Adicionar";
                    }
                }
                else
                {
                    MessageBox.Show("Prencha os campos com o Número do quarto e o Valor de sua diária.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível fazer a gravação dos dados do quarto.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void TxtNumero_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNumero.Enabled == true)
            {
                if (TxtNumero.TextLength != 0)
                {
                    if (Convert.ToInt32(TxtNumero.Text) > 0)
                    {
                        for (int t = 0; t < DgvQuarto.Rows.Count; t++)
                        {
                            if (Convert.ToInt32(DgvQuarto.Rows[t].Cells[0].Value) == Convert.ToInt32(TxtNumero.Text))
                            {
                                ep.SetError(TxtNumero, "Número já existe!");
                                TxtNumero.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        ep.SetError(TxtNumero, "Digite um número maior que zero!");
                        TxtNumero.Focus();
                        return;
                    }
                }
                ep.Clear();
            }
        }
        private void TxtValorDiaria_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e)
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
        private void DgvQuarto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CarregaCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os campos com o item selecionado!\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnNovo_Click(object sender, EventArgs e)
        {
            AbreCampos();
            LimpaCampos();
            TxtNumero.Enabled = true;
            TxtNumero.Focus();
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            AbreCampos();
            TxtValorDiaria.Focus();
            BtnAdicionar.Text = "Confirmar";
        }
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir permanentemente o Quarto Selecionado?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Quarto quarto = new Quarto(Convert.ToInt32(TxtNumero.Text));
                    QuartoNegocio quartoNegocio = new QuartoNegocio();
                    quartoNegocio.Excluir(quarto);
                    MessageBox.Show("Quarto Excluído com Sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregaQuartos();
                    FechaCampos();
                    CarregaCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o quarto.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void BtnEncerrar_Click(object sender, EventArgs e)
        { 
            this.Close();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                FechaCampos();
                ep.Clear();
                CarregaCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível fazer o cancelamento.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void CarregaQuartos()
        {
            try
            {
                QuartoNegocio quartoNegocio = new QuartoNegocio();

                DgvQuarto.DataSource = null;
                DgvQuarto.DataSource = quartoNegocio.Quartos();

                DgvQuarto.Update();
                DgvQuarto.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os Quartos.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void AbreCampos()
        {
            TxtValorDiaria.Enabled = true;
            TxtLocalidade.Enabled = true;
            BtnAdicionar.Enabled = true;
            BtnCancelar.Enabled = true;

            BtnExcluir.Enabled = false;
            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            DgvQuarto.Enabled = false;
        }
        private void LimpaCampos()
        {
            TxtNumero.Text = "";
            TxtValorDiaria.Text = "";
            TxtLocalidade.Text = "";
        }
        private void FechaCampos()
        {
            TxtNumero.Enabled = false;
            TxtValorDiaria.Enabled = false;
            TxtLocalidade.Enabled = false;
            BtnAdicionar.Enabled = false;
            BtnCancelar.Enabled = false;

            BtnExcluir.Enabled = true;
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = true;
            DgvQuarto.Enabled = true;
        }
        private void CarregaCampos()
        {
            try
            {
                if (DgvQuarto.Rows.Count != 0)
                {
                    TxtNumero.Text = DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[0].Value.ToString();
                    TxtValorDiaria.Text = Convert.ToDouble(DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[1].Value).ToString("#,##0.00");
                    TxtLocalidade.Text = DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[2].Value.ToString();
                }
                else
                {
                    LimpaCampos();
                    BtnEditar.Enabled = false;
                    BtnExcluir.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os campos.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}     