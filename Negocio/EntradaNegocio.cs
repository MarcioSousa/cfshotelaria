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
    public class EntradaNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Entrada entrada)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodProduto", entrada.CodigoProduto);
                acessoMySql.AdicionarParametros("aDataEntrada", entrada.DataEntrada);
                acessoMySql.AdicionarParametros("aDataVencimento", entrada.DataVencimento);
                acessoMySql.AdicionarParametros("aQtde", entrada.Qtde);
                return acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_EntradaNovo").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Entrada entrada)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", entrada.Codigo);
                acessoMySql.AdicionarParametros("aDataEntrada", entrada.DataEntrada);
                acessoMySql.AdicionarParametros("aDataVencimento", entrada.DataVencimento);
                acessoMySql.AdicionarParametros("aQtde", entrada.Qtde);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_EntradaAlterar");
                return "Entrada alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Entrada entrada)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", entrada.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_EntradaExcluir");
                return "Entrada excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Entrada> Entradas(Produto produto)
        {
            try
            {
                List<Entrada> entradas = new List<Entrada>();

                acessoMySql.LimparParametros();

                DataTable dataTableClientesAluguel = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_produto, dataEntrada, dataVencimento, qtde FROM entrada WHERE cod_produto = " + produto.Codigo + " ORDER BY dataEntrada DESC", false);

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

    }
}
