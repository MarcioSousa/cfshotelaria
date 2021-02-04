using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class DML
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string QuartoInserir(Quarto quarto)
        {
            try
            {
                return acessoMySql.ExecutarManipulacao(CommandType.Text, "INSERT INTO quarto(numero, valorDiaria, localidade) VALUES(" + quarto.Numero + ", " + quarto.ValorDiaria.ToString().Replace(",", ".") + ", '" + quarto.Localidade + "')").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string QuartoAlterar(Quarto quarto, int numeroAntigo)
        {
            try
            {
                acessoMySql.ExecutarManipulacao(CommandType.Text, "UPDATE quarto SET numero = " + quarto.Numero + ", valorDiaria = " + quarto.ValorDiaria + ", localidade = '" + quarto.Localidade + "' WHERE numero = " + numeroAntigo);
                return "Quarto " + numeroAntigo + " foi Alterado com Sucesso para " + quarto.Numero;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string QuartoExcluir(Quarto quarto)
        {
            try
            {
                acessoMySql.ExecutarManipulacao(CommandType.Text, "DELETE FROM quarto WHERE numero = " + quarto.Numero);
                return "Quarto " + quarto.Numero + " Excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string AluguelInserir(Aluguel aluguel)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodQuarto", aluguel.NumeroQuarto);
                //acessoMySql.AdicionarParametros("aValor", aluguel.Valor);
                //acessoMySql.AdicionarParametros("aDataChegada", aluguel.DataChegada);
                aluguel.Codigo = Convert.ToInt32(acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_AluguelNovo"));
                return aluguel.Codigo.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AluguelAlterar(Aluguel aluguel)
        {
            try
            {
                //acessoMySql.AdicionarParametros("aCodigo", aluguel.Codigo);
                //acessoMySql.AdicionarParametros("aCodQuarto", aluguel.NumeroQuarto);
                //acessoMySql.AdicionarParametros("aValor", aluguel.Valor);
                //acessoMySql.AdicionarParametros("aDataChegada", aluguel.DataChegada);
                //acessoMySql.AdicionarParametros("aDataSaida", aluguel.DataSaida);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_AluguelAlterar");
                return "Aluguel alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string AluguelExcluir(Aluguel aluguel)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", aluguel.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_AluguelExcluir");
                return "Aluguel excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ClienteInserir(Cliente cliente)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodAluguel", cliente.CodigoAluguel);
                //acessoMySql.AdicionarParametros("aNome", cliente.Nome);
                //acessoMySql.AdicionarParametros("aRg", cliente.Rg);
                //acessoMySql.AdicionarParametros("aCpf", cliente.Cpf);
                //acessoMySql.AdicionarParametros("aContato", cliente.Contato);
                cliente.Codigo = Convert.ToInt32(acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ClienteNovo"));
                return "Cliente Cadastrado!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ClienteAlterar(Cliente cliente)
        {
            try
            {
                //acessoMySql.AdicionarParametros("aCodigo", cliente.Codigo);
                //acessoMySql.AdicionarParametros("aCodAluguel", cliente.CodigoAluguel);
                //acessoMySql.AdicionarParametros("aNome", cliente.Nome);
                //acessoMySql.AdicionarParametros("aRg", cliente.Rg);
                //acessoMySql.AdicionarParametros("aCpf", cliente.Cpf);
                //acessoMySql.AdicionarParametros("aContato", cliente.Contato);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ClienteAlterar");
                return "Cliente alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ClienteExcluir(Cliente cliente)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", cliente.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ClienteExcluir");
                return "Cliente excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string EntradaInserir(Entrada entrada)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodProduto", entrada.CodigoProduto);
                //acessoMySql.AdicionarParametros("aDataEntrada", entrada.DataEntrada);
                //acessoMySql.AdicionarParametros("aDataVencimento", entrada.DataVencimento);
                //acessoMySql.AdicionarParametros("aQtde", entrada.Qtde);
                return acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_EntradaNovo").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EntradaAlterar(Entrada entrada)
        {
            try
            {
                //acessoMySql.AdicionarParametros("aCodigo", entrada.Codigo);
                //acessoMySql.AdicionarParametros("aDataEntrada", entrada.DataEntrada);
                //acessoMySql.AdicionarParametros("aDataVencimento", entrada.DataVencimento);
                //acessoMySql.AdicionarParametros("aQtde", entrada.Qtde);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_EntradaAlterar");
                return "Entrada alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EntradaExcluir(Entrada entrada)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", entrada.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_EntradaExcluir");
                return "Entrada excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string LimpezaInserir(Limpeza limpeza)
        {
            try
            {
                acessoMySql.ExecutarManipulacao(CommandType.Text, "INSERT INTO limpeza(cod_quarto, datalimpeza) VALUES(" + limpeza.Quarto.Numero + ", " + limpeza.DataLimpeza + ")");
                return "Salvo com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string LimpezaAlterar(Limpeza limpeza)
        {
            try
            {
                acessoMySql.ExecutarManipulacao(CommandType.Text, "UPDATE limpeza SET cod_quarto = " + limpeza.Quarto.Numero + ", datalimpeza = " + limpeza.DataLimpeza + " WHERE codigo = " + limpeza.Codigo);
                return "Limpeza alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string LimpezaExcluir(Limpeza limpeza)
        {
            try
            {
                acessoMySql.ExecutarManipulacao(CommandType.Text, "DELETE FROM limpeza WHERE codigo = " + limpeza.Codigo);
                return "Limpeza excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string PagamentoInserir(Pagamento pagamento)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodAluguel", pagamento.CodigoAluguel);
                //acessoMySql.AdicionarParametros("aTipo", pagamento.Tipo);
                //acessoMySql.AdicionarParametros("aDataPagamento", pagamento.DataPagamento);
                //acessoMySql.AdicionarParametros("aValor", pagamento.Valor);
                pagamento.Codigo = Convert.ToInt32(acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PagamentoNovo"));
                return "Pagamento adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string PagamentoAlterar(Pagamento pagamento)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", pagamento.Codigo);
                ////acessoMySql.AdicionarParametros("aCodCliente", pagamento.Cliente.Codigo);
                //acessoMySql.AdicionarParametros("aTipo", pagamento.Tipo);
                //acessoMySql.AdicionarParametros("aDataPagamento", pagamento.DataPagamento);
                //acessoMySql.AdicionarParametros("aValor", pagamento.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PagamentoAlterar");
                return "Pagamento alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string PagamentoExcluir(Pagamento pagamento)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", pagamento.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PagamentoExcluir");
                return "Pagamento excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string PedidoInserir(Pedido pedido)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodAluguel", pedido.CodigoAluguel);
                //acessoMySql.AdicionarParametros("aCodProduto", pedido.CodigoProduto);
                //acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
                //acessoMySql.AdicionarParametros("aQtde", pedido.Qtde);
                //acessoMySql.AdicionarParametros("aValor", pedido.Valor);
                pedido.Codigo = Convert.ToInt32(acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PedidoNovo"));
                return "Pedido adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string PedidoAlterar(Pedido pedido)
        {
            try
            {
                //acessoMySql.AdicionarParametros("aCodigo", pedido.Codigo);
                //acessoMySql.AdicionarParametros("aCodAluguel", pedido.CodigoAluguel);
                //acessoMySql.AdicionarParametros("aCodProduto", pedido.CodigoProduto);
                //acessoMySql.AdicionarParametros("aDataPedido", pedido.DataPedido);
                // acessoMySql.AdicionarParametros("aQtde", pedido.Qtde);
                //acessoMySql.AdicionarParametros("aValor", pedido.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PedidoAlterar");
                return "Pedido alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string PedidoExcluir(Pedido pedido)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", pedido.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_PedidoExcluir");
                return "Pedido excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ProdutoInserir(Produto produto)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", produto.Codigo);
                //acessoMySql.AdicionarParametros("aNome", produto.Nome);
                //acessoMySql.AdicionarParametros("aValor", produto.Valor);
                //acessoMySql.AdicionarParametros("aQtdeAtual", produto.Qtdeatual);
                return acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ProdutoNovo").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ProdutoAlterar(Produto produto)
        {
            try
            {
                //acessoMySql.AdicionarParametros("aCodigo", produto.Codigo);
                //acessoMySql.AdicionarParametros("aNome", produto.Nome);
                //acessoMySql.AdicionarParametros("aValor", produto.Valor);
                //acessoMySql.AdicionarParametros("aQtdeAtual", produto.Qtdeatual);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ProdutoAlterar");
                return "Produto alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ProdutoExcluir(Produto produto)
        {
            try
            {
                //acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodigo", produto.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ProdutoExcluir");
                return "Produto excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
