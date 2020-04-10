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
    public class ProdutoNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Produto produto)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", produto.Codigo);
                acessoMySql.AdicionarParametros("aNome", produto.Nome);
                acessoMySql.AdicionarParametros("aValor", produto.Valor);
                acessoMySql.AdicionarParametros("aQtdeAtual", produto.Qtdeatual);
                return acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ProdutoNovo").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Produto produto)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", produto.Codigo);
                acessoMySql.AdicionarParametros("aNome", produto.Nome);
                acessoMySql.AdicionarParametros("aValor", produto.Valor);
                acessoMySql.AdicionarParametros("aQtdeAtual", produto.Qtdeatual);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ProdutoAlterar");
                return "Produto alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Produto produto)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", produto.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_ProdutoExcluir");
                return "Produto excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Produto Produto(Produto produto)
        {
            try
            {
                DataTable dataTableProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, nome, valor, qtdeAtual FROM produto WHERE codigo = " + produto.Codigo, false);

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    produto.Codigo = Convert.ToInt32(linha["codigo"]);
                    produto.Nome = linha["nome"].ToString();
                    produto.Valor = Convert.ToDouble(linha["valor"]);

                    if (linha["qtdeAtual"] is DBNull)
                    {
                        produto.Qtdeatual = null;
                    }
                    else
                    {
                        produto.Qtdeatual = Convert.ToInt32(linha["qtdeAtual"]);
                    }
                }
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Produtos.\nDetalhes: " + ex.Message);
            }
        }

        public List<Produto> Produtos()
        {
            try
            {
                List<Produto> produtos = new List<Produto>();
                
                DataTable dataTableProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, nome, valor, qtdeAtual FROM produto ORDER BY codigo", false);

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    Produto produto = new Produto();
                    produto.Codigo = Convert.ToInt32(linha["codigo"]);
                    produto.Nome = linha["nome"].ToString();
                    produto.Valor = Convert.ToDouble(linha["valor"]);

                    if (linha["qtdeAtual"] is DBNull)
                    {
                        produto.Qtdeatual = null;
                    }
                    else
                    {
                        produto.Qtdeatual = Convert.ToInt32(linha["qtdeAtual"]);
                    }
                    produtos.Add(produto);
                }
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Produtos.\nDetalhes: " + ex.Message);
            }
        }

        public List<Produto> ProdutosEstoque()
        {
            try
            {
                List<Produto> produtos = new List<Produto>();

                DataTable dataTableProduto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, nome, valor, qtdeAtual FROM produto WHERE qtdeAtual IS NOT NULL ORDER BY codigo", false);

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    Produto produto = new Produto();
                    produto.Codigo = Convert.ToInt32(linha["codigo"]);
                    produto.Nome = linha["nome"].ToString();
                    produto.Valor = Convert.ToDouble(linha["valor"]);

                    if (linha["qtdeAtual"] is DBNull)
                    {
                        produto.Qtdeatual = null;
                    }
                    else
                    {
                        produto.Qtdeatual = Convert.ToInt32(linha["qtdeAtual"]);
                    }
                    produtos.Add(produto);
                }
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Produtos.\nDetalhes: " + ex.Message);
            }
        }

    }
}
