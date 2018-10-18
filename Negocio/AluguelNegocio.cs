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
    public class AluguelNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Aluguel aluguel)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodQuarto", aluguel.Quarto.Numero);
                acessoMySql.AdicionarParametros("aValor", aluguel.Valor);
                acessoMySql.AdicionarParametros("aDataChegada", aluguel.DataChegada);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_AluguelNovo");
                return "Aluguel adicionado com sucesso!";
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

        public List<Aluguel> Alugueis(List<Quarto> quartos)
        {
            try
            {
                List<Aluguel> alugueis = new List<Aluguel>();

                DataTable dataTableAluguelQuarto = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_AluguelQuarto", false);

                foreach (DataRow linha in dataTableAluguelQuarto.Rows)
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (Convert.ToInt32(linha["cod_quarto"]) == quartos[t].Numero)
                        {
                            Aluguel aluguel = new Aluguel(Convert.ToInt32(linha["codigo"]), Convert.ToDouble(linha["valor"]), Convert.ToDateTime(linha["dataChegada"]), quartos[t]);
                            alugueis.Add(aluguel);
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

