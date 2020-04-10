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
        AcessoSqlServer acessoSqlServer = new AcessoSqlServer();

        //MANIPULAÇÃO
        public string Inserir(Limpeza limpeza)
        {
            try
            {
                acessoSqlServer.ExecutarManipulacao(CommandType.Text, "INSERT INTO limpeza(cod_quarto, datalimpeza) VALUES(" + limpeza.Quarto.Numero+ ", " + limpeza.DataLimpeza + ")");
                return "Salvo com sucesso!";
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
                acessoSqlServer.ExecutarManipulacao(CommandType.Text, "UPDATE limpeza SET cod_quarto = " + limpeza.Quarto.Numero + ", datalimpeza = " + limpeza.DataLimpeza + " WHERE codigo = " + limpeza.Codigo);
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
                acessoSqlServer.ExecutarManipulacao(CommandType.Text, "DELETE FROM limpeza WHERE codigo = " + limpeza.Codigo);
                return "Limpeza excluído com Sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //SELÊÇÃO
        public List<Limpeza> Limpezas(Quarto quarto)
        {
            try
            {
                List<Limpeza> limpezas  = new List<Limpeza>();

                DataTable dataTableQuarto = acessoSqlServer.ExecutarConsulta(CommandType.Text, "SELECT codigo, datalimpeza FROM limpeza WHERE cod_quarto = " + quarto.Numero + " ORDER BY datalimpeza DESC LIMIT 0,10");

                foreach (DataRow linha in dataTableQuarto.Rows)
                {
                    Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quarto);
                    limpezas.Add(limpeza);
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

        //public List<Limpeza> Limpezas(List<Quarto> quartos)
        //{
        //    try
        //    {
        //        List<Limpeza> limpezas = new List<Limpeza>();
        //        for (int t = 0; t < quartos.Count; t++)
        //        {
        //            acessoMySql.LimparParametros();
        //            DataTable dataTableLimpeza = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, datalimpeza FROM limpeza WHERE cod_quarto = " + quartos[t].Numero + " LIMIT 0,2", false);

        //            foreach (DataRow linha in dataTableLimpeza.Rows)
        //            {
        //                Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quartos[t]);
        //                limpezas.Add(limpeza);
        //            }
        //        }
        //        return limpezas;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível carregar os Quartos.\nDetalhes: " + ex.Message);
        //    }
        //}


//public Quarto AddLimpeza(Quarto quarto)
//{
//    try
//    {
//        Quarto quarto1 = new Quarto(20, 0, "teste");
//        List<Limpeza> limpezas = new List<Limpeza>();
//        for (int t = 0; t < quartos.Count; t++)
//        {
//            acessoMySql.LimparParametros();
//            DataTable dataTableLimpeza = acessoMySql.ExecutarConsulta(CommandType.Text, "SELECT codigo, cod_quarto, datalimpeza FROM limpeza WHERE cod_quarto = " + quartos[t].Numero + " ORDER BY datalimpeza DESC LIMIT 10", false);

//            foreach (DataRow linha in dataTableLimpeza.Rows)
//            {
//                Limpeza limpeza = new Limpeza(Convert.ToInt32(linha["codigo"]), Convert.ToDateTime(linha["datalimpeza"]), quartos[t]);
//                limpezas.Add(limpeza);
//            }
//        }

//        return quarto1;
//    }
//    catch (Exception ex)
//    {
//        throw new Exception("Não foi possível carregar as Limpezas.\nDetalhes: " + ex.Message);
//    }
//}