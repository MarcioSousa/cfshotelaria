using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Control.Properties;

namespace Control
{
    class AcessoMySql
    {
        protected readonly MySqlParameterCollection mySqlParameterCollection = new MySqlCommand().Parameters;

        private MySqlConnection CriarConexao()
        {
            return new MySqlConnection(Settings.Default.stringConexaoHotelariaMysql);
        }
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

                MySqlConnection mySqlConnection = CriarConexao();
                mySqlConnection.Open();

                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandType = commandType;
                mySqlCommand.CommandText = nomeStoreProcedureOuTextoSql;
                mySqlCommand.CommandTimeout = 7200;

                foreach (MySqlParameter mySqlParameter in mySqlParameterCollection)
                {
                    mySqlCommand.Parameters.Add(new MySqlParameter(mySqlParameter.ParameterName, mySqlParameter.Value));
                }
                mySqlCommand.ExecuteScalar();
                mySqlConnection.Close();
                return 1;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public DataTable ExecutarConsulta(CommandType commandType, string nomeStoreProcedureOuTextoSql)
        {
            try
            {
                MySqlConnection mySqlConnection = CriarConexao();
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
                mySqlConnection.Clone();
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
