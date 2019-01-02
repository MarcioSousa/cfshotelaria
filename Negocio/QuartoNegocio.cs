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
    public class QuartoNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Quarto quarto)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aNumero", quarto.Numero);
                acessoMySql.AdicionarParametros("aValorDiaria", quarto.ValorDiaria);
                acessoMySql.AdicionarParametros("aLocalidade", quarto.Localidade);
                return acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_QuartoNovo").ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Quarto quarto)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aNumero", quarto.Numero);
                acessoMySql.AdicionarParametros("aValorDiaria", quarto.ValorDiaria);
                acessoMySql.AdicionarParametros("aLocalidade", quarto.Localidade);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_QuartoAlterar");
                return "Quarto " + quarto.Numero + " alterado com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Quarto quarto)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aNumero", quarto.Numero);
                acessoMySql.ExecutarManipulacao(CommandType.StoredProcedure, "usp_QuartoExcluir");
                return "Quarto " + quarto.Numero + " excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public List<Quarto> Quartos()
        {
            try
            {
                List<Quarto> quartos = new List<Quarto>();

                DataTable dataTableQuarto = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_Quartos", false);

                foreach (DataRow linha in dataTableQuarto.Rows)
                {
                    Quarto quarto = new Quarto(Convert.ToInt32(linha["numero"]),Convert.ToDouble(linha["valorDiaria"]),linha["localidade"].ToString());
                    quartos.Add(quarto);
                }

                return quartos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Quartos.\nDetalhes: " + ex.Message);
            }
        }

        public List<Quarto> QuartosOcupados()
        {
            try
            {
                List<Quarto> quartos = new List<Quarto>();

                DataTable dataTableQuarto = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_QuartosOcupados", false);

                foreach (DataRow linha in dataTableQuarto.Rows)
                {
                    Quarto quarto = new Quarto(Convert.ToInt32(linha["numero"]), Convert.ToDouble(linha["valorDiaria"]), linha["localidade"].ToString());
                    quartos.Add(quarto);
                }

                return quartos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Quartos Ocupados.\nDetalhes: " + ex.Message);
            }
        }

        public void AddLimpezas(Quarto quarto)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodQuarto", quarto.Numero);
                DataTable dataTableLimpezasQuarto = acessoMySql.ExecutarConsulta(CommandType.StoredProcedure, "usp_QuartoLimpezas", false);

                foreach (DataRow linha in dataTableLimpezasQuarto.Rows)
                {
                    Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quarto);
                    quarto.Limpezas.Add(limpeza);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar os Quartos.\nDetalhes: " + ex.Message);
            }
            
        }

    }
}
