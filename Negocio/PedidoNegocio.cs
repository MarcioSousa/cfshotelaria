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

                DataTable dataTablePedidos = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_Pedidos", false);

                foreach (DataRow linha in dataTablePedidos.Rows)
                {
                    for (int t = 0; t < alugueis.Count; t++)
                    {
                        if (Convert.ToInt32(linha["cod_aluguel"]) == alugueis[t].Codigo)
                        {
                            Pedido pedido = new Pedido(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["dataPedido"]), alugueis[t]);
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

        public void AddItemPedidos(Pedido pedido, List<Produto> produtos)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodPedido", pedido.Codigo);
                DataTable dataTablePedidoItensPedidos = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_ItensPedidoAluguel", false);

                foreach (DataRow linha in dataTablePedidoItensPedidos.Rows)
                {
                    for (int t = 0; t < produtos.Count; t++)
                    {
                        if (produtos[t].Codigo == Convert.ToInt32(linha["cod_produto"]))
                        {
                            ItemPedido itemPedido = new ItemPedido(Convert.ToInt32(linha["codigo"]), Convert.ToInt32(linha["qtde"]), Convert.ToDouble(linha["valor"]), produtos[t], pedido);
                            pedido.ItemPedidos.Add(itemPedido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os ItensPedidos dos Pedidos.\nDetalhes: " + ex.Message);
            }
        }
    }
}
