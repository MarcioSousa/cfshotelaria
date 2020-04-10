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
    public class AluguelNegocio
    {
        AcessoMySql acessoMySql = new AcessoMySql();

        public string Inserir(Aluguel aluguel)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodQuarto", aluguel.NumeroQuarto);
                acessoMySql.AdicionarParametros("aValor", aluguel.Valor);
                acessoMySql.AdicionarParametros("aDataChegada", aluguel.DataChegada);
                aluguel.Codigo = Convert.ToInt32(acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_AluguelNovo"));
                return aluguel.Codigo.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(Aluguel aluguel)
        {
            try
            {
                acessoMySql.AdicionarParametros("aCodigo", aluguel.Codigo);
                acessoMySql.AdicionarParametros("aCodQuarto", aluguel.NumeroQuarto);
                acessoMySql.AdicionarParametros("aValor", aluguel.Valor);
                acessoMySql.AdicionarParametros("aDataChegada", aluguel.DataChegada);
                acessoMySql.AdicionarParametros("aDataSaida", aluguel.DataSaida);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_AluguelAlterar");
                return "Aluguel alterado com sucesso!.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Excluir(Aluguel aluguel)
        {
            try
            {
                acessoMySql.LimparParametros();
                acessoMySql.AdicionarParametros("aCodigo", aluguel.Codigo);
                acessoMySql.ExecutarManipulacao(CommandType.Text, "usp_AluguelExcluir");
                return "Aluguel excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Aluguel AluguelQuartoSelecionado(Quarto quarto)
        {
            try
            {
                Aluguel aluguel = new Aluguel();

                acessoMySql.LimparParametros();
                DataTable dataTableAluguelQuarto = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, dataChegada, valor FROM aluguel WHERE cod_quarto = " + quarto.Numero + " AND dataSaida IS NULL", false);

                foreach (DataRow linha in dataTableAluguelQuarto.Rows)
                {
                    aluguel.Codigo = Convert.ToInt32(linha["codigo"]);
                    aluguel.Valor = Convert.ToDouble(linha["valor"]);
                    aluguel.DataChegada = Convert.ToDateTime(linha["dataChegada"]);
                }

                return aluguel;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível carregar o Aluguel do quarto selecionado.\nDetalhes: " + ex.Message);
            }
        }

    }
}
