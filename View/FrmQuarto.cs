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
        private List<Quarto> quartos;
        bool novo = false;

        public FrmQuarto(List<Quarto> quartos)
        {
            InitializeComponent();
            DgvQuarto.AutoGenerateColumns = false;
            this.quartos = quartos;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (novo)
                {
                    bool passou = false;

                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (quartos[t].Numero == Convert.ToInt32(TxtNumero.Text))
                        {
                            passou = true;
                            break;
                        }
                    }

                    if (passou == false)
                    {
                        Quarto quarto = new Quarto(Convert.ToInt32(TxtNumero.Text), Convert.ToDouble(TxtValorDiaria.Text), TxtLocalidade.Text);
                        QuartoNegocio quartoNegocio = new QuartoNegocio();
                        quartoNegocio.Inserir(quarto);
                        quartos.Add(quarto);
                        DgvQuarto.DataSource = null;
                        DgvQuarto.DataSource = quartos;
                        FechaCampos();
                    }
                    else
                    {
                        MessageBox.Show("Quarto com o número já registrado, digite outro número de quarto!", "Número Repetido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (quartos[t].Numero == Convert.ToInt32(TxtNumero.Text))
                        {
                            QuartoNegocio quartoNegocio = new QuartoNegocio();
                            quartos[t].ValorDiaria = Convert.ToDouble(TxtValorDiaria.Text.ToString());
                            quartos[t].Localidade = TxtLocalidade.Text;
                            quartoNegocio.Alterar(quartos[t]);
                            DgvQuarto.DataSource = null;
                            DgvQuarto.DataSource = quartos;
                            FechaCampos();

                            break;
                        }
                    }
                }
                novo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar o quarto.\nAviso:" + ex.Message);
            }
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            DgvQuarto.DataSource = quartos;

            DgvQuarto.Update();
            DgvQuarto.Refresh();
        }

        private void DgvQuarto_SelectionChanged(object sender, EventArgs e)
        {
            TxtNumero.Text = DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[0].Value.ToString();
            TxtValorDiaria.Text = (Convert.ToDouble(DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[1].Value)).ToString("N2");
            TxtLocalidade.Text = DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            novo = true;
            AbreCampos();
            LimpaCampos();
            TxtNumero.Enabled = true;
            TxtNumero.Focus();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            novo = false;
            AbreCampos();
            TxtValorDiaria.Focus();
        }



        private void AbreCampos()
        {
            TxtValorDiaria.Enabled = true;
            TxtLocalidade.Enabled = true;
            BtnAdd.Enabled = true;
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
            BtnAdd.Enabled = false;
            BtnCancelar.Enabled = false;

            BtnExcluir.Enabled = true;
            BtnNovo.Enabled = true;
            BtnEditar.Enabled = true;
            DgvQuarto.Enabled = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            novo = false;
            FechaCampos();
            Ep.Clear();
            TxtNumero.Text = DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[0].Value.ToString();
            TxtValorDiaria.Text = (Convert.ToDouble(DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[1].Value)).ToString("N2");
            TxtLocalidade.Text = DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[2].Value.ToString();
        }

        private void TxtNumero_Validating(object sender, CancelEventArgs e)
        {
            if (TxtNumero.Enabled == true)
            {
                if (TxtNumero.Text != "")
                {
                    if (Convert.ToInt32(TxtNumero.Text) > 0)
                    {
                        for (int t = 0; t < quartos.Count; t++)
                        {
                            if (quartos[t].Numero == Convert.ToInt32(TxtNumero.Text))
                            {
                                Ep.SetError(TxtNumero, "Número já existe!");
                                TxtNumero.Focus();
                                return;
                            }
                        }
                    }
                    else
                    {
                        Ep.SetError(TxtNumero, "Digite um número maior que zero!");
                        TxtNumero.Focus();
                        return;
                    }
                }

                Ep.Clear();
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir o Quarto Selecionado?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (quartos[t].Numero.ToString() == DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[0].Value.ToString())
                        {
                            QuartoNegocio quartoNegocio = new QuartoNegocio();
                            quartoNegocio.Excluir(quartos[t]);
                            quartos.Remove(quartos[t]);
                            MessageBox.Show("Excluído com Sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DgvQuarto.DataSource = null;
                            DgvQuarto.DataSource = quartos;
                            DgvQuarto.Refresh();
                            DgvQuarto.Update();
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível excluir.\nEntre em contato com o desenvolvedor!\nAviso: " + ex.Message, "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtValorDiaria_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if(e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
        }
    }
}