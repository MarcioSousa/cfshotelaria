using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using Control;

namespace Negocio
{
    public class PedidoNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Pedido pedido)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodAluguel", pedido.Aluguel.Codigo);
                acessoMySql.AdicionarParametros("aCodProduto", pedido.Produto.Codigo);
                acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
                acessoMySql.AdicionarParametros("aQtde", pedido.Qtde);
                acessoMySql.AdicionarParametros("aValor", pedido.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PedidoNovo");
                return "Pedido adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Pedido pedido)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", pedido.Codigo);
                acessoMySql.AdicionarParametros("aCodAluguel", pedido.Aluguel.Codigo);
                acessoMySql.AdicionarParametros("aCodProduto", pedido.Produto.Codigo);
                acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
                 acessoMySql.AdicionarParametros("aQtde", pedido.Qtde);
                acessoMySql.AdicionarParametros("aValor", pedido.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PedidoAlterar");
                return "Pedido alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Pedido pedido)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", pedido.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PedidoExcluir");
                return "Pedido excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Pedido> Pedidos(List<Aluguel> aluguels, List<Produto> produtos)
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();

                for (int t = 0; t < aluguels.Count; t++)
                {
                    for (int p = 0; p < produtos.Count; p++)
                    {
                        acessoMySql.LimparParametros();
                        DataTable dataTablePedidos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, datapedido, qtde, valor, cod_aluguel FROM pedido WHERE cod_aluguel = " + aluguels[t].Codigo + " AND cod_produto = " + produtos[p].Codigo , false);

                        foreach (DataRow linha in dataTablePedidos.Rows)
                        {
                            Pedido pedido = new Pedido(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["dataPedido"]), Convert.ToInt32(linha["qtde"]), Convert.ToDouble(linha["valor"]), aluguels[t], produtos[p]);
                            pedidos.Add(pedido);
                        }
                    }
                }

                return pedidos;

            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar as Limpezas.\nDetalhes: " + ex.Message);
            }
        }



    }
}

//SELECT P.codigo, P.datapedido, B.nome, P.qtde, P.valor, P.cod_aluguel FROM pedido P INNER JOIN produto B ON B.codigo = P.cod_produto WHERE P.cod_aluguel = " + pedido.Aluguel.Codigo


        //public void AddLimpezas(Quarto quarto)
        //{
        //    try
        //    {
        //        acessoMySql.LimparParametros();
        //        acessoMySql.AdicionarParametros("aCodQuarto", quarto.Numero);
        //        DataTable dataTableLimpezasQuarto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_quarto, datalimpeza FROM limpeza WHERE cod_quarto = " + quarto.Numero, false);

        //        foreach (DataRow linha in dataTableLimpezasQuarto.Rows)
        //        {
        //            Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quarto);
        //            quarto.Limpezas.Add(limpeza);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível carregar os Quartos.\nDetalhes: " + ex.Message);
        //    }

        //}

