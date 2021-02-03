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

            dgvQuarto.DataSource = null;

            quartos = dql.Quartos();
            dgvQuarto.Rows.Add(quartos);
            //QuartoNegocio quartoNegocio = new QuartoNegocio();

            //quartos = quartoNegocio.Quartos();

            dgvQuarto.DataSource = quartos;
            dgvQuarto.Update();
            dgvQuarto.Refresh();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DML dml = new DML();

            if (gbxDados.Text == "NOVO QUARTO"){

                Quarto quarto = new Quarto();
                quarto.Numero =Convert.ToInt32(txtNumero.Text);
                quarto.ValorDiaria = Convert.ToDouble(txtValorDiaria.Text);
                quarto.Localidade = txtLocalidade.Text;

                dml.QuartoInserir(quarto);


            }else if (gbxDados.Text == "ALTERAÇÃO DE QUARTO"){

            } else if (gbxDados.Text == "EXCLUSÃO DE QUARTO"){

            }

            CarregaGrid();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            gbxDados.Text = "NOVO QUARTO";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dgvQuarto.CurrentCell.ToString());
            gbxDados.Text = "ALTERAÇÃO DE QUARTO";
        }


    }
}
