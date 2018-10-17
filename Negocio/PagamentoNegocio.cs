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
    public class PagamentoNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Pagamento pagamento)
        {
            try
            {
                acessoMySql.LimparParametros();
                //acessoMySql.AdicionarParametros("aCodCliente", pagamento.Cliente.Codigo);
                acessoMySql.AdicionarParametros("aTipo", pagamento.Tipo);
                acessoMySql.AdicionarParametros("aDataPagamento", pagamento.DataPagamento);
                acessoMySql.AdicionarParametros("aValor", pagamento.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PagamentoNovo");
                return "Pagamento adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Pagamento pagamento)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", pagamento.Codigo);
                //acessoMySql.AdicionarParametros("aCodCliente", pagamento.Cliente.Codigo);
                acessoMySql.AdicionarParametros("aTipo", pagamento.Tipo);
                acessoMySql.AdicionarParametros("aDataPagamento", pagamento.DataPagamento);
                acessoMySql.AdicionarParametros("aValor", pagamento.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PagamentoAlterar");
                return "Pagamento alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Pagamento pagamento)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", pagamento.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_PagamentoExcluir");
                return "Pagamento excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Pagamento> Pagamentos(List<Aluguel> alugueis)
        {
            try
            {
                List<Pagamento> pagamentos = new List<Pagamento>();

                DataTable dataTablePagamentos = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_Pagamentos", false);

                foreach (DataRow linha in dataTablePagamentos.Rows)
                {
                    Pagamento pagamento = new Pagamento();
                    pagamento.Codigo = Convert.ToInt32(linha["aCodigo"]);
                    //pagamento.Cliente.Codigo = Convert.ToInt32(linha["aCodCliente"]);
                    pagamento.Tipo = linha["aTipo"].ToString();
                    pagamento.DataPagamento = Convert.ToDateTime(linha["aDataPagamento"]);
                    pagamento.Valor = Convert.ToDouble(linha["aValor"]);

                    pagamentos.Add(pagamento);
                }
                return pagamentos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Pagamentos.\nDetalhes: " + ex.Message);
            }
        }

    }
}







//        public List<Cliente> ClientesAluguel(List<Aluguel> alugueis)
//        {
//            try
//            {
//                List<Cliente> clientes = new List<Cliente>();

//                DataTable dataTableClientesAluguel = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_ClientesAluguel", false);

//                foreach (DataRow linha in dataTableClientesAluguel.Rows)
//                {
//                    for (int t = 0; t < alugueis.Count; t++)
//                    {
//                        if (Convert.ToInt32(linha["cod_aluguel"]) == alugueis[t].Codigo)
//                        {
//                            Cliente cliente = new Cliente(Convert.ToInt32(linha["codigo"]), linha["nome"].ToString(), linha["rg"].ToString(), linha["cpf"].ToString(), linha["contato"].ToString(), alugueis[t]);
//                            clientes.Add(cliente);
//                        }
//                    }
//                }
//                return clientes;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Não foi possível carregar os Alugueis dos Clientes.\nDetalhes: " + ex.Message);
//            }
//        }

//    }
//}