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
    public partial class FrmAluguel : Form
    {
        //List<Limpeza> limpezas = new List<Limpeza>();
        //List<Quarto> quartos = new List<Quarto>();
        //List<Aluguel> alugueis = new List<Aluguel>();
        //List<Cliente> clientes = new List<Cliente>();
        //List<Pagamento> pagamentos = new List<Pagamento>();
        //List<Pedido> pedidos = new List<Pedido>();
        //List<Produto> produtos = new List<Produto>();

        public FrmAluguel()
        {
            InitializeComponent();
            DgvQuarto.AutoGenerateColumns = false;
            DgvLimpeza.AutoGenerateColumns = false;
            DgvCliente.AutoGenerateColumns = false;
            DgvPagamento.AutoGenerateColumns = false;
            DgvPedido.AutoGenerateColumns = false;
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            try
            {
                CarregaGridQuarto();
                CarregaGridLimpezas();
                CarregaAluguel();

                //AtualizarCabecalho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar todo o formulário. Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //CarregaTodoFormulario();
        }
        private void Tempo_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.DayOfWeek.ToString() == "Sunday")
            {
                TxtSemana.Text = "Domingo, " + DateTime.Now.ToString();
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Monday")
            {
                TxtSemana.Text = "Segunda-Feira, " + DateTime.Now.ToString();
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Tuesday")
            {
                TxtSemana.Text = "Terça-Feira, " + DateTime.Now.ToString();
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Wednesday")
            {
                TxtSemana.Text = "Quarta-Feira, " + DateTime.Now.ToString();
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Thursday")
            {
                TxtSemana.Text = "Quinta-Feira, " + DateTime.Now.ToString();
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Friday")
            {
                TxtSemana.Text = "Sexta-Feira, " + DateTime.Now.ToString();
            }
            else if (DateTime.Now.DayOfWeek.ToString() == "Saturday")
            {
                TxtSemana.Text = "Sábado, " + DateTime.Now.ToString();
            }
            if (lblCodigoAluguel.Text != "")
            {
                Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));

                CalcularTotalQuarto(aluguel);
            }
        }
        private void BtnQuarto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmQuarto frmQuarto = new FrmQuarto();
                frmQuarto.ShowDialog();
                CarregaGridQuarto();
                CarregaAluguel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar o formulário de Quarto.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void DgvQuarto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DgvQuarto.Rows.Count != 0)
                {
                    LblNumeroQuarto.Text = Convert.ToInt32(DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[0].Value).ToString("000");
                    LblValorQuarto.Text = Convert.ToDouble(DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[1].Value).ToString("C");
                    LblLocalizacao.Text = DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[2].Value.ToString();

                    CarregaGridLimpezas();
                    CarregaAluguel();

                    if (lblCodigoAluguel.Text != "")
                    {
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));
                        aluguel.DataChegada = Convert.ToDateTime(LblDia.Text);
                        CarregaGridPedidos(aluguel);
                    }
                    else
                    {
                        DgvPedido.DataSource = null;
                    }
                }
                else
                {
                    CarregaAluguel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao selecionar o quarto.\nAviso: " + ex.Message, "Quarto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnOcuparQuarto_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnOcuparQuarto.Text == "OCUPAR QUARTO")
                {
                    AluguelNegocio aluguelNegocio = new AluguelNegocio();
                    Aluguel aluguel = new Aluguel(0, 0, DateTime.Now, Convert.ToInt32(LblNumeroQuarto.Text));

                    aluguel.Codigo = Convert.ToInt32(aluguelNegocio.Inserir(aluguel));
                    lblCodigoAluguel.Text = aluguel.Codigo.ToString();

                    MessageBox.Show("Aluguel cadastrado, cadastre agora o Cliente que ficará no quarto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FrmCliente frmCliente = new FrmCliente(aluguel);
                    frmCliente.ShowDialog();

                    CarregaGridCliente(aluguel);

                    if(DgvCliente.Rows.Count == 0)
                    {
                        MessageBox.Show("Clique no botão de '+' para adicionar o cliente no quarto ou clique em 'Liberar Quarto'!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    BtnOcuparQuarto.Text = "LIBERAR QUARTO";
                    CarregaAluguel();
                    CalcularTotalQuarto(aluguel);
                }
                else
                {
                    if (DgvCliente.Rows.Count == 0 && DgvPagamento.Rows.Count == 0 && DgvPedido.Rows.Count == 0)
                    {
                        AluguelNegocio aluguelNegocio = new AluguelNegocio();
                        if (Convert.ToInt32(LblNumeroQuarto.Text) != 0)
                        {
                            Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));

                            aluguelNegocio.Excluir(aluguel);
                            lblCodigoAluguel.Text = "";
                            CarregaAluguel();
                        }
                        else
                        {
                            MessageBox.Show("Cadastre os quartos clicando no botão 'Quartos'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("1) Apague TODOS os Clientes, TODOS os Pagamentos e TODOS os Pedidos efetuados para poder liberar o quarto\nou\n2)Clique no botão 'Finalizar Aluguel' para receber do cliente o valor mostrado no formulário para fazer a desocupação!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível criar um novo aluguel.\nDetalhes: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxNovaLimpeza_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvQuarto.Rows.Count != 0)
                {
                    Quarto quarto = new Quarto(Convert.ToInt32(LblNumeroQuarto.Text));
                    FrmLimpeza frmLimpeza = new FrmLimpeza(quarto);
                    frmLimpeza.ShowDialog();
                    CarregaGridLimpezas();
                }
                else
                {
                    MessageBox.Show("Primeiro cadastre um quarto para poder cadastrar a limpeza do mesmo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar o formulário de Limpeza.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxNovoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnOcuparQuarto.Text == "LIBERAR QUARTO")
                {
                    Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));

                    FrmCliente frmCliente = new FrmCliente(aluguel);
                    frmCliente.ShowDialog();

                    CarregaGridCliente(aluguel);
                }
                else
                {
                    MessageBox.Show("Clique no botão 'LIBERAR QUARTO' para poder cadastrar seu primeiro cliente e seu primeiro aluguel.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível iniciar o cadastro do cliente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxNovoPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnOcuparQuarto.Text == "LIBERAR QUARTO")
                {
                    Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));
                    FrmPagamento frmPagamento = new FrmPagamento(aluguel);
                    frmPagamento.ShowDialog();
                    CarregaGridPagamento(aluguel);
                }
                else
                {
                    MessageBox.Show("O quarto selecionado não está ocupado para receber um pagamento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível efetuar o pagamento.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PbxEditaLimpeza_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvLimpeza.Rows.Count != 0)
                {
                    if (DgvQuarto.Rows.Count != 0)
                    {
                        Quarto quarto = new Quarto(Convert.ToInt32(LblNumeroQuarto.Text));
                        Limpeza limpeza = new Limpeza(Convert.ToInt32(DgvLimpeza.Rows[DgvLimpeza.CurrentRow.Index].Cells[0].Value),Convert.ToDateTime(DgvLimpeza.Rows[DgvLimpeza.CurrentRow.Index].Cells[2].Value), quarto);
                        FrmLimpeza frmLimpeza = new FrmLimpeza(quarto, limpeza);
                        frmLimpeza.ShowDialog();
                        CarregaGridLimpezas();
                    }
                    else
                    {
                        MessageBox.Show("Primeiro cadastre um quarto para poder editar a limpeza do mesmo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma limpeza efetuado nesse momento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar o formulário de Limpeza!\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        private void PbxEditaCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvCliente.Rows.Count != 0)
                {
                    Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));
                    Cliente cliente = new Cliente(Convert.ToInt32(DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[0].Value), DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[1].Value.ToString(), DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[2].Value.ToString(), DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[3].Value.ToString(), DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[4].Value.ToString(), Convert.ToInt32(lblCodigoAluguel.Text));

                    FrmCliente frmCliente = new FrmCliente(aluguel, cliente);
                    frmCliente.ShowDialog();

                    CarregaGridCliente(aluguel);
                }
                else
                {
                    MessageBox.Show("Nenhum cliente cadastrado para ser editado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível fazer a edição do Cliente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxEditarPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigoAluguel.Text != "")
                {
                    if (DgvPagamento.Rows.Count != 0)
                    {
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));

                        Pagamento pagamento = new Pagamento(Convert.ToInt32(DgvPagamento.Rows[DgvPagamento.CurrentRow.Index].Cells[0].Value), DgvPagamento.Rows[DgvPagamento.CurrentRow.Index].Cells[1].Value.ToString(), Convert.ToDateTime(DgvPagamento.Rows[DgvPagamento.CurrentRow.Index].Cells[2].Value), Convert.ToDouble(DgvPagamento.Rows[DgvPagamento.CurrentRow.Index].Cells[3].Value), aluguel.Codigo);

                        FrmPagamento frmPagamento = new FrmPagamento(aluguel, pagamento);
                        frmPagamento.ShowDialog();
                        CarregaGridPagamento(aluguel);
                    }
                    else
                    {
                        MessageBox.Show("Não há nenhum pagamento para fazer a edição!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("O quarto está livre, primeiramente clique no botão 'Ocupar quarto!'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar o pagamento.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PbxExcluiLimpeza_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvLimpeza.Rows.Count != 0)
                {
                    if (MessageBox.Show("Deseja deletar a limpeza selecionada?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (DgvQuarto.Rows.Count != 0)
                        {
                            LimpezaNegocio limpezaNegocio = new LimpezaNegocio();
                            Quarto quarto = new Quarto(Convert.ToInt32(LblNumeroQuarto.Text));
                            Limpeza limpeza = new Limpeza(Convert.ToInt32(DgvLimpeza.Rows[DgvLimpeza.CurrentRow.Index].Cells[0].Value));
                            limpezaNegocio.Excluir(limpeza);
                            CarregaGridLimpezas();
                        }
                        else
                        {
                            MessageBox.Show("Primeiro cadastre um quarto para poder excluir a limpeza do mesmo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nenhuma limpeza efetuado nesse momento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir a limpeza selecionada.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxExcluirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvCliente.Rows.Count != 0)
                {
                    if (MessageBox.Show("Deseja excluir definitivamente o cliente do quarto selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));
                        Cliente cliente = new Cliente(Convert.ToInt32(DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[0].Value));
                        ClienteNegocio clienteNegocio = new ClienteNegocio();
                        clienteNegocio.Excluir(cliente);
                        MessageBox.Show("Cliente excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregaGridCliente(aluguel);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum cliente a ser excluído!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o cliente.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CarregaGridPagamento(Aluguel aluguel)
        {
            try
            {
                double TotalPag = 0;
                PagamentoNegocio pagamentoNegocio = new PagamentoNegocio();

                DgvPagamento.DataSource = null;
                DgvPagamento.DataSource = pagamentoNegocio.Pagamentos(aluguel);

                DgvPagamento.Update();
                DgvPagamento.Refresh();

                for (int t = 0; t < DgvPagamento.Rows.Count; t++)
                {
                    TotalPag = TotalPag + Convert.ToDouble(DgvPagamento.Rows[t].Cells[3].Value);
                }
                LblTotalPag.Text = TotalPag.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("não foi possível carregar os pagamentos! Aviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxExcluirPagamento_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPagamento.Rows.Count != 0)
                {
                    if (MessageBox.Show("Deseja realmente deletar o pagamento efetuado?", "Deleção de pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PagamentoNegocio pagamentoNegocio = new PagamentoNegocio();
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));

                        Pagamento pagamento = new Pagamento(Convert.ToInt32(DgvPagamento.Rows[DgvPagamento.CurrentRow.Index].Cells[0].Value));

                        pagamentoNegocio.Excluir(pagamento);

                        MessageBox.Show("Pagamento excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregaGridPagamento(aluguel);
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum pagamento efetuado nesse momento!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o pagamento.\nDetalhes: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (TxtCodigoProduto.Text != "" && TxtQtde.Text != "" && lblCodigoAluguel.Text != "")
                {
                    Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));
                    aluguel.DataChegada = Convert.ToDateTime(LblDia.Text);
                    Pedido pedido = new Pedido(null, DateTime.Now, Convert.ToInt32(TxtQtde.Text), Convert.ToDouble(TxtValor.Text.Remove(0, 2)), Convert.ToInt32(lblCodigoAluguel.Text), Convert.ToInt32(TxtCodigoProduto.Text));
                    PedidoNegocio pedidoNegocio = new PedidoNegocio();

                    pedidoNegocio.Inserir(pedido);
                    CarregaGridPedidos(aluguel);
                    TxtCodigoProduto.Text = "";
                    TxtQtde.Text = "";
                    TxtCodigoProduto.Focus();
                }
                else
                {
                    if (TxtCodigoProduto.Text == "")
                    {
                        Ep.SetError(TxtCodigoProduto, "Digite o Código do produto!");
                        TxtCodigoProduto.Focus();
                        return;
                    }
                    else if (TxtNomeProduto.Text == "")
                    {
                        Ep.SetError(TxtCodigoProduto, "Digite um Código de um produto existente!");
                        TxtCodigoProduto.Focus();
                        return;
                    }
                    else if (TxtQtde.Text == "")
                    {
                        Ep.SetError(TxtQtde, "Digite a quantidade do pedido feito ao Quarto!");
                        TxtQtde.Focus();
                        return;
                    }
                    else if (lblCodigoAluguel.Text == "")
                    {
                        Ep.SetError(BtnOcuparQuarto, "Clique aqui para ocupar primeiramente o Quarto!");
                        BtnOcuparQuarto.Focus();
                        return;
                    }
                    Ep.Clear();
                }
            }

        }
        private void TxtCodigoProduto_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TxtCodigoProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtCodigoProduto.Text != "")
                {
                    ProdutoNegocio produtoNegocio = new ProdutoNegocio();
                    Produto produto = new Produto(Convert.ToInt32(TxtCodigoProduto.Text));

                    produto = produtoNegocio.Produto(produto);

                    if (produto.Valor != 0)
                    {
                        TxtNomeProduto.Text = produto.Nome;
                        TxtValor.Text = Convert.ToDouble(produto.Valor).ToString("C");
                    }
                    else
                    {
                        TxtNomeProduto.Text = "";
                        TxtValor.Text = "";
                    }
                }
                else
                {
                    TxtNomeProduto.Text = "";
                    TxtValor.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar o produto!\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnExcluirPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvPedido.Rows.Count != 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir o produto selecionado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PedidoNegocio pedidoNegocio = new PedidoNegocio();
                        Pedido pedido = new Pedido(Convert.ToInt32(DgvPedido.Rows[DgvPedido.CurrentRow.Index].Cells[0].Value));
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));
                        pedidoNegocio.Excluir(pedido);

                        MessageBox.Show("Pedido excluído com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregaGridPedidos(aluguel);
                    }
                }
                else
                {
                    MessageBox.Show("Formulário de pedidos vazio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o pedido selecionado!\nDetalhes: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnFinalizarAluguel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCodigoAluguel.Text != "")
                {
                    if (MessageBox.Show("Deseja Encerrar o aluguel desse quarto?\nVerifique se foi feito todo o pagamento do mesmo!", "Finalizamento do Aluguel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(lblCodigoAluguel.Text));
                        AluguelNegocio aluguelNegocio = new AluguelNegocio();
                        int diasQuarto;

                        aluguel.DataChegada = DateTime.Parse(LblDia.Text + " " + LblHorario.Text);

                        diasQuarto = (DateTime.Now.Subtract(aluguel.DataChegada).Days) + 1;

                        aluguel.Valor = diasQuarto * Convert.ToDouble(LblValorQuarto.Text.Remove(0, 2));
                        aluguel.NumeroQuarto = Convert.ToInt32(LblNumeroQuarto.Text);
                        aluguel.DataSaida = DateTime.Now;

                        aluguelNegocio.Alterar(aluguel);
                        MessageBox.Show("Quarto finalizado e livre para seu próximo uso!", "Quarto Aberto!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregaTodoFormulario();
                    }
                }
                else
                {
                    MessageBox.Show("O quarto já está LIVRE!\nClique no botão 'OCUPAR QUARTO'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível finalizar o aluguel. Aviso:" + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (lblCodigoAluguel.Text != "")
            {

            }
        }

        private void CarregaTodoFormulario()
        {
            lblCodigoAluguel.Text = "";

            try
            {
                Tempo.Start();
                CarregaGridQuarto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CarregaAluguel()
        {
            try
            {
                if (DgvQuarto.Rows.Count != 0)
                {
                    Quarto quarto = new Quarto(Convert.ToInt32(LblNumeroQuarto.Text));
                    Aluguel aluguel = new Aluguel();
                    AluguelNegocio aluguelNegocio = new AluguelNegocio();

                    aluguel = aluguelNegocio.AluguelQuartoSelecionado(quarto);
                    if (aluguel.Codigo > 0)
                    {
                        BtnOcuparQuarto.Visible = true;
                        BtnOcuparQuarto.Text = "LIBERAR QUARTO";
                        BtnOcuparQuarto.BackColor = Color.Red;
                        BtnOcuparQuarto.ForeColor = Color.White;
                        LblSituacao.Text = "OCUPADO";
                        lblCodigoAluguel.Text = aluguel.Codigo.ToString();
                        LblDia.Text = aluguel.DataChegada.ToShortDateString();
                        LblHorario.Text = aluguel.DataChegada.ToShortTimeString();
                        CarregaGridCliente(aluguel);
                        CarregaGridPagamento(aluguel);
                        BtnFinalizarAluguel.Visible = true;
                        PnlPedidos.Visible = true;
                        GbxPagamento.Visible = true;
                        GbxCliente.Visible = true;
                        PnlDiferenca.Visible = true;
                        GbxResumo.Visible = true;
                    }
                    else
                    {
                        BtnOcuparQuarto.Visible = true;
                        DgvCliente.DataSource = null;
                        DgvPagamento.DataSource = null;
                        BtnOcuparQuarto.Text = "OCUPAR QUARTO";
                        BtnOcuparQuarto.BackColor = Color.Yellow;
                        BtnOcuparQuarto.ForeColor = Color.Black;
                        LblSituacao.Text = "LIVRE";
                        lblCodigoAluguel.Text = "";
                        LblDia.Text = "";
                        LblHorario.Text = "";
                        BtnFinalizarAluguel.Visible = false;
                        PnlPedidos.Visible = false;
                        GbxPagamento.Visible = false;
                        GbxCliente.Visible = false;
                        PnlDiferenca.Visible = false;
                        GbxResumo.Visible = false;
                    }
                }
                else
                {
                    DgvCliente.DataSource = null;
                    DgvPagamento.DataSource = null;
                    BtnOcuparQuarto.Visible = false;
                    LblSituacao.Text = "";
                    lblCodigoAluguel.Text = "";
                    LblDia.Text = "";
                    LblHorario.Text = "";
                    BtnFinalizarAluguel.Visible = false;
                    PnlPedidos.Visible = false;
                    GbxPagamento.Visible = false;
                    GbxCliente.Visible = false;
                    PnlDiferenca.Visible = false;
                    GbxResumo.Visible = false;
                    LblValorQuarto.Text = "";
                    LblNumeroQuarto.Text = "000";
                    LblLocalizacao.Text = "";
                    GbxResumo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar o Aluguel desse quarto.\nDetalhes: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregaGridQuarto()
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
                MessageBox.Show("Não foi possível carregar os quartos!\nMensagem: " + ex.Message, "Quartos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CarregaGridLimpezas()
        {
            try
            {
                LimpezaNegocio limpezaNegocio = new LimpezaNegocio();

                DgvLimpeza.DataSource = null;

                if (DgvQuarto.Rows.Count != 0)
                {
                    Quarto quarto = new Quarto(Convert.ToInt32(LblNumeroQuarto.Text));
                    DgvLimpeza.DataSource = limpezaNegocio.Limpezas(quarto);
                    DgvLimpeza.Update();
                    DgvLimpeza.Refresh();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar as limpezas do quarto!\nMensagem: " + ex.Message, "Limpezas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void CarregaGridCliente(Aluguel aluguel)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                DgvCliente.DataSource = null;
                DgvCliente.DataSource = clienteNegocio.ClientesAtivos(aluguel);

                DgvCliente.Update();
                DgvCliente.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os clientes.\nAviso: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void CarregaGridPedidos(Aluguel aluguel)
        {
            try
            {
                PedidoNegocio pedidoNegocio = new PedidoNegocio();

                DgvPedido.DataSource = null;
                DgvPedido.DataSource = pedidoNegocio.Pedidos(aluguel);

                DgvPedido.Update();
                DgvPedido.Refresh();
                CalcularTotalQuarto(aluguel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os pedidos desse aluguel.\nDetalhes: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw;
            }
        }

        private void CalcularTotalQuarto(Aluguel aluguel)
        {
            try
            {
                int diasQuarto;
                double valorTotalDiariaQuarto;
                double valorTotalPedido = 0;
                if (LblDia.Text != "")
                {
                    aluguel.DataChegada = DateTime.Parse(LblDia.Text + " " + LblHorario.Text);

                    diasQuarto = (DateTime.Now.Subtract(aluguel.DataChegada).Days) + 1;

                    valorTotalDiariaQuarto = diasQuarto * Convert.ToDouble(LblValorQuarto.Text.Remove(0, 2));

                    for (int t = 0; t < DgvPedido.Rows.Count; t++)
                    {
                        valorTotalPedido = valorTotalPedido + (Convert.ToDouble(DgvPedido.Rows[t].Cells[4].Value) * Convert.ToDouble(DgvPedido.Rows[t].Cells[5].Value));
                    }

                    lblTotalPedido.Text = valorTotalPedido.ToString("C");
                    lblQtdeDiasValor.Text = diasQuarto.ToString() + " Dia(s) - " + valorTotalDiariaQuarto.ToString("C");
                    lblTotalAluguel.Text = (valorTotalDiariaQuarto + valorTotalPedido).ToString("C");
                    LblTotalPedidos.Text = valorTotalPedido.ToString("C");
                    LblFaltante.Text = (Convert.ToDouble(lblTotalAluguel.Text.Remove(0, 2)) - Convert.ToDouble(LblTotalPag.Text.Remove(0, 2))).ToString("C");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível fazer os cálculos do quarto. Detalhes: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}