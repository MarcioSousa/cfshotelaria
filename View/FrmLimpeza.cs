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
        Limpeza limpeza;
        Quarto quarto;

        public FrmLimpeza(Quarto quarto)
        {
            InitializeComponent();
            this.quarto = quarto;
        }

        public FrmLimpeza(Quarto quarto, Limpeza limpeza)
        {
            InitializeComponent();
            this.quarto = quarto;
            this.limpeza = limpeza;
        }


        private void FrmLimpeza_Load(object sender, EventArgs e)
        {
            try
            {
                if(limpeza is null)
                {
                    //NOVA LIMPEZA
                    NudQuartoNumero.Value = quarto.Numero;
                }
                else
                {
                    //EDITA LIMPEZA
                    NudQuartoNumero.Value = limpeza.Quarto.Numero;
                    DtpDataLimpeza.Value = limpeza.DataLimpeza;
                    DtpHoraLimpeza.Value = limpeza.DataLimpeza;
                }
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
                if (limpeza is null)
                {
                    //NOVA LIMPEZA
                    limpeza = new Limpeza(null, Convert.ToDateTime(DtpDataLimpeza.Text + " " + DtpHoraLimpeza.Text), quarto)
                    {
                        Quarto = quarto
                    };
                    limpezaNegocio.Inserir(limpeza);
                   
                    quarto.Limpezas.Add(limpeza);
                }
                else
                {
                    //EDITA LIMPEZA
                    limpeza.DataLimpeza = Convert.ToDateTime(DtpDataLimpeza.Text + " " + DtpHoraLimpeza.Text);
                    limpezaNegocio.Alterar(limpeza);
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
