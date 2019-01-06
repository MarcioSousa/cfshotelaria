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
    public partial class FrmProduto : Form
    {
        List<Produto> produtos;

        public FrmProduto()
        {
            InitializeComponent();
            DgvProduto.AutoGenerateColumns = false;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            CarregaListProdutos();

            DgvProduto.DataSource = null;
            DgvProduto.DataSource = produtos;

            DgvProduto.Refresh();
            DgvProduto.Update();
        }

        private void CarregaListProdutos()
        {
            ProdutoNegocio produtoNegocio = new ProdutoNegocio();
            produtos = produtoNegocio.Produtos();

        }

        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();

                if (BtnNovo.BackColor == Color.Blue)
                {
                    Produto produto = new Produto(Convert.ToInt32(TxtCodigo.Text), TxtNome.Text, Convert.ToDouble(TxtValor.Text));

                    if (TxtQtdeAtual.Text == "")
                    {
                        produto.Qtdeatual = null;
                    }
                    else
                    {
                        produto.Qtdeatual = Convert.ToInt32(TxtQtdeAtual.Text);
                    }

                    produtos.Add(produto);

                    InsertionSort();

                    DgvProduto.DataSource = null;
                    DgvProduto.DataSource = produtos;

                    DgvProduto.Refresh();
                    DgvProduto.Update();

                    MessageBox.Show(produtoNegocio.Inserir(produto).ToString());

                    LimpaCampos();
                    TxtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível gravar o Produto.\nAviso: " + ex.Message, "Adicionar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InsertionSort()
        {
            int i, j;

            Produto atual = new Produto(-1, "", 0);

            for (i = 1; i < produtos.Count; i++)
            {
                atual = produtos[i];
                j = i;

                while ((j > 0) && produtos[j - 1].Codigo > atual.Codigo)
                {
                    produtos[j] = produtos[j - 1];
                    j = j - 1;
                }

                produtos[j] = atual;
            }
        }


        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            AbrirCampos();
            BtnNovo.BackColor = Color.Blue;
            TxtCodigo.Focus();

            TxtCodigo.Text = "2";
            TxtNome.Text = "Suco";
            TxtValor.Text = "5,50";
            TxtQtdeAtual.Text = "20";
        }

        private void LimpaCampos()
        {
            TxtCodigo.Text = "";
            TxtNome.Text = "";
            TxtValor.Text = "";
            TxtQtdeAtual.Text = "";
        }

        private void AbrirCampos()
        {
            TxtCodigo.Enabled = true;
            TxtNome.Enabled = true;
            TxtValor.Enabled = true;
            TxtQtdeAtual.Enabled = true;

            TxtCodigo.ReadOnly = false;
            TxtNome.ReadOnly = false;
            TxtValor.ReadOnly = false;
            TxtQtdeAtual.ReadOnly = false;

            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;

            BtnFinalizar.Enabled = false;
            BtnAdicionar.Enabled = true;
            BtnCancelar.Enabled = true;
        }

        private void DgvProduto_SelectionChanged(object sender, EventArgs e)
        {
            if (TxtCodigo.Enabled == false)
            {
                TxtCodigo.Text = DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[0].Value.ToString();
                TxtNome.Text = DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[1].Value.ToString();
                TxtValor.Text = DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[2].Value.ToString();
                TxtQtdeAtual.Text = DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[3].Value.ToString();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            AbrirCampos();
            BtnEditar.BackColor = Color.Blue;
            TxtCodigo.Focus();
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }
    }
}