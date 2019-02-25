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
    public partial class FrmEstoque : Form
    {
        public FrmEstoque()
        {
            InitializeComponent();
            DgvProduto.AutoGenerateColumns = false;
            DgvEntrada.AutoGenerateColumns = false;
            DgvSaida.AutoGenerateColumns = false;
        }

        private void FrmEstoque_Load(object sender, EventArgs e)
        {
            CarregaGrids();
        }

        private void CbxEstoque_CheckedChanged(object sender, EventArgs e)
        {
            CarregaGrids();
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == 13)
                {
                    MessageBox.Show("Apertou o 13");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível fazer o preenchimento do campo de código. Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            AbreCampos();
            LimpaCampos();
            TxtCodigoProduto.Enabled = true;
            TxtCodigoProduto.Focus();
        }
        private void BtnNovaEntrada_Click(object sender, EventArgs e)
        {
            AbreCamposEntrada();
            LimpaCamposEntrada();
            DtpDataEntrada.Focus();
            LblCodigoEntrada.Text = "";
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            AbreCampos();
            TxtValor.Text = TxtValor.Text.Remove(0, 2);
            TxtNome.Focus();
        }
        private void BtnEditaEntrada_Click(object sender, EventArgs e)
        {
            AbreCamposEntrada();
            DtpDataEntrada.Focus();
            LblCodigoEntrada.Text = DgvEntrada.Rows[DgvEntrada.CurrentRow.Index].Cells[0].Value.ToString();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir o Produto selecionado do sistema?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                    Produto produto = new Produto(Convert.ToInt32(TxtCodigoProduto.Text));

                    produtoNegocio.Excluir(produto);
                    MessageBox.Show("Excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregaGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o produto selecionado\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnExcluiEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja excluir a Entrada selecionada do sistema?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EntradaNegocio entradaNegocio = new EntradaNegocio();
                    Entrada entrada = new Entrada(Convert.ToInt32(DgvEntrada.Rows[DgvEntrada.CurrentRow.Index].Cells[0].Value));

                    entradaNegocio.Excluir(entrada);

                    MessageBox.Show("Excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CarregaGridEntrada();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir a entrada selecionada\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtCodigoProduto.Text != "" && TxtNome.Text != "" && TxtValor.Text != "" && Convert.ToInt32(TxtCodigoProduto.Text) > 0)
                {
                    Produto produto = new Produto(Convert.ToInt32(TxtCodigoProduto.Text), TxtNome.Text, Convert.ToDouble(TxtValor.Text));
                    ProdutoNegocio produtoNegocio = new ProdutoNegocio();

                    if (TxtQtde.Text != "")
                    {
                        produto.Qtdeatual = Convert.ToInt32(TxtQtde.Text);
                    }

                    if (TxtCodigoProduto.Enabled == false)
                    {
                        produtoNegocio.Alterar(produto);
                        CarregaGrids();
                        FechaCampos();
                    }
                    else
                    {
                        bool passou = false;
                        string aviso = produtoNegocio.Inserir(produto);

                        if (aviso == "Duplicate entry '" + TxtCodigoProduto.Text + "' for key 'PRIMARY'")
                        {
                            MessageBox.Show("Produto com o código " + TxtCodigoProduto.Text + " já existe, insira outro código!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TxtCodigoProduto.Text = "";
                            TxtCodigoProduto.Focus();
                            passou = true;
                        }
                        if (!passou)
                        {
                            CarregaGrids();
                            FechaCampos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos necessários com dados do Produto!\nO código do produto tem que ser maior que Zero!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (Convert.ToInt32(TxtCodigoProduto.Text) < 1)
                    {
                        TxtCodigoProduto.Text = "";
                        TxtCodigoProduto.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível confirmar o cadastro do produto! Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DgvProduto_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[3].Value is null)
            {
                GbxEntrada.Visible = false;
                DgvEntrada.DataSource = null;
            }
            else
            {
                GbxEntrada.Visible = true;
                CarregaCamposProduto();
                CarregaGridEntrada();
            }
            CarregaGridSaida();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FechaCampos();
            CarregaCamposProduto();
        }








        private void BtnConfirmarEntrada_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    if (TxtQtdeEntrada.Text != "")
            //    {
            //        Entrada entrada = new Entrada(Convert.ToInt32(DgvEntrada.Rows[DgvEntrada.CurrentRow.Index].Cells[0].Value), Convert.ToDateTime(DtpDataEntrada.Text), Convert.ToDateTime(DtpVencimento.Text), Convert.ToInt32(TxtQtdeEntrada.Text), Convert.ToInt32(TxtCodigoProduto.Text));

            //        EntradaNegocio entradaNegocio = new EntradaNegocio();
            //        entradaNegocio.Alterar(entrada);

            //        CarregaGridEntrada();
            //        FechaCamposEntrada();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Preencha o campo de quantidade de entrada de produtos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Não foi possível confirmar o cadastro de entrada do produto! Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            try
            {
                if (TxtQtdeEntrada.Text != "")
                {
                    Entrada entrada = new Entrada(null, Convert.ToDateTime(DtpDataEntrada.Value), Convert.ToDateTime(DtpVencimento.Value), Convert.ToInt32(TxtQtdeEntrada.Text), Convert.ToInt32(TxtCodigoProduto.Text));

                    EntradaNegocio entradaNegocio = new EntradaNegocio();

                    if (LblCodigoEntrada.Text == "")
                    {
                        entradaNegocio.Inserir(entrada);
                    }
                    else
                    {
                        entrada.Codigo = Convert.ToInt32(LblCodigoEntrada.Text);
                        entradaNegocio.Alterar(entrada);
                    }
                    CarregaGridEntrada();
                    FechaCamposEntrada();
                }
                else
                {
                    MessageBox.Show("Preencha o campo de quantidade de produtos que estão entrando na empresa!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível confirmar o cadastro do produto! Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCancelaEntrada_Click(object sender, EventArgs e)
        {
            FechaCamposEntrada();
            CarregaCamposEntrada();
            
        }

        private void DgvEntrada_SelectionChanged(object sender, EventArgs e)
        {
            CarregaCamposEntrada();
        }


        private void CarregaGridSaida()
        {
            try
            {  
                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                Produto produto = new Produto(Convert.ToInt32(DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[0].Value));

              DgvSaida.DataSource = null;
                DgvSaida.DataSource = pedidoNegocio.SaidasProduto(produto);

                DgvSaida.Update();
                DgvSaida.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as entradas dos produtos. Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CarregaGridEntrada()
        {
            try
            {
                EntradaNegocio entradaNegocio = new EntradaNegocio();
                Produto produto = new Produto(Convert.ToInt32(TxtCodigoProduto.Text));

                DgvEntrada.DataSource = null;
                DgvEntrada.DataSource = entradaNegocio.Entradas(produto);

                DgvEntrada.Update();
                DgvEntrada.Refresh();

                if (DgvEntrada.Rows.Count != 0)
                {
                    BtnEditaEntrada.Enabled = true;
                    BtnExcluiEntrada.Enabled = true;
                }
                else
                {
                    BtnEditaEntrada.Enabled = false;
                    BtnExcluiEntrada.Enabled = false;
                }
                CarregaCamposEntrada();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as entradas dos produtos. Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void LimpaCampos()
        {
            TxtCodigoProduto.Text = "";
            TxtNome.Text = "";
            TxtValor.Text = "";
            TxtQtde.Text = "";
        }
        private void CarregaCamposProduto()
        {
            if (DgvProduto.Rows.Count != 0)
            {
                TxtCodigoProduto.Text = DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[0].Value.ToString();
                TxtNome.Text = DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[1].Value.ToString();
                TxtValor.Text = Convert.ToDouble(DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[2].Value).ToString("C");

                if (DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[3].Value is null)
                {
                    TxtQtde.Text = "";
                }
                else
                {
                    TxtQtde.Text = DgvProduto.Rows[DgvProduto.CurrentRow.Index].Cells[3].Value.ToString();
                }
            }
        }

        private void CarregaGrids()
        {
            try
            {
                ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                DgvProduto.DataSource = null;

                if (CbxEstoque.Checked == false)
                {
                    DgvProduto.DataSource = produtoNegocio.Produtos();
                }
                else
                {
                    DgvProduto.DataSource = produtoNegocio.ProdutosEstoque();
                }

                DgvProduto.Update();
                DgvProduto.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar todo os produtos. Detalhes: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CarregaCamposEntrada()
        {
            try
            {
                if(DgvEntrada.Rows.Count != 0)
                {
                    DtpDataEntrada.Text = DgvEntrada.Rows[DgvEntrada.CurrentRow.Index].Cells[1].Value.ToString();
                    DtpVencimento.Text = DgvEntrada.Rows[DgvEntrada.CurrentRow.Index].Cells[2].Value.ToString();
                    TxtQtdeEntrada.Text = DgvEntrada.Rows[DgvEntrada.CurrentRow.Index].Cells[3].Value.ToString();
                }
                else
                {
                    LimpaCamposEntrada();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os campos! Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void AbreCampos()
        {

            TxtNome.Enabled = true;
            TxtValor.Enabled = true;
            TxtQtde.Enabled = true;

            BtnConfirmar.Enabled = true;
            BtnCancelar.Enabled = true;

            BtnNovo.Enabled = false;
            BtnEditar.Enabled = false;
            BtnExcluir.Enabled = false;

            CbxEstoque.Enabled = false;
            DgvProduto.Enabled = false;
            GbxEntrada.Enabled = false;
        }
        private void AbreCamposEntrada()
        {
            DtpDataEntrada.Enabled = true;
            DtpVencimento.Enabled = true;
            TxtQtdeEntrada.Enabled = true;

            BtnConfirmarEntrada.Enabled = true;
            BtnCancelaEntrada.Enabled = true;

            BtnNovaEntrada.Enabled = false;
            BtnEditaEntrada.Enabled = false;
            BtnExcluiEntrada.Enabled = false;

            DgvEntrada.Enabled = false;

            GbxProduto.Enabled = false;
        }
        private void FechaCampos()
        {
            TxtCodigoProduto.Enabled = false;
            TxtNome.Enabled = false;
            TxtValor.Enabled = false;
            TxtQtde.Enabled = false;

            BtnConfirmar.Enabled = false;
            BtnCancelar.Enabled = false;

            BtnNovo.Enabled = true;

            if (DgvProduto.Rows.Count != 0)
            {
                BtnEditar.Enabled = true;
                BtnExcluir.Enabled = true;
            }
            else
            {
                BtnEditar.Enabled = false;
                BtnExcluir.Enabled = false;
            }

            CbxEstoque.Enabled = true;
            GbxEntrada.Enabled = true;
            DgvProduto.Enabled = true;
        }
        private void FechaCamposEntrada()
        {
            DtpDataEntrada.Enabled = false;

            DtpVencimento.Enabled = false;
            TxtQtdeEntrada.Enabled = false;

            BtnConfirmarEntrada.Enabled = false;
            BtnCancelaEntrada.Enabled = false;

            BtnNovaEntrada.Enabled = true;
            if (DgvEntrada.Rows.Count != 0)
            {
                BtnEditaEntrada.Enabled = true;
                BtnExcluiEntrada.Enabled = true;
            }
            else
            {
                BtnEditaEntrada.Enabled = false;
                BtnExcluiEntrada.Enabled = false;
            }

            DgvEntrada.Enabled = true;
            GbxProduto.Enabled = true;
        }
        private void LimpaCamposEntrada()
        {
            DtpDataEntrada.Value = DateTime.Now;
            DtpVencimento.Value = DateTime.Now;
            TxtQtdeEntrada.Text = "";
        }


    }
}