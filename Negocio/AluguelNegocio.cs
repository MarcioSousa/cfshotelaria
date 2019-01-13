﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using Control;

namespace Negocio
{
    public class AluguelNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(int codigoQuarto)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodQuarto", codigoQuarto);
                acessoMySql.AdicionarParametros("aValor", 0.00);
                acessoMySql.AdicionarParametros("aDataChegada", DateTime.Now);
                return acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_AluguelNovo").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Aluguel aluguel)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", aluguel.Codigo);
                acessoMySql.AdicionarParametros("aCodQuarto", aluguel.Quarto.Numero);
                acessoMySql.AdicionarParametros("aValor", aluguel.Valor);
                acessoMySql.AdicionarParametros("aDataChegada", aluguel.DataChegada);
                acessoMySql.AdicionarParametros("aDataSaida", aluguel.DataSaida);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_AluguelAlterar");
                return "Aluguel alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Aluguel aluguel)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", aluguel.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_AluguelExcluir");
                return "Aluguel excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Aluguel> AlugueisAberto(List<Quarto> quartos)
        {
            try
            {
                List<Aluguel> alugueis = new List<Aluguel>();

                acessoMySql.LimparParametros();
                DataTable dataTableAluguelQuarto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_quarto, valor, dataChegada, dataSaida FROM aluguel WHERE dataSaida IS NULL ORDER BY cod_quarto", false);

                foreach (DataRow linha in dataTableAluguelQuarto.Rows)
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (quartos[t].Numero == Convert.ToInt32(linha["cod_quarto"]))
                        {
                            Aluguel aluguel = new Aluguel(Convert.ToInt32(linha["codigo"]), Convert.ToDouble(linha["valor"]), Convert.ToDateTime(linha["dataChegada"]), quartos[t]);
                            alugueis.Add(aluguel);
                            break;
                        }
                    }
                }

                return alugueis;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Alugueis dos Quartos.\nDetalhes: " + ex.Message);
            }
        }

        public void AddClientes(Aluguel aluguel)
        {
            try
            {
                acessoMySql.LimparParametros();
                DataTable dataTableAluguelClientes = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, contato, cpf, rg, nome FROM cliente WHERE cod_aluguel = " + aluguel.Codigo, false);

                foreach (DataRow linha in dataTableAluguelClientes.Rows)
                {
                    Cliente cliente = new Cliente(Convert.ToInt32(linha["codigo"]), linha["nome"].ToString(), linha["rg"].ToString(), linha["cpf"].ToString(), linha["contato"].ToString(), aluguel);
                    aluguel.Clientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Clientes em seus Alugueis.\nDetalhes: " + ex.Message);
            }
        }

        public void AddPagamentos(Aluguel aluguel)
        {
            try
            {
                acessoMySql.LimparParametros();
                DataTable dataTableAluguelPagamentos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, dataPagamento, tipo, valor FROM pagamento WHERE cod_aluguel = " + aluguel.Codigo, false);

                foreach (DataRow linha in dataTableAluguelPagamentos.Rows)
                {
                    Pagamento pagamento = new Pagamento(Convert.ToInt32(linha["codigo"]), linha["tipo"].ToString(), Convert.ToDateTime(linha["dataPagamento"]), Convert.ToDouble(linha["valor"]), aluguel);
                    aluguel.Pagamentos.Add(pagamento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Quartos.\nDetalhes: " + ex.Message);
            }
        }

        //Só foi passado 3 parâmetros pois pedido tem o código como chave primária
        //Se fosse duas chaves primárias (aluguel e produto), então era somente passar dois parâmetros.
        public void AddPedidos(Aluguel aluguel, Produto produto, Pedido pedido)
        {
            try
            {
                acessoMySql.LimparParametros();
                DataTable dataTableAluguelPedidos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, datapedido, qtde, valor, cod_aluguel, cod_produto FROM pedido WHERE codigo = " + pedido.Codigo, false);

                foreach (DataRow linha in dataTableAluguelPedidos.Rows)
                {
                    pedido = new Pedido(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["dataPedido"]), Convert.ToInt32(linha["qtde"]), Convert.ToDouble(linha["valor"]), aluguel, produto);
                    aluguel.Pedidos.Add(pedido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Quartos.\nDetalhes: " + ex.Message);
            }
        }


    }
}

//limpezaNegocio
//public List<Limpeza> Limpezas(List<Quarto> quartos)

//quartoNegocio
//public List<Quarto> Quartos()

//AlugelNegocio
//public List<Aluguel> Alugueis(List<Quarto> quartos)

//ClienteNegocio
//public List<Cliente> Clientes(List<Aluguel> alugueis)

//PagamentoNegocio
//public List<Pagamento> Pagamentos(List<Aluguel> alugueis)

//PedidoNegocio
//public List<Pedido> Pedidos(List<Aluguel> alugueis)

//ItemPedidoNegocio
//public List<ItemPedido> ItensPedidos(List<Pedido> pedidos)

//ItemPedidoNegocio
//public List<ItemPedido> ItensPedidos(List<Produto> produtos)

//EntradaNegocio
//public List<Entrada> Entradas(List<Produto> produtos)

//ProdutoNegocio
//public List<Produto> Produtos()

