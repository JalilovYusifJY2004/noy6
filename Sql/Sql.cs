using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noy5.Sql
{
    internal class Sql
    {
        private const string connected = "server=DESKTOP-8CCT4OL;database=noy5;trusted_connection=true;integrated security=true;";
        private static SqlConnection _connection =new SqlConnection(connected);

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            try
            {
                _connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, _connection);

                dataAdapter.Fill(table);

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                _connection.Close();
            }

            return table;
        }
        public int ExecuteCommand(string cmd)
        {
            int result = 0;
            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand(cmd, _connection);
                result = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }

    }
}