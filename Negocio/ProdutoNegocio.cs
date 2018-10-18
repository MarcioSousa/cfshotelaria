﻿using System;
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
                acessoMySql.AdicionarParametros("aNome", produto.Nome);
                acessoMySql.AdicionarParametros("aValor", produto.Valor);
                acessoMySql.AdicionarParametros("aQtdeAtual", produto.Qtdeatual);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ProdutoNovo");
                return "Produto adicionado com sucesso!";
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
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ProdutoAlterar");
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
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ProdutoExcluir");
                return "Produto excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Produto> Produtos()
        {
            try
            {
                List<Produto> produtos = new List<Produto>(); 

                DataTable dataTableProduto = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_Produtos", false);

                foreach (DataRow linha in dataTableProduto.Rows)
                {
                    Produto produto = new Produto(Convert.ToInt32(linha["codigo"]), linha["nome"].ToString(), Convert.ToDouble(linha["valor"]));

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