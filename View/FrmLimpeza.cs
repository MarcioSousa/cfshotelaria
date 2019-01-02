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
    public partial class FrmLimpeza : Form
    {
        Quarto quarto;
        List<Limpeza> limpezas;
        Limpeza limpeza;

        int codigoLimpeza;

        public FrmLimpeza(Quarto quarto, List <Limpeza> limpezas, int codigoLimpeza)
        {
            InitializeComponent();
            this.quarto = quarto;
            this.limpezas = limpezas;
            this.codigoLimpeza = codigoLimpeza;
        }

        private void FrmLimpeza_Load(object sender, EventArgs e)
        {
            try
            {
                if (codigoLimpeza == 0)
                {
                    TxtCodigo.Text = "Nova Limpeza";
                }
                else
                {
                    TxtCodigo.Text = codigoLimpeza.ToString();
                    
                    for(int t = 0; t < limpezas.Count; t++)
                    {
                        if(limpezas[t].Codigo == codigoLimpeza)
                        {
                            DtpDataLimpeza.Value = limpezas[t].DataLimpeza;
                            DtpHoraLimpeza.Value = limpezas[t].DataLimpeza;
                        }
                    }

                }

                NudQuartoNumero.Value = quarto.Numero;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Código do Quarto não carregado!\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpezaNegocio limpezaNegocio = new LimpezaNegocio();

                if (codigoLimpeza == 0)
                {
                    limpeza = new Limpeza(null, Convert.ToDateTime(DtpDataLimpeza.Text + " " + DtpHoraLimpeza.Text), quarto);
                    try
                    {
                        limpeza.Codigo = Convert.ToInt32(limpezaNegocio.Inserir(limpeza));
                        limpezas.Add(limpeza);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao criar o código da limpeza!\nMensagem: " + ex.Message, "Cancelamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    for (int t = 0; t < limpezas.Count; t++)
                    {
                        if (limpezas[t].Codigo == Convert.ToInt32(TxtCodigo.Text))
                        {
                            limpezas[t].Codigo = Convert.ToInt32(TxtCodigo.Text);
                            limpezas[t].DataLimpeza = Convert.ToDateTime(DtpDataLimpeza.Text + " " + DtpHoraLimpeza.Text);
                            limpezas[t].Quarto = quarto;

                            limpezaNegocio.Alterar(limpezas[t]);

                            break;
                        }
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível gravar a Limpeza.\nAviso: " + ex.Message, "Gravação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
