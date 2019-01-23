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
            DgvQuarto.AutoGenerateColumns = false;
            DgvLimpeza.AutoGenerateColumns = false;
            DgvCliente.AutoGenerateColumns = false;
            DgvPagamento.AutoGenerateColumns = false;
            DgvPedido.AutoGenerateColumns = false;
        }
        private void CarregaLists()
        {
            LimpezaNegocio limpezaNegocio = new LimpezaNegocio();
            QuartoNegocio quartoNegocio = new QuartoNegocio();
            AluguelNegocio aluguelNegocio = new AluguelNegocio();
            PagamentoNegocio pagamentoNegocio = new PagamentoNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
            ProdutoNegocio produtoNegocio = new ProdutoNegocio();

            quartos = quartoNegocio.Quartos();
            limpezas = limpezaNegocio.Limpezas(quartos);

            for (int t = 0; t < quartos.Count; t++)
            {
                quartoNegocio.AddLimpezas(quartos[t]);
            }

            produtos = produtoNegocio.Produtos();

            alugueis = aluguelNegocio.AlugueisAberto(quartos);
            clientes = clienteNegocio.ClientesAtivos(alugueis);

            for (int t = 0; t < alugueis.Count; t++)
            {
                aluguelNegocio.AddClientes(alugueis[t]);
            }

            pagamentos = pagamentoNegocio.Pagamentos(alugueis);

            for (int t = 0; t < alugueis.Count; t++)
            {
                aluguelNegocio.AddPagamentos(alugueis[t]);

            }

            pedidos = pedidoNegocio.Pedidos(alugueis, produtos);

            for (int t = 0; t < pedidos.Count; t++)
            {
                for (int a = 0; a < alugueis.Count; a++)
                {
                    for (int p = 0; p < produtos.Count; p++)
                    {
                        if ((pedidos[t].Produto.Codigo == produtos[p].Codigo) && (pedidos[t].Aluguel.Codigo == alugueis[a].Codigo))
                        {
                            aluguelNegocio.AddPedidos(alugueis[a], produtos[p], pedidos[t]);
                        }
                    }
                }
            }

        }

        private void FrmQuarto_Load(object sender, EventArgs e)
        {
            lblCodigoAluguel.Text = "";

            try
            {
                CarregaLists();
                Tempo.Start();

                CarregaGridQuarto();
                CarregaGridCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        private void BtnQuarto_Click(object sender, EventArgs e)
        {
            try
            {
                FrmQuarto frmCadQuarto = new FrmQuarto(quartos);
                frmCadQuarto.ShowDialog();

                InsertionSort(quartos);

                CarregaGridQuarto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DgvQuarto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DgvLimpeza.DataSource = null;

                CarregaGridCliente();
             

                lblCodigoAluguel.Text = "";

                for (int t = 0; t < alugueis.Count; t++)
                {
                    if (alugueis[t].Quarto.Numero == Convert.ToInt32(DgvQuarto.Rows[DgvQuarto.CurrentRow.Index].Cells[0].Value))
                    {
                        CarregaCabecalho(alugueis[t]);
                        lblCodigoAluguel.Text = alugueis[t].Codigo.ToString();
                        CarregaGridLimpezas(alugueis[t].Quarto);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os dados do quarto.\nMensagem: " + ex.Message);
            }
        }
        private void BtnOcuparQuarto_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnOcuparQuarto.Text == "OCUPAR QUARTO")
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (quartos[t].Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                        {
                            AluguelNegocio aluguelNegocio = new AluguelNegocio();
                            Aluguel aluguel = new Aluguel(null, 0, DateTime.Now, quartos[t]);

                            aluguel.Codigo = Convert.ToInt32(aluguelNegocio.Inserir(aluguel));

                            FrmCliente frmCliente = new FrmCliente(aluguel);
                            frmCliente.ShowDialog();

                            alugueis.Add(aluguel);

                            CarregaCabecalho(aluguel);

                            for (int u = 0; u < alugueis.Count; u++)
                            {
                                if (alugueis[u].Codigo == Convert.ToInt32(lblCodigoAluguel.Text))
                                {
                                    clientes.Add(alugueis[u].Clientes[0]);
                                    break;
                                }
                            }
                            //for(int u = 0; u < )

                            //aluguelNegocio.AddClientes(aluguel);

                            CarregaGridCliente();
                            break;
                        }
                    }
                }
                else
                {
                    for (int a = 0; a < alugueis.Count; a++)
                    {
                        if (alugueis[a].Codigo == Convert.ToInt32(lblCodigoAluguel.Text))
                        {
                            if (alugueis[a].Clientes.Count == 0 && alugueis[a].Pagamentos.Count == 0 && alugueis[a].Pedidos.Count == 0)
                            {
                                AluguelNegocio aluguelNegocio = new AluguelNegocio();
                                aluguelNegocio.Excluir(alugueis[a]);
                                alugueis.RemoveAt(a);
                                MessageBox.Show("Quarto LIBERADO!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BtnOcuparQuarto.Text = "OCUPAR QUARTO";
                                for (int t = 0; t < quartos.Count; t++)
                                {
                                    if (quartos[t].Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                                    {
                                        LimpaCabecalho(quartos[t]);
                                        break;
                                    }
                                }

                                break;
                            }
                            else
                            {
                                MessageBox.Show("Delete primeiro todos os clientes, pagamentos e pedidos deste mesmo quarto para poder liberar o mesmo.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi retornado um número!\nMensagem: " + ex.Message);
            }
        }

        private void PbxNovaLimpeza_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(LblNumeroQuarto.Text) == 0)
                {
                    if (quartos.Count == 0)
                    {
                        MessageBox.Show("Comece cadastrando primeiramente o Quarto\nclicando no botão 'Quartos' logo acima.", "Cadastro de Limpeza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Selecione o quarto para poder fazer o cadastro da limpeza!", "Não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                else
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (quartos[t].Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                        {
                            FrmLimpeza frmLimpeza = new FrmLimpeza(quartos[t]);
                            frmLimpeza.ShowDialog();

                            if (quartos[t].Limpezas.Count != Convert.ToInt32(DgvLimpeza.Rows.Count))
                            {
                                for (int q = 0; q < quartos[t].Limpezas.Count; q++)
                                {
                                    for (int g = 0; g < DgvLimpeza.Rows.Count; g++)
                                    {
                                        if(quartos[t].Limpezas[q].Codigo == Convert.ToInt32(DgvLimpeza.Rows[g].Cells[0].Value))
                                        {
                                            limpezas.Add(quartos[t].Limpezas[q]);
                                            break;
                                        }
                                    }
                                }
                            }
                         
                            if(DgvLimpeza.Rows.Count == 0)
                            {
                                limpezas.Add(quartos[t].Limpezas[0]);
                            }

                            
                            CarregaGridLimpezas(quartos[t]);
                            break;












                            //for(int l = 0; l < limpezas.Count; l++)
                            //{
                            //    if(limpezas[l].Quarto.Numero == quartos[t].Numero)
                            //    {

                            //    }
                            //}







                            //for(int q = 0; q < quartos.Count; q++)
                            //{
                            //    if (quartos[q].Numero == quartos[t].Numero)
                            //    {

                            //    }
                            //}

                            //for(int l = 0; l < limpezas.Count; l++)
                            //{

                            //}


                            //for (int l = 0; l < limpezas.Count; l++)
                            //{
                            //    if(limpezas[l].Quarto.Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                            //    {
                            //        if(limpezas[l].Quarto.Limpezas.Count != quartos[t].Limpezas.Count)
                            //        {
                            //            limpezas.Add(quartos[t].Limpezas[limpezas[l].Quarto.Limpezas.Count - 1]);
                            //            break;
                            //        }
                            //    }
                            //}



                            //for (int c = 0; c < clientes.Count; c++)
                            //{
                            //    if (clientes[c].Aluguel.Codigo == Convert.ToInt32(lblCodigoAluguel.Text))
                            //    {
                            //        if (clientes[c].Aluguel.Clientes.Count != alugueis[t].Clientes.Count)
                            //        {
                            //            clientes.Add(alugueis[t].Clientes[clientes[c].Aluguel.Clientes.Count - 1]);
                            //            break;
                            //        }
                            //        break;
                            //    }
                            //}




                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível adicionar uma nova limpeza!", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxNovoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(LblNumeroQuarto.Text) == 0)
                {
                    if (quartos.Count == 0)
                    {
                        MessageBox.Show("Comece cadastrando primeiramente o Quarto\nclicando no botão 'Quartos' logo acima.", "Cadastro de Limpeza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Selecione o quarto para poder fazer o cadastro de cliente!", "Não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
                else
                {
                    if (lblCodigoAluguel.Text != "")
                    {
                        for (int t = 0; t < alugueis.Count; t++)
                        {
                            if (alugueis[t].Codigo == Convert.ToInt32(lblCodigoAluguel.Text))
                            {
                                FrmCliente frmCliente = new FrmCliente(alugueis[t]);
                                frmCliente.ShowDialog();

                                for (int c = 0; c < clientes.Count; c++)
                                {
                                    if (clientes[c].Aluguel.Codigo == Convert.ToInt32(lblCodigoAluguel.Text))
                                    {
                                        if (clientes[c].Aluguel.Clientes.Count != alugueis[t].Clientes.Count)
                                        {
                                            clientes.Add(alugueis[t].Clientes[clientes[c].Aluguel.Clientes.Count - 1]);
                                            break;
                                        }
                                        break;
                                    }
                                }

                                CarregaGridCliente();
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Clique no botão 'Ocupar Quarto' primeiramente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Clique no botão 'Ocupar Quarto' primeiramente. Mensagem:" + ex.Message, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxNovoPagamento_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToInt32(LblNumeroQuarto.Text) == 0)
            //    {
            //        if (quartos.Count == 0)
            //        {
            //            MessageBox.Show("Comece cadastrando primeiramente o Quarto\nclicando no botão 'Quartos' logo acima!", "Cadastro de Limpeza", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Selecione o quarto para poder fazer o cadastro de pagamento!", "Não selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //        return;
            //    }
            //    else
            //    {
            //        if (DgvCliente.Rows.Count == 0)
            //        {
            //            MessageBox.Show("Cadastre primeiramente o Cliente para quarto.");
            //        }
            //        else
            //        {
            //            FrmPagamento frmPagamento = new FrmPagamento();
            //            frmPagamento.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Não foi possível adicionar um novo pagamento!", "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void PbxEditaLimpeza_Click(object sender, EventArgs e)
        {
            try
            {
                for (int t = 0; t < quartos.Count; t++)
                {
                    if (quartos[t].Numero == Convert.ToInt32(LblNumeroQuarto.Text))
                    {
                        for (int l = 0; l < quartos[t].Limpezas.Count; l++)
                        {
                            if (quartos[t].Limpezas[l].Codigo == Convert.ToInt32(DgvLimpeza.Rows[DgvLimpeza.CurrentRow.Index].Cells[0].Value))
                            {
                                FrmLimpeza frmLimpeza = new FrmLimpeza(quartos[t], quartos[t].Limpezas[l]);
                                frmLimpeza.ShowDialog();

                                CarregaGridLimpezas(quartos[t]);

                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível adicionar uma nova limpeza!\nAviso:" + ex.Message, "Aviso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void PbxEditaCliente_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (quartos.Count != 0)
            //    {
            //        for (int t = 0; t < quartos.Count; t++)
            //        {
            //            for (int u = 0; u < alugueis.Count; u++)
            //            {
            //                if (quartos[t].Numero == alugueis[u].Quarto.Numero)
            //                {
            //                    for (int c = 0; c < alugueis[u].Clientes.Count; c++)
            //                    {
            //                        if (alugueis[u].Clientes[c].Codigo == Convert.ToInt32(DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[0].Value))
            //                        {
            //                            FrmCliente frmCliente = new FrmCliente(alugueis[u], alugueis[u].Clientes[c]);
            //                            frmCliente.ShowDialog();

            //                            CarregaGridCliente();

            //                            break;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Registre seu primeiro quarto no sistema clicando no botão 'Quartos'");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Não foi possível editar o cliente.\nMensagem: " + ex.Message);
            //}
        }
        private void PbxEditarPagamento_Click(object sender, EventArgs e)
        {

        }

        private void PbxExcluiLimpeza_Click(object sender, EventArgs e)
        {
            if (DgvLimpeza.Rows.Count != 0)
            {
                if (MessageBox.Show("Deseja excluir a limpeza selecionada?", "Exclusão de Limpeza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LimpezaNegocio limpezaNegocio = new LimpezaNegocio();

                    for (int t = 0; t < quartos.Count; t++)
                    {
                        for (int l = 0; l < quartos[t].Limpezas.Count; l++)
                        {
                            if (quartos[t].Limpezas[l].Codigo == Convert.ToInt32(DgvLimpeza.Rows[DgvLimpeza.CurrentRow.Index].Cells[0].Value))
                            {
                                limpezaNegocio.Excluir(quartos[t].Limpezas[l]);
                                quartos[t].Limpezas.RemoveAt(l);

                                CarregaGridLimpezas(quartos[t]);

                                MessageBox.Show("Excluído com Sucesso!", "Conclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Não tem limpeza para ser excluída!", "Não Exclusão", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        private void PbxExcluirCliente_Click(object sender, EventArgs e)
        {
            //if (DgvCliente.Rows.Count != 0)
            //{
            //    if (MessageBox.Show("Deseja excluir o Cliente selecionado?", "Exclusão de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        ClienteNegocio clienteNegocio = new ClienteNegocio();
            //        for (int t = 0; t < clientes.Count; t++)
            //        {
            //            if (Convert.ToInt32(DgvCliente.Rows[DgvCliente.CurrentRow.Index].Cells[0].Value.ToString()) == clientes[t].Codigo)
            //            {
            //                clienteNegocio.Excluir(clientes[t]);
            //                clientes.RemoveAt(t);

            //                for (int u = 0; u < alugueis.Count; u++)
            //                {
            //                    if (alugueis[u].Codigo == Convert.ToInt32(lblCodigoAluguel.Text))
            //                    {
            //                        alugueis[u].Clientes.RemoveAt(u);
            //                    }
            //                }

            //                CarregaGridCliente();

            //                MessageBox.Show("Excluído com Sucesso!", "Conclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Exclusão Cancelada!", "Não Exclusão", MessageBoxButtons.OK, MessageBoxIcon.None);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Cadastre seu primeiro Cliente ao quarto selecionado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        private void PbxExcluirPagamento_Click(object sender, EventArgs e)
        {
            //if (DgvPagamento.Rows.Count != 0)
            //{
            //    if (MessageBox.Show("Deseja excluir o pagamento selecionada?", "Exclusão de Pagamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        PagamentoNegocio pagamentoNegocio = new PagamentoNegocio();

            //        for (int t = 0; t < pagamentos.Count; t++)
            //        {
            //            if (Convert.ToInt32(DgvPagamento.Rows[DgvPagamento.CurrentRow.Index].Cells[0].Value.ToString()) == pagamentos[t].Codigo)
            //            {
            //                pagamentoNegocio.Excluir(pagamentos[t]);
            //                pagamentos.RemoveAt(t);

            //                DgvPagamento.DataSource = null;
            //                DgvPagamento.DataSource = pagamentos;

            //                DgvPagamento.Update();
            //                DgvPagamento.Refresh();

            //                MessageBox.Show("Excluído com Sucesso!", "Conclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Não tem pagamento para ser excluído!", "Não Exclusão", MessageBoxButtons.OK, MessageBoxIcon.None);
            //    }
            //}
        }


        private void ApagarAluguel(Aluguel aluguel)
        {
            try
            {
                AluguelNegocio aluguelNegocio = new AluguelNegocio();
                aluguelNegocio.Excluir(aluguel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o Aluguel.\nMensagem: " + ex.Message);
            }
        }
        private void CarregaGridLimpezas(Quarto quarto)
        {
            InsertionSort(quarto.Limpezas);

            if (quarto.Limpezas.Count > 10)
            {
                quarto.Limpezas.RemoveAt(10);
            }

            DgvLimpeza.DataSource = null;
            DgvLimpeza.DataSource = quarto.Limpezas;

            DgvLimpeza.Update();
            DgvLimpeza.Refresh();
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
        private void CarregaCabecalho(Aluguel aluguel)
        {
            lblCodigoAluguel.Text = aluguel.Codigo.ToString();
            LblNumeroQuarto.Text = aluguel.Quarto.Numero.ToString("000");
            LblSituacao.Text = "OCUPADO";
            LblDia.Text = aluguel.DataChegada.ToShortDateString();
            LblHorario.Text = aluguel.DataChegada.ToShortTimeString();
            LblValorQuarto.Text = aluguel.Valor.ToString("C");
            LblLocalizacao.Text = aluguel.Quarto.Localidade;
            BtnOcuparQuarto.Visible = true;
            BtnOcuparQuarto.Text = "LIBERAR QUARTO";

            CalcularTotalQuarto(aluguel);
        }
        private void LimpaCabecalho(Quarto quarto)
        {
            if (quartos.Count == 0)
            {

                LblNumeroQuarto.Text = "000";
                LblSituacao.Text = "";
                LblDia.Text = "";
                LblHorario.Text = "";
                LblValorQuarto.Text = "";
                LblLocalizacao.Text = "";
                BtnOcuparQuarto.Visible = false;
            }
            else
            {
                LblNumeroQuarto.Text = quarto.Numero.ToString("000");
                LblSituacao.Text = "LIVRE";
                LblDia.Text = "";
                LblHorario.Text = "";
                LblValorQuarto.Text = quarto.ValorDiaria.ToString("C");
                LblLocalizacao.Text = quarto.Localidade;
                BtnOcuparQuarto.Visible = true;
                BtnOcuparQuarto.Text = "OCUPAR QUARTO";
            }
            lblCodigoAluguel.Text = "";
            lblTotalPedido.Text = "";
            lblQtdeDiasValor.Text = "";
            lblTotalAluguel.Text = "";
            LblTotalPedidos.Text = "";
        }
        private void CalcularTotalQuarto(Aluguel aluguel)
        {
            int diasQuarto;
            double valorTotalDiariaQuarto;
            double valorTotalPedido = 0;

            diasQuarto = (DateTime.Today.Date.Subtract(aluguel.DataChegada).Days) + 1;
            valorTotalDiariaQuarto = diasQuarto * aluguel.Quarto.ValorDiaria;

            for (int t = 0; t < aluguel.Pedidos.Count; t++)
            {
                valorTotalPedido = valorTotalPedido + aluguel.Pedidos[t].Valor;
            }

            lblTotalPedido.Text = valorTotalPedido.ToString("C");
            lblQtdeDiasValor.Text = diasQuarto.ToString() + " Dia(s) - " + valorTotalDiariaQuarto.ToString("C");
            lblTotalAluguel.Text = (valorTotalDiariaQuarto + valorTotalPedido).ToString("C");
            LblTotalPedidos.Text = valorTotalPedido.ToString("C");
        }
        private void CarregaGridQuarto()
        {
            try
            {
                DgvQuarto.DataSource = null;

                if (quartos.Count > 0)
                {
                    DgvQuarto.DataSource = quartos;

                    DgvQuarto.Update();
                    DgvQuarto.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CarregaGridCliente()
        {
            try
            {
                DgvCliente.DataSource = null;

                for (int t = 0; t < alugueis.Count; t++)
                {
                    if (lblCodigoAluguel.Text != "")
                    {
                        if (alugueis[t].Codigo == Convert.ToInt32(lblCodigoAluguel.Text))
                        {
                            DgvCliente.DataSource = alugueis[t].Clientes;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível carregar os clientes!\nMensagem: " + ex.Message);
            }

            DgvCliente.Update();
            DgvCliente.Refresh();

        }

        private void InsertionSort(List<Quarto> quartos)
        {
            int i, j;

            Quarto atual = new Quarto(0, 0, "0");

            for (i = 1; i < quartos.Count; i++)
            {
                atual = quartos[i];
                j = i;

                while ((j > 0) && quartos[j - 1].Numero > atual.Numero)
                {
                    quartos[j] = quartos[j - 1];
                    j = j - 1;
                }

                quartos[j] = atual;
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

    }
}