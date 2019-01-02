using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Control.Properties;
using System.Data;
using MySql.Data.MySqlClient;


namespace Control
{
    public class AcessoMySql
    {
        private MySqlConnection CriarConexao(bool login)
        {
            if (login)
            {
                return new MySqlConnection(Settings.Default.stringConexaoCadFacil);
            }
            else
            {
                return new MySqlConnection(Settings.Default.stringConexaoHotelaria);
            }
        }

        private MySqlParameterCollection mySqlParameterCollection = new MySqlCommand().Parameters;

        public void LimparParametros()
        {
            mySqlParameterCollection.Clear();
        }

        public void AdicionarParametros(string nomeParametro, object valorParametro)
        {
            mySqlParameterCollection.Add(new MySqlParameter(nomeParametro, valorParametro));
        }

        public object ExecutarManipulacao(CommandType commandType, string nomeStoreProcedureOuTextoSql)
        { 
            try
            {
                int codigo;
                MySqlConnection mySqlConnection = CriarConexao(false);
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandType = commandType;
                mySqlCommand.CommandText = nomeStoreProcedureOuTextoSql;
                mySqlCommand.CommandTimeout = 7200;


                foreach(MySqlParameter mySqlParameter in mySqlParameterCollection)
                {
                    mySqlCommand.Parameters.Add(new MySqlParameter(mySqlParameter.ParameterName, mySqlParameter.Value));
                }

                codigo = Convert.ToInt32(mySqlCommand.ExecuteScalar());
                mySqlConnection.Close();

                return codigo;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoreProcedureOuTextoSql, bool login)
        {
            try
            {
                MySqlConnection mySqlConnection = CriarConexao(login);
                mySqlConnection.Open();
                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandType = commandType;
                mySqlCommand.CommandText = nomeStoreProcedureOuTextoSql;
                mySqlCommand.CommandTimeout = 7200;

                foreach (MySqlParameter mySqlParameter in mySqlParameterCollection)
                {
                    mySqlCommand.Parameters.Add(new MySqlParameter(mySqlParameter.ParameterName, mySqlParameter.Value));
                }

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);
                mySqlConnection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}