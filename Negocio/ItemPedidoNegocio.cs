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
    public class ItemPedidoNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(ItemPedido itemPedido)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodProduto", itemPedido.Produto.Codigo);
                acessoMySql.AdicionarParametros("aCodPedido", itemPedido.Pedido.Codigo);
                acessoMySql.AdicionarParametros("aQtde", itemPedido.Qtde);
                acessoMySql.AdicionarParametros("aValor", itemPedido.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ItemPedidoNovo");
                return "Item Pedido adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(ItemPedido itemPedido)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", itemPedido.Codigo);
                acessoMySql.AdicionarParametros("aCodProduto", itemPedido.Produto.Codigo);
                acessoMySql.AdicionarParametros("aCodPedido", itemPedido.Pedido.Codigo);
                acessoMySql.AdicionarParametros("aQtde", itemPedido.Qtde);
                acessoMySql.AdicionarParametros("aValor", itemPedido.Valor);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ItemPedidoAlterar");
                return "Item Pedido alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(ItemPedido itemPedido)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", itemPedido.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_ItemPedidoExcluir");
                return "Item Pedido excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ItemPedido> ItemPedidos(List<Pedido> pedidos, List<Produto> produtos)
        {
            try
            {
                List<ItemPedido> itemPedidos = new List<ItemPedido>();
                for (int t = 0; t < pedidos.Count; t++)
                {
                    acessoMySql.LimparParametros();
                    DataTable dataTableItemPedido = acessoMySql.ExecutarConsulta(CommandType.Text,
                        "SELECT I.codigo, P.nome, I.qtde, I.valor, I.cod_pedido, I.cod_produto FROM itempedido I " +
                        "INNER JOIN produto P ON I.cod_produto = P.codigo " +
                        "INNER JOIN pedido E ON E.codigo = I.cod_pedido " +
                        "INNER JOIN aluguel A ON A.codigo = E.cod_aluguel " +
                        "WHERE A.dataSaida IS NULL AND I.cod_pedido = " + pedidos[t].Codigo, false);
                    for (int u = 0; u < produtos.Count; u++)
                    {
                        foreach (DataRow linha in dataTableItemPedido.Rows)
                        {
                            if (pedidos[t].Codigo == Convert.ToInt32(linha["cod_pedido"]) && produtos[u].Codigo == Convert.ToInt32(linha["cod_produto"]))
                            {
                                ItemPedido itemPedido = new ItemPedido(Convert.ToInt32(linha["codigo"]), Convert.ToInt32(linha["qtde"]), Convert.ToDouble(linha["valor"]), produtos[u], pedidos[t]);
                                itemPedidos.Add(itemPedido);
                            }
                        }

                    }
                }

                return itemPedidos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os ItemPedidos.\nDetalhes: " + ex.Message);
            }
        }


    }
}

//SELECT I.codigo, P.nome, I.qtde, I.valor, I.cod_pedido, I.cod_produto FROM itempedido I
//INNER JOIN produto P ON I.cod_produto = P.codigo
//INNER JOIN pedido E ON E.codigo = I.cod_pedido
//INNER JOIN aluguel A ON A.codigo = E.cod_aluguel
//WHERE A.dataSaida IS NULL AND I.cod_pedido = 8