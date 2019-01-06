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
                acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
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
                acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
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

        public List<Pedido> Pedidos (List<Aluguel> alugueis)
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();
                for (int t = 0; t < alugueis.Count; t++)
                {
                    acessoMySql.LimparParametros();
                    DataTable dataTablePedidos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, datapedido FROM pedido WHERE cod_aluguel = " + alugueis[t].Codigo, false);

                    foreach (DataRow linha in dataTablePedidos.Rows)
                    {
                        Pedido pedido = new Pedido(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["dataPedido"]), alugueis[t]);
                        pedidos.Add(pedido);
                    }
                }

                return pedidos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar as Limpezas.\nDetalhes: " + ex.Message);
            }
        }

        public void AddItemPedidos(Pedido pedido, Produto produto)
        {
            try
            {
                acessoMySql.LimparParametros();
                DataTable dataTablePedidoItensPedidos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_pedido, cod_produto, qtde, valor FROM itemPedido WHERE cod_pedido = " + pedido.Codigo + " AND cod_produto = " + produto.Codigo, false);

                foreach (DataRow linha in dataTablePedidoItensPedidos.Rows)
                {
                    ItemPedido itemPedido = new ItemPedido(Convert.ToInt32(linha["codigo"]), Convert.ToInt32(linha["qtde"]), Convert.ToDouble(linha["valor"]), produto, pedido);
                    pedido.ItemPedidos.Add(itemPedido);
                    produto.ItemPedidos.Add(itemPedido);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os ItensPedidos dos Pedidos.\nDetalhes: " + ex.Message);
            }
        }

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
    }
}
