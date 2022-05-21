using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RegApp
{
    internal class DataBaseWorker
    {
        private readonly string connectionString;
        private SqlConnection connection;
        private static string db_name = "RegAppBd";
        

        public DataBaseWorker()
        {
            connectionString = $"Server=localhost;Database={db_name};Trusted_Connection=True;";

        }

        public void OpentConection()
        {
            // Создание подключения
            connection = new SqlConnection(connectionString);

            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("неполучилось открыть бд");
                Console.WriteLine(ex.Message);
            }
        }

        public List<string[]> ExecuteQuery(string query, int col)
        {
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            List<string[]> response = new List<string[]>();

            while (sqlDataReader.Read())
            {
                response.Add(new string[col]);

                for(int i = 0; i < col; i++)
                {
                    response[response.Count - 1][i] = sqlDataReader[i].ToString();
                } 
            }
            sqlDataReader.Close();
            if (response.Count > 0)
                return response;
            else
                return null;
        }

         public string ExecuteQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader cmdDataReader = cmd.ExecuteReader();

            string response = null;

            while (cmdDataReader.Read())
            {
                response = cmdDataReader[0].ToString();
            }

            cmdDataReader.Close();

            return response;
        }



        public void CloseConection()
        {
            try
            {
                connection.Close();
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
