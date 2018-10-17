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
    public class LimpezaNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Limpeza limpeza)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodQuarto", limpeza.Quarto.Numero);
                acessoMySql.AdicionarParametros("aDataLimpeza", limpeza.DataLimpeza);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_LimpezaNovo");
                return "Limpeza adicionado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Limpeza limpeza)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", limpeza.Codigo);
                acessoMySql.AdicionarParametros("aCodQuarto", limpeza.Quarto.Numero);
                acessoMySql.AdicionarParametros("aDataLimpeza", limpeza.DataLimpeza);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_LimpezaAlterar");
                return "Limpeza alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Limpeza limpeza)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", limpeza.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_LimpezaExcluir");
                return "Limpeza excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Limpeza> Limpezas(List<Quarto> quartos)
        {
            try
            {
                List<Limpeza> limpezas = new List<Limpeza>();

                DataTable dataTableLimpeza = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_Limpezas", false);

                foreach (DataRow linha in dataTableLimpeza.Rows)
                {
                    for (int t = 0; t < quartos.Count; t++)
                    {
                        if (Convert.ToInt32(linha["cod_quarto"]) == quartos[t].Numero)
                        {
                            Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quartos[t]);
                            limpezas.Add(limpeza);
                        }
                    }
                }
                return limpezas;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar as Limpezas.\nDetalhes: " + ex.Message);
            }
        }

    }
}