using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace Control
{
    public class DQL
    {
        //acessoMySql acessoMySql = new acessoMySql();
        AcessoMySql acessoMySql = new AcessoMySql();

        public List<Quarto> Quartos ()
        {
            try
            {
                List<Quarto> quartos = new List<Quarto>();

                DataTable dataTableQuarto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT numero, valorDiaria, localidade FROM quarto ORDER BY numero");

                foreach (DataRow linha in dataTableQuarto.Rows)
                {
                    Quarto quarto = new Quarto(Convert.ToInt32(linha["numero"]), Convert.ToDouble(linha["valorDiaria"]), linha["localidade"].ToString());
                    quartos.Add(quarto);
                }

                return quartos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Quartos.\nDetalhes: " + ex.Message);
            }
        }
        public Aluguel AluguelQuartoSelecionado(Quarto quarto)
        {
            try
            {
                Aluguel aluguel = new Aluguel();

                //acessoMySql.LimparParametros();
                DataTable dataTableAluguelQuarto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, dataChegada, valor FROM aluguel WHERE cod_quarto = " + quarto.Numero + " AND dataSaida IS NULL");

                foreach (DataRow linha in dataTableAluguelQuarto.Rows)
                {
                    aluguel.Codigo = Convert.ToInt32(linha["codigo"]);
                    aluguel.Valor = Convert.ToDouble(linha["valor"]);
                    aluguel.DataChegada = Convert.ToDateTime(linha["dataChegada"]);
                }

                return aluguel;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o Aluguel do quarto selecionado.\nDetalhes: " + ex.Message);
            }
        }
        public List<Cliente> ClientesAtivos(Aluguel aluguel)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();

                //acessoMySql.LimparParametros();
                DataTable dataTableClientesAluguel = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, nome, rg, cpf, contato FROM cliente WHERE cod_aluguel = " + aluguel.Codigo);

                foreach (DataRow linha in dataTableClientesAluguel.Rows)
                {
                    Cliente cliente = new Cliente(Convert.ToInt32(linha["codigo"]), linha["nome"].ToString(), linha["rg"].ToString(), linha["cpf"].ToString(), linha["contato"].ToString(), aluguel.Codigo);
                    clientes.Add(cliente);
                }

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Alugueis dos Clientes.\nDetalhes: " + ex.Message);
            }
        }
        public List<Entrada> Entradas(Produto produto)
        {
            try
            {
                List<Entrada> entradas = new List<Entrada>();

                //acessoMySql.LimparParametros();

                DataTable dataTableClientesAluguel = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_produto, dataEntrada, dataVencimento, qtde FROM entrada WHERE cod_produto = " + produto.Codigo + " ORDER BY dataEntrada DESC");

                foreach (DataRow linha in dataTableClientesAluguel.Rows)
                {
                    Entrada entrada = new Entrada(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["dataEntrada"]), Convert.ToDateTime(linha["dataVencimento"]), Convert.ToInt32(linha["qtde"]), Convert.ToInt32(linha["cod_produto"]));
                    entradas.Add(entrada);
                }

                return entradas;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar as Entradas dos Produtos.\nDetalhes: " + ex.Message);
            }
        }
        public List<Limpeza> Limpezas(Quarto quarto)
        {
            try
            {
                List<Limpeza> limpezas = new List<Limpeza>();

                DataTable dataTableQuarto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, datalimpeza FROM limpeza WHERE cod_quarto = " + quarto.Numero + " ORDER BY datalimpeza DESC LIMIT 0,10");

                foreach (DataRow linha in dataTableQuarto.Rows)
                {
                    Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quarto);
                    limpezas.Add(limpeza);
                }

                return limpezas;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar as Limpezas.\nDetalhes: " + ex.Message);
            }
        }
        public List<Pagamento> Pagamentos(Aluguel aluguel)
        {
            try
            {
                //Aluguel aluguel = new Aluguel();
                List<Pagamento> pagamentos = new List<Pagamento>();

                //acessoMySql.LimparParametros();
                DataTable dataTablePagamentos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, tipo, dataPagamento, valor FROM pagamento WHERE cod_aluguel = " + aluguel.Codigo);

                foreach (DataRow linha in dataTablePagamentos.Rows)
                {
                    Pagamento pagamento = new Pagamento(Convert.ToInt32(linha["codigo"]), linha["tipo"].ToString(), Convert.ToDateTime(linha["dataPagamento"]), Convert.ToDouble(linha["valor"]), aluguel.Codigo);
                    pagamentos.Add(pagamento);
                }

                return pagamentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Pagamentos.\nDetalhes: " + ex.Message);
            }
        }
        public List<Pedido> Pedidos(Aluguel aluguel)
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();

                //acessoMySql.LimparParametros();
                DataTable dataTablePedidos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT E.codigo, E.datapedido, E.qtde, E.valor, R.codigo, R.nome FROM pedido E INNER JOIN produto R ON E.cod_produto = R.codigo WHERE E.cod_aluguel = " + aluguel.Codigo);

                foreach (DataRow linha in dataTablePedidos.Rows)
                {
                    Pedido pedido = new Pedido(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["dataPedido"]), Convert.ToInt32(linha["qtde"]), Convert.ToDouble(linha["valor"]), aluguel.Codigo, Convert.ToInt32(linha["codigo1"]));
                    pedido.NomeProduto = linha["nome"].ToString();
                    pedidos.Add(pedido);
                }

                return pedidos;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar as Limpezas.\nDetalhes: " + ex.Message);
            }
        }
        public List<Pedido> SaidasProduto(Produto produto)
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();

                //acessoMySql.LimparParametros();

                DataTable dataTableSaidasProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, cod_produto, datapedido, qtde, valor FROM pedido WHERE cod_produto = " + produto.Codigo + " ORDER BY datapedido DESC");

                foreach (DataRow linha in dataTableSaidasProduto.Rows)
                {
                    Pedido pedido = new Pedido(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datapedido"]), Convert.ToInt32(linha["qtde"]), Convert.ToDouble(linha["valor"]), Convert.ToInt32(linha["cod_aluguel"]), Convert.ToInt32(linha["cod_produto"]));
                    pedidos.Add(pedido);
                }

                return pedidos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar as Entradas dos Produtos.\nDetalhes: " + ex.Message);
            }
        }
        public Produto Produto(Produto produto)
        {
            try
            {
                DataTable dataTableProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, nome, valor, qtdeAtual FROM produto WHERE codigo = " + produto.Codigo);

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    produto.Codigo = Convert.ToInt32(linha["codigo"]);
                    produto.Nome = linha["nome"].ToString();
                    produto.Valor = Convert.ToDouble(linha["valor"]);

                    if (linha["qtdeAtual"] is DBNull)
                    {
                        produto.Qtdeatual = null;
                    }
                    else
                    {
                        produto.Qtdeatual = Convert.ToInt32(linha["qtdeAtual"]);
                    }
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Produtos.\nDetalhes: " + ex.Message);
            }
        }
        public List<Produto> Produtos()
        {
            try
            {
                List<Produto> produtos = new List<Produto>();

                DataTable dataTableProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, nome, valor FROM produto ORDER BY codigo");

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    Produto produto = new Produto();
                    produto.Codigo = Convert.ToInt32(linha["codigo"]);
                    produto.Nome = linha["nome"].ToString();
                    produto.Valor = Convert.ToDouble(linha["valor"]);

                    produtos.Add(produto);
                }

                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Produtos.\nDetalhes: " + ex.Message);
            }
        }
        public List<Produto> ProdutosEstoque()
        {
            try
            {
                List<Produto> produtos = new List<Produto>();

                DataTable dataTableProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, nome, valor, qtdeAtual FROM produto WHERE qtdeAtual IS NOT NULL ORDER BY codigo");

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    Produto produto = new Produto();
                    produto.Codigo = Convert.ToInt32(linha["codigo"]);
                    produto.Nome = linha["nome"].ToString();
                    produto.Valor = Convert.ToDouble(linha["valor"]);

                    if (linha["qtdeAtual"] is DBNull)
                    {
                        produto.Qtdeatual = null;
                    }
                    else
                    {
                        produto.Qtdeatual = Convert.ToInt32(linha["qtdeAtual"]);
                    }
                    produtos.Add(produto);
                }
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Produtos.\nDetalhes: " + ex.Message);
            }
        }

        //public List<Quarto> QuartosOcupados()
        //{
        //    try
        //    {
        //        List<Quarto> quartos = new List<Quarto>();

        //        DataTable dataTableQuarto = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "SELECT Q.numero, Q.valorDiaria, Q.localidade FROM quarto Q INNER JOIN aluguel A ON A.cod_quarto = Q.numero AND A.dataSaida IS NULL ORDER BY Q.numero", false);

        //        foreach (DataRow linha in dataTableQuarto.Rows)
        //        {
        //            Quarto quarto = new Quarto(Convert.ToInt32(linha["numero"]), Convert.ToDouble(linha["valorDiaria"]), linha["localidade"].ToString());
        //            quartos.Add(quarto);
        //        }

        //        return quartos;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível carregar os Quartos Ocupados.\nDetalhes: " + ex.Message);
        //    }
        //}

        //public void AddLimpezas(Quarto quarto)
        //{
        //    try
        //    {
        //        acessoMySql.LimparParametros();
        //        DataTable dataTableLimpezasQuarto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_quarto, datalimpeza FROM limpeza WHERE cod_quarto = " + quarto.Numero + " LIMIT 0,10", false);

        //        foreach (DataRow linha in dataTableLimpezasQuarto.Rows)
        //        {
        //            Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quarto);
        //            quarto.Limpezas.Add(limpeza);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível carregar as Limpezas do quarto " + quarto.Numero + ".\nDetalhes: " + ex.Message);
        //    }
        //}
    }
}
