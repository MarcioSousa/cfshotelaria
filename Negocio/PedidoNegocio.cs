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
                acessoMySql.AdicionarParametros("aCodAluguel", pedido.CodigoAluguel);
                acessoMySql.AdicionarParametros("aCodProduto", pedido.CodigoProduto);
                acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
                acessoMySql.AdicionarParametros("aQtde", pedido.Qtde);
                acessoMySql.AdicionarParametros("aValor", pedido.Valor);
                pedido.Codigo = Convert.ToInt32(acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PedidoNovo"));
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
                acessoMySql.AdicionarParametros("aCodAluguel", pedido.CodigoAluguel);
                acessoMySql.AdicionarParametros("aCodProduto", pedido.CodigoProduto);
                acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
                 acessoMySql.AdicionarParametros("aQtde", pedido.Qtde);
                acessoMySql.AdicionarParametros("aValor", pedido.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PedidoAlterar");
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
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PedidoExcluir");
                return "Pedido excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Pedido> Pedidos(Aluguel aluguel)
        {
            try
            {
                List<Pedido> pedidos = new List<Pedido>();

                acessoMySql.LimparParametros();
                DataTable dataTablePedidos = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT E.codigo, E.datapedido, E.qtde, E.valor, R.codigo, R.nome FROM pedido E INNER JOIN produto R ON E.cod_produto = R.codigo WHERE E.cod_aluguel = " + aluguel.Codigo, false);

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

                acessoMySql.LimparParametros();

                DataTable dataTableSaidasProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, cod_produto, datapedido, qtde, valor FROM pedido WHERE cod_produto = " + produto.Codigo + " ORDER BY datapedido DESC", false);

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

