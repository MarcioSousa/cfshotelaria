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
        List<Limpeza> limpezas = new List<Limpeza>();
        List<Quarto> quartos = new List<Quarto>();
        List<Aluguel> alugueis = new List<Aluguel>();
        List<Cliente> clientes = new List<Cliente>();
        List<Pagamento> pagamentos = new List<Pagamento>();
        List<Pedido> pedidos = new List<Pedido>();
        List<Produto> produtos = new List<Produto>();

        public FrmAluguel()
        {
            InitializeComponent();
            DgvQuartos.AutoGenerateColumns = false;
            DgvCliente.AutoGenerateColumns = false;
            DgvPagamento.AutoGenerateColumns = false;
            dgvLimpeza.AutoGenerateColumns = false;
        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            CarregaQuartos();
            CarregaLimpezas();
            CarregaAlugueis();
            CarregaClientes();
            CarregaPagamentos();
            CarregaProdutos();
            CarregaPedidos();

            Tempo.Start();

            DesativaMarcacao();
        }

        private void DesativaMarcacao()
        {
            int index;
            if (dgvLimpeza.SelectedRows.Count > 0)
            {
                index = dgvLimpeza.SelectedRows[0].Index;
                if (index >= 0)
                {
                    dgvLimpeza.Rows[index].Selected = false;
                }
            }

            if (DgvPagamento.SelectedRows.Count > 0)
            {
                index = DgvPagamento.SelectedRows[0].Index;
                if (index >= 0)
                {
                    DgvPagamento.Rows[index].Selected = false;
                }
            }

            if (DgvPedido.SelectedRows.Count > 0)
            {
                index = DgvPedido.SelectedRows[0].Index;
                if (index >= 0)
                {
                    DgvPedido.Rows[index].Selected = false;
                }
            }

            if (DgvCliente.SelectedRows.Count > 0)
            {
                index = DgvCliente.SelectedRows[0].Index;
                if (index >= 0)
                {
                    DgvCliente.Rows[index].Selected = false;
                }
            }

        }

        private void CarregaQuartos()
        {
            List<Quarto> quartosOcupados = new List<Quarto>();
            //var source = new BindingList<MinhaClasse>();
            //dataGridView1.DataSource = source;
            //source.Add(new MinhaClasse { Nome = "João", Idade = 32 });

            QuartoNegocio quartoNegocio = new QuartoNegocio();

            quartos = quartoNegocio.Quartos();

            //ORGANIZA TODOS OS QUARTOS EM ORDEM CRESCENTE
            //InsertionSort(quartos);

            //CARREGA TODAS AS LISTAS DE LIMPEZAS DO OBJETO QUARTO E TAMBÉM O ALUGUEL
            for (int t = 0; t < quartos.Count; t++)
            {
                quartoNegocio.AddLimpezas(quartos[t]);
            }


            //TROCANDO CORES DOS BOTÕES PARA MOSTRAR OS QUARTOS QUE ESTÃO OCUPADOS
            //List<Quarto> quartosOcupados = new List<Quarto>();
            //quartosOcupados = quartoNegocio.QuartosOcupados();

            //for (int u = 0; u < quartosOcupados.Count; u++)
            //{
            //    for (int v = 0; v < quartos.Count; v++)
            //    {
            //        if (quartosOcupados[u].Numero == quartos[v].Numero)
            //        {
            //            DgvQuarto.Rows.Add(quartos[u]);
            //            break;
            //            //CALL usp_QuartoNovo(20, 80.00,'2º Andar')
            //        }
            //    }
            //}

            //CARREGA DATAGRID QUARTOS
            DgvQuartos.DataSource = null;
            DgvQuartos.DataSource = quartos;

            DgvQuartos.Update();
            DgvQuartos.Refresh();
        }
        private void CarregaLimpezas()
        {
            QuartoNegocio quartoNegocio = new QuartoNegocio();
            LimpezaNegocio limpezaNegocio = new LimpezaNegocio();

            for (int t = 0; t < quartos.Count; t++)
            {
                if (quartos[t].Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                {
                    limpezas = limpezaNegocio.Limpezas(quartos[t]);
                    break;
                }
            }

            dgvLimpeza.DataSource = limpezas;

            dgvLimpeza.Refresh();
            dgvLimpeza.Update();
        }
        private void CarregaAlugueis()
        {
            AluguelNegocio aluguelNegocio = new AluguelNegocio();

            alugueis = aluguelNegocio.Alugueis(quartos);

            for (int t = 0; t < alugueis.Count; t++)
            {
                aluguelNegocio.AddClientes(alugueis[t]);
                aluguelNegocio.AddPagamentos(alugueis[t]);
                aluguelNegocio.AddPedidos(alugueis[t]);
            }

        }
        private void CarregaClientes()
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            clientes = clienteNegocio.Clientes(alugueis);
        }
        private void CarregaPagamentos()
        {
            PagamentoNegocio pagamentoNegocio = new PagamentoNegocio();
            pagamentos = pagamentoNegocio.Pagamentos(alugueis);
        }
        private void CarregaPedidos()
        {
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            pedidos = pedidoNegocio.Pedidos(alugueis);

            for (int t = 0; t < pedidos.Count; t++)
            {
                pedidoNegocio.AddItemPedidos(pedidos[t], produtos);
            }
        }
        private void CarregaProdutos()
        {
            ProdutoNegocio produtoNegocio = new ProdutoNegocio();
            produtos = produtoNegocio.Produtos();
        }
        private void CarregaCabecalho()
        {
            for (int t = 0; t < quartos.Count; t++)
            {
                if (quartos[t].Numero.ToString() == DgvQuartos.Rows[DgvQuartos.CurrentRow.Index].Cells[0].Value.ToString())
                {
                    LblNumeroQuarto.Text = quartos[t].Numero.ToString("000");
                    LblValorQuarto.Text = quartos[t].ValorDiaria.ToString("C");
                    LblLocalizacao.Text = quartos[t].Localidade;
                }

                LblSituacao.Text = "LIVRE";
                LblDia.Text = "";
                LblHorario.Text = "";

                for (int u = 0; u < alugueis.Count; u++)
                {
                    if (alugueis[u].Quarto.Numero == quartos[t].Numero)
                    {
                        LblSituacao.Text = "OCUPADO";
                        LblDia.Text = alugueis[u].DataChegada.ToString("dd/MM/yyyy");
                        LblHorario.Text = alugueis[u].DataChegada.ToString("HH:mm:ss");
                    }
                }
            }
        }

        private void CarregaCampos(int numeroQuarto, int qtdeQuarto)
        {
            //    DgvCliente.Rows.Clear();
            //    DgvPagamento.Rows.Clear();
            //    DgvPedido.Rows.Clear();

            //    for (int t = 0; t < qtdeQuarto; t++)
            //    {
            //        if (quartos[t].Numero == numeroQuarto)
            //        {
            //            LblNumero.Text = quartos[t].Numero.ToString();
            //            LblValorQuarto.Text = quartos[t].ValorDiaria.ToString("C");
            //            LblLocalizacao.Text = quartos[t].Localidade.ToString();

            //            for (int u = 0; u < alugueis.Count; u++)
            //            {
            //                if (alugueis[u].Quarto.Numero == quartos[t].Numero)
            //                {
            //                    LblSituacao.Text = "Ocupado";
            //                    LblDia.Text = alugueis[u].DataChegada.ToString("dd/MM/yyyy");
            //                    LblHorario.Text = alugueis[u].DataChegada.ToString("HH:mm:ss");

            //                    for (int c = 0; c < clientes.Count; c++)
            //                    {
            //                        if (alugueis[u].Codigo == clientes[c].Aluguel.Codigo)
            //                        {
            //                            DgvCliente.Rows.Add(clientes[c].Aluguel.Codigo, clientes[c].Nome);
            //                        }

            //                        DgvCliente.Update();
            //                        DgvCliente.Refresh();
            //                    }
            //                    for (int p = 0; p < pagamentos.Count; p++)
            //                    {
            //                        if (pagamentos[p].Aluguel.Codigo == alugueis[u].Codigo)
            //                        {
            //                            DgvPagamento.Rows.Add(pagamentos[p].Tipo.ToString(), pagamentos[p].DataPagamento.ToString(), pagamentos[p].Valor.ToString("C"));

            //                            DgvPagamento.Update();
            //                            DgvPagamento.Refresh();
            //                        }
            //                    }
            //                    for (int e = 0; e < pedidos.Count; e++)
            //                    {
            //                        if (pedidos[e].Aluguel.Codigo == alugueis[u].Codigo)
            //                        {
            //                            for (int b = 0; b < pedidos[e].ItemPedidos.Count; b++)
            //                            {
            //                                DgvPedido.Rows.Add(pedidos[e].DataPedido.ToString(), pedidos[e].ItemPedidos[b].Qtde, pedidos[e].ItemPedidos[b].Produto.Nome, pedidos[e].ItemPedidos[b].Valor.ToString("C"));
            //                            }

            //                            DgvPedido.Update();
            //                            DgvPedido.Refresh();
            //                        }
            //                    }
            //                    break;
            //                }
            //                else
            //                {
            //                    LblDia.Text = "";
            //                    LblHorario.Text = "";
            //                    LblSituacao.Text = "Livre";
            //                }
            //            }
            //            break;
            //        }
            //    }
        }

        private void TxtCodigoProduto_Validating(object sender, CancelEventArgs e)
        {
            if (TxtCodigoProduto.Text == "")
            {
                Ep.SetError(TxtCodigoProduto, "Você não digitou o Código!");
                TxtCodigoProduto.Focus();
                return;
            }
            Ep.Clear();
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
        }

        private void PbxAddCliente_Click(object sender, EventArgs e)
        {
            try
            {
                //List<Cliente> clientesQuarto = new List<Cliente>();

                if (DgvCliente.Rows.Count != 0)
                {
                    for (int t = 0; t < clientes.Count; t++)
                    {
                        if (Convert.ToInt32(DgvCliente.Rows[0].Cells[0].Value) == clientes[t].Aluguel.Codigo)
                        {
                            //clientesQuarto.Add(clientes[t]);
                        }
                    }
                }

                if (clientes.Count == 0)
                {
                    AluguelNegocio aluguelNegocio = new AluguelNegocio();
                    int retorno = Convert.ToInt32(aluguelNegocio.Inserir(Convert.ToInt32(LblNumeroQuarto.Text)));
                    MessageBox.Show(retorno.ToString());
                }

                FrmCliente frmCliente = new FrmCliente(clientes);
                frmCliente.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar o Aluguel.\nDetalhes: " + ex.Message);
            }
        }

        private void PbxNovaLimpeza_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoQuarto;

                codigoQuarto = Convert.ToInt32(LblNumeroQuarto.Text);

                if (codigoQuarto == 0)
                {
                    MessageBox.Show("Selecione o quarto para poder fazer o cadastro da limpeza!", "Não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (quartos[t].Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                        {
                            FrmLimpeza frmLimpeza = new FrmLimpeza(quartos[t], limpezas, 0);
                            frmLimpeza.ShowDialog();

                            InsertionSort(limpezas);

                            if (limpezas.Count > 10)
                            {
                                limpezas.RemoveAt(10);
                            }

                            dgvLimpeza.DataSource = null;
                            dgvLimpeza.DataSource = limpezas;

                            dgvLimpeza.Update();
                            dgvLimpeza.Refresh();

                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar uma nova limpeza!", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InsertionSort(List<Limpeza> limpezas)
        {
            int i, j;

            Limpeza atual = new Limpeza(0, DateTime.Today.Date, quartos[0]);

            for (i = 1; i < limpezas.Count; i++)
            {
                atual = limpezas[i];
                j = i;

                while ((j > 0) && limpezas[j - 1].DataLimpeza < atual.DataLimpeza)
                {
                    limpezas[j] = limpezas[j - 1];
                    j = j - 1;
                }

                limpezas[j] = atual;
            }
        }

        private void PbxEditaLimpeza_Click(object sender, EventArgs e)
        {
            try
            {
                for (int t = 0; t < quartos.Count; t++)
                {
                    if (quartos[t].Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                    {
                        FrmLimpeza frmLimpeza = new FrmLimpeza(quartos[t], limpezas, Convert.ToInt32(dgvLimpeza.Rows[dgvLimpeza.CurrentRow.Index].Cells[0].Value));
                        frmLimpeza.ShowDialog();

                        dgvLimpeza.DataSource = null;
                        dgvLimpeza.DataSource = limpezas;

                        dgvLimpeza.Update();
                        dgvLimpeza.Refresh();

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível adicionar uma nova limpeza!\nAviso:" + ex.Message, "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditarQuarto_Click(object sender, EventArgs e)
        {
            FrmQuarto frmCadQuarto = new FrmQuarto(quartos);
            frmCadQuarto.ShowDialog();
        }

        private void PbxNovoPagamento_Click(object sender, EventArgs e)
        {
            FrmPagamento frmPagamento = new FrmPagamento();
            frmPagamento.ShowDialog();
        }

        private void BtnQuarto_Click(object sender, EventArgs e)
        {
            FrmQuarto frmCadQuarto = new FrmQuarto(quartos);
            frmCadQuarto.ShowDialog();

            //InsertionSort(quartos);

            DgvQuartos.DataSource = null;
            DgvQuartos.DataSource = quartos;

            DgvQuartos.Refresh();
            DgvQuartos.Update();

        }

        private void DgvQuartos_DoubleClick(object sender, EventArgs e)
        {
            CarregaCabecalho();
            CarregaLimpezas();
        }

        private void PbxExcluiLimpeza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir a limpeza selecionada?", "Exclusão de Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpezaNegocio limpezaNegocio = new LimpezaNegocio();
                for (int t = 0; t < limpezas.Count; t++)
                {
                    if (Convert.ToInt32(dgvLimpeza.Rows[dgvLimpeza.CurrentRow.Index].Cells[0].Value.ToString()) == limpezas[t].Codigo)
                    {
                        limpezaNegocio.Excluir(limpezas[t]);
                        limpezas.RemoveAt(t);
                    

                        dgvLimpeza.DataSource = null;
                        dgvLimpeza.DataSource = limpezas;
                        dgvLimpeza.Update();
                        dgvLimpeza.Refresh();


                        MessageBox.Show("Excluído com Sucesso!", "Conclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
        }
    }
}

//SELECT codigo, cod_quarto, datalimpeza FROM limpeza WHERE cod_quarto = 30 ORDER BY datalimpeza DESC LIMIT 10

//public void VerificarDados()
//{
//quartos[0] = new Quarto(20, 80.00, "2º Andar");
//quartos[1] = new Quarto(21, 98.00, "3º Andar");
//quartos[2] = new Quarto(10, 85.00, "Térreo");
//quartos[3] = new Quarto(11, 102.00, "Térreo");
//quartos[4] = new Quarto(12, 98.00, "1º Andar");

//limpezas[0] = new Limpeza(1, Convert.ToDateTime("16/09/2018 16:00"), quartos[0]);
//limpezas[1] = new Limpeza(2, Convert.ToDateTime("17/09/2018 19:00"), quartos[1]);
//limpezas[2] = new Limpeza(3, Convert.ToDateTime("14/08/2018 19:30"), quartos[0]);
//limpezas[3] = new Limpeza(4, Convert.ToDateTime("12/08/2018 20:00"), quartos[2]);
//limpezas[4] = new Limpeza(5, Convert.ToDateTime("19/08/2018 20:00"), quartos[0]);

//quartos[0].Limpezas.Add(limpezas[0]);
//quartos[0].Limpezas.Add(limpezas[2]);
//quartos[0].Limpezas.Add(limpezas[4]);
//quartos[1].Limpezas.Add(limpezas[1]);
//quartos[2].Limpezas.Add(limpezas[3]);

////=================================================================================
//produtos[0] = new Produto(1, "Cerveja Lata", 6.00);
//produtos[0].Qtdeatual = 20;
//produtos[1] = new Produto(2, "Suco", 5.50);
//produtos[1].Qtdeatual = 10;
//produtos[2] = new Produto(3, "Cerveja Garrafa", 13.00);
//produtos[2].Qtdeatual = 30;
//produtos[3] = new Produto(4, "Lanche da Manhã", 22.00);
//produtos[4] = new Produto(5, "Almoço", 15.00);

//entradas[0] = new Entrada(1, Convert.ToDateTime("15/09/2018"), Convert.ToDateTime("15/09/2019"), 20, produtos[0]);
//entradas[1] = new Entrada(2, Convert.ToDateTime("11/08/2018"), Convert.ToDateTime("11/08/2019"), 20, produtos[2]);
//entradas[2] = new Entrada(3, Convert.ToDateTime("15/08/2018"), Convert.ToDateTime("15/08/2019"), 10, produtos[2]);
//entradas[3] = new Entrada(4, Convert.ToDateTime("16/09/2018"), Convert.ToDateTime("16/09/2019"), 30, produtos[0]);
//entradas[4] = new Entrada(5, Convert.ToDateTime("14/08/2018"), Convert.ToDateTime("14/09/2018"), 20, produtos[1]);

//produtos[0].Entradas.Add(entradas[3]);
//produtos[0].Entradas.Add(entradas[0]);
//produtos[1].Entradas.Add(entradas[4]);
//produtos[2].Entradas.Add(entradas[1]);
//produtos[2].Entradas.Add(entradas[2]);

////=================================================================================
//aluguels[0] = new Aluguel(1, 80.00, Convert.ToDateTime("16/09/2018 20:00"), quartos[0]);
//aluguels[1] = new Aluguel(2, 80.00, Convert.ToDateTime("19/09/2018 21:00"), quartos[1]);
//aluguels[2] = new Aluguel(3, 102.00, Convert.ToDateTime("15/09/2018 19:00"), quartos[3]);
//aluguels[3] = new Aluguel(4, 150.00, Convert.ToDateTime("12/08/2018 20:00"), quartos[2]);
//aluguels[4] = new Aluguel(5, 210.00, Convert.ToDateTime("15/08/2018 20:00"), quartos[4]);

//clientes[0] = new Cliente(1, "Marcio", "12121212", "12121233", "1111111", aluguels[0]);
//clientes[1] = new Cliente(2, "Roberta", "1201010", "1232010", "2222222", aluguels[0]);
//clientes[2] = new Cliente(3, "Rafael", "1200210", "989655", "1256322", aluguels[1]);
//clientes[3] = new Cliente(4, "Leandro", "12010020", "452122232", "85655232", aluguels[2]);
//clientes[4] = new Cliente(5, "João", "12001020", "12523200", "12002320", aluguels[3]);
//clientes[5] = new Cliente(6, "Hugo", "10101010", "11122222", "1198556552", aluguels[4]);

////Alugueis com os clientes
//aluguels[0].DataSaida = Convert.ToDateTime("19/09/2018 20:00");
//aluguels[0].Clientes.Add(clientes[0]);
//aluguels[0].Clientes.Add(clientes[1]);
//aluguels[1].Clientes.Add(clientes[2]);
//aluguels[2].Clientes.Add(clientes[3]);
//aluguels[3].Clientes.Add(clientes[4]);
//aluguels[4].Clientes.Add(clientes[5]);

//pagamentos[0] = new Pagamento(1, "Crédito", Convert.ToDateTime("19/09/2018 20:00"), 120.00, aluguels[0]);
//pagamentos[1] = new Pagamento(2, "Dinheiro", Convert.ToDateTime("19/09/2018 20:00"), 100.00, aluguels[0]);
//pagamentos[2] = new Pagamento(3, "Dinheiro", Convert.ToDateTime("19/09/2018 20:03"), 136.50, aluguels[0]);
//pagamentos[3] = new Pagamento(4, "Dinheiro", Convert.ToDateTime("19/09/2018 21:00"), 80.00, aluguels[1]);
//pagamentos[4] = new Pagamento(5, "Cartão", Convert.ToDateTime("15/09/2018 22:00"), 50.00, aluguels[2]);

//aluguels[0].Pagamentos.Add(pagamentos[0]);
//aluguels[0].Pagamentos.Add(pagamentos[1]);
//aluguels[0].Pagamentos.Add(pagamentos[2]);
//aluguels[1].Pagamentos.Add(pagamentos[3]);
//aluguels[2].Pagamentos.Add(pagamentos[4]);

//pedidos[0] = new Pedido(1, Convert.ToDateTime("16/09/2018 20:00"), aluguels[0]);
//pedidos[1] = new Pedido(2, Convert.ToDateTime("16/09/2018 22:00"), aluguels[0]);
//pedidos[2] = new Pedido(3, Convert.ToDateTime("19/09/2018 23:00"), aluguels[1]);
//pedidos[3] = new Pedido(4, Convert.ToDateTime("13/08/2018 22:00"), aluguels[3]);
//pedidos[4] = new Pedido(5, Convert.ToDateTime("15/09/2018 20:00"), aluguels[2]);

//aluguels[0].Pedidos.Add(pedidos[0]);
//aluguels[0].Pedidos.Add(pedidos[1]);
//aluguels[1].Pedidos.Add(pedidos[2]);
//aluguels[2].Pedidos.Add(pedidos[4]);
//aluguels[3].Pedidos.Add(pedidos[3]);

//itemPedidos[0] = new ItemPedido(1, 2, 6.00, produtos[0], pedidos[0]);
//itemPedidos[1] = new ItemPedido(2, 1, 6.00, produtos[0], pedidos[0]);
//itemPedidos[2] = new ItemPedido(3, 1, 5.50, produtos[1], pedidos[0]);
//itemPedidos[3] = new ItemPedido(4, 1, 13.00, produtos[2], pedidos[1]);
//itemPedidos[4] = new ItemPedido(5, 3, 15.00, produtos[1], pedidos[2]);
//itemPedidos[5] = new ItemPedido(6, 1, 22.00, produtos[3], pedidos[3]);
//itemPedidos[6] = new ItemPedido(7, 1, 15.00, produtos[4], pedidos[4]);

//produtos[0].ItemPedidos.Add(itemPedidos[0]);
//produtos[0].ItemPedidos.Add(itemPedidos[1]);
//produtos[1].ItemPedidos.Add(itemPedidos[2]);
//produtos[1].ItemPedidos.Add(itemPedidos[4]);
//produtos[2].ItemPedidos.Add(itemPedidos[3]);
//produtos[3].ItemPedidos.Add(itemPedidos[5]);
//produtos[4].ItemPedidos.Add(itemPedidos[6]);

//pedidos[0].ItemPedidos.Add(itemPedidos[0]);
//pedidos[0].ItemPedidos.Add(itemPedidos[1]);
//pedidos[0].ItemPedidos.Add(itemPedidos[2]);
//pedidos[1].ItemPedidos.Add(itemPedidos[3]);
//pedidos[2].ItemPedidos.Add(itemPedidos[4]);
//pedidos[3].ItemPedidos.Add(itemPedidos[5]);
//pedidos[4].ItemPedidos.Add(itemPedidos[6]);

//}