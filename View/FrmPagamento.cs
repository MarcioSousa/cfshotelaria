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
    public partial class FrmPagamento : Form
    {
        Aluguel aluguel;
        Pagamento pagamento;

        public FrmPagamento(Aluguel aluguel)
        {
            InitializeComponent();
            this.aluguel = aluguel;
        }

        public FrmPagamento(Aluguel aluguel, Pagamento pagamento)
        {
            InitializeComponent();
            this.aluguel = aluguel;
            this.pagamento = pagamento;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbxForma.Text != "" && TxtValor.Text != "")
                {
                    PagamentoNegocio pagamentoNegocio = new PagamentoNegocio();

                    if (pagamento != null)
                    {
                        pagamento.DataPagamento = DateTime.Parse(DtpData.Text + " " + DtpHora.Text);
                        pagamento.Tipo = CbxForma.Text;
                        pagamento.Valor = Convert.ToDouble(TxtValor.Text);
                        pagamentoNegocio.Alterar(pagamento);

                        this.Close();
                    }
                    else
                    {
                        pagamento = new Pagamento(null, CbxForma.Text, DateTime.Parse(DtpData.Text + " " + DtpHora.Text), Convert.ToDouble(TxtValor.Text), aluguel.Codigo);
                        pagamentoNegocio.Inserir(pagamento);

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Preencha os campos com os valores corretos\nnão deixando nenhum campo vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar os dados.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmPagamento_Load(object sender, EventArgs e)
        {
            try
            {
                if (pagamento != null)
                {
                    DtpData.Text = pagamento.DataPagamento.ToShortDateString();
                    DtpHora.Text = pagamento.DataPagamento.ToShortTimeString();
                    CbxForma.Text = pagamento.Tipo;
                    TxtValor.Text = pagamento.Valor.ToString("N2");
                    DtpData.Focus();
                }
                else
                {
                    CbxForma.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os pagamentos do quarto.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
