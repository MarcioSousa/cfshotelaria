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
                acessoMySql.AdicionarParametros("aCodProduto", entrada.Produto.Codigo);
                acessoMySql.AdicionarParametros("aDataEntrada", entrada.DataEntrada);
                acessoMySql.AdicionarParametros("aDataVencimento", entrada.DataVencimento);
                acessoMySql.AdicionarParametros("aQtde", entrada.Qtde);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_EntradaNovo");
                return "Entrada adicionado com sucesso!";
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
                acessoMySql.AdicionarParametros("aCodProduto", entrada.Produto.Codigo);
                acessoMySql.AdicionarParametros("aDataEntrada", entrada.DataEntrada);
                acessoMySql.AdicionarParametros("aDataVencimento", entrada.DataVencimento);
                acessoMySql.AdicionarParametros("aQtde", entrada.Qtde);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_EntradaAlterar");
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
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_EntradaExcluir");
                return "Entrada excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
