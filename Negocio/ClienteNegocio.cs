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
    public class ClienteNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Cliente cliente)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodAluguel", cliente.Aluguel.Codigo);
                acessoMySql.AdicionarParametros("aNome", cliente.Nome);
                acessoMySql.AdicionarParametros("aRg", cliente.Rg);
                acessoMySql.AdicionarParametros("aCpf", cliente.Cpf);
                acessoMySql.AdicionarParametros("aContato", cliente.Contato);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ClienteNovo");
                return "Cliente adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Cliente cliente)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", cliente.Codigo);
                acessoMySql.AdicionarParametros("aCodAluguel", cliente.Aluguel.Codigo);
                acessoMySql.AdicionarParametros("aNome", cliente.Nome);
                acessoMySql.AdicionarParametros("aRg", cliente.Rg);
                acessoMySql.AdicionarParametros("aCpf", cliente.Cpf);
                acessoMySql.AdicionarParametros("aContato", cliente.Contato);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ClienteAlterar");
                return "Cliente alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Cliente cliente)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", cliente.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ClienteExcluir");
                return "Cliente excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Cliente> ClientesAtivos(List<Aluguel> alugueis)
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                for (int t = 0; t < alugueis.Count; t++)
                {
                    acessoMySql.LimparParametros();
                    DataTable dataTableClientesAluguel = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_aluguel, nome, rg, cpf, contato FROM cliente WHERE cod_aluguel = " + alugueis[t].Codigo, false);

                    foreach (DataRow linha in dataTableClientesAluguel.Rows)
                    {
                        Cliente cliente = new Cliente(Convert.ToInt32(linha["codigo"]), linha["nome"].ToString(), linha["rg"].ToString(), linha["cpf"].ToString(), linha["contato"].ToString(), alugueis[t]);
                        clientes.Add(cliente);
                    }
                }
                
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Alugueis dos Clientes.\nDetalhes: " + ex.Message);
            }
        }

    }
}

        //public List<Cliente> Clientes()
        //{
        //    try
        //    {
        //        List<Cliente> clientes = new List<Cliente>();

        //        DataTable dataTableCliente = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_Clientes", false);

        //        foreach (DataRow linha in dataTableCliente.Rows)
        //        {
        //            Cliente cliente = new Cliente();
        //            cliente.Codigo = Convert.ToInt32(linha["codigo"]);
        //            cliente.Aluguel.Codigo = Convert.ToInt32(linha["cod_aluguel"]);
        //            cliente.Nome = linha["nome"].ToString();
        //            cliente.Rg = linha["rg"].ToString();
        //            cliente.Cpf = linha["cpf"].ToString();
        //            cliente.Contato = linha["contato"].ToString();

        //            clientes.Add(cliente);
        //        }
        //        return clientes;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível carregar os Clientes.\nDetalhes: " + ex.Message);
        //    }
        //}