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
    public partial class FrmProduto : Form
    {
        bool edicao = false;
        int numeroAntigo;

        public FrmProduto()
        {
            InitializeComponent();
            dgvProduto.AutoGenerateColumns = false;
        }
        private void FrmProduto_Load(object sender, EventArgs e)
        {
            CarregaGrid();
        }
        private void VerificaCampos()
        {
            if (dgvProduto.Rows.Count != 0)
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
            List<Produto> produtos = new List<Produto>();
            DQL dql = new DQL();

            produtos = dql.Produtos();
            dgvProduto.Rows.Add(produtos);

            dgvProduto.DataSource = produtos;

            dgvProduto.Update();
            dgvProduto.Refresh();

            limpaCampos();
            VerificaCampos();
        }
        private void limpaCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtValor.Text = "";
            txtCodigo.Focus();
        }
        private void iniciarcadastro()
        {
            gbxDados.Visible = true;
            btnAlterar.Visible = false;
            btnExcluir.Visible = false;
            dgvProduto.Enabled = false;
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            DML dml = new DML();

            try
            {
                if (txtCodigo.Text != "" && txtNome.Text != "" & txtValor.Text != "")
                {
                    Produto produto = new Produto();
                    produto.Codigo = Convert.ToInt32(txtCodigo.Text);
                    produto.Valor = Convert.ToDouble(txtValor.Text);
                    produto.Nome = txtNome.Text;

                    if (edicao)
                    {
                        MessageBox.Show(dml.ProdutoAlterar(produto, numeroAntigo), "Alterado com Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnAlterar.Enabled = true;
                        btnExcluir.Enabled = true;
                        edicao = false;

                        numeroAntigo = 0;
                    }
                    else
                    {
                        if (dml.ProdutoInserir(produto) != "1")
                        {
                            MessageBox.Show("Erro ao fazer a inserção!", "Não cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    dgvProduto.DataSource = null;
                    CarregaGrid();

                }
                else
                {
                    if (txtCodigo.Text.Trim() == "")
                    {
                        epError.SetError(txtCodigo, "Preencha com o Código do Produto.");
                        txtCodigo.Focus();
                    }
                    else if (txtValor.Text.Trim() == "")
                    {
                        epError.SetError(txtValor, "Preencha com o Valor do Produto.");
                        txtValor.Focus();
                    }
                    else
                    {
                        epError.SetError(txtNome, "Preencha com o Nome do Produto.");
                        txtNome.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique os valores cadastrados!\n" + ex.Message, "Não Registrado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            edicao = true;
            txtCodigo.Text = dgvProduto.Rows[dgvProduto.CurrentRow.Index].Cells[0].Value.ToString();
            txtValor.Text = Convert.ToDouble(dgvProduto.Rows[dgvProduto.CurrentRow.Index].Cells[2].Value).ToString("C2").Replace("R$", "");
            txtNome.Text = dgvProduto.Rows[dgvProduto.CurrentRow.Index].Cells[1].Value.ToString();
            numeroAntigo = Convert.ToInt32(txtCodigo.Text);
            txtCodigo.Focus();
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DML dml = new DML();
            Produto produto = new Produto();
            produto.Codigo = Convert.ToInt32(dgvProduto.Rows[dgvProduto.CurrentRow.Index].Cells[0].Value);


            if (MessageBox.Show("Deseja realmente excluir o registro selecionado?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dml.ProdutoExcluir(produto);
                    MessageBox.Show("Produto Excluído com Sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível fazer a exclusão!\n" + ex.Message, "Cancelado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvProduto.DataSource = null;
                CarregaGrid();
            }
        }
        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                txtCodigo.Text = "";
                epError.SetError(txtCodigo, "Digite um número inteiro válido." + ex.Message);
            }
        }
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            epError.Clear();
        }
        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            epError.Clear();
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            epError.Clear();
        }

    }
}
