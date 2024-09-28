using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using UHF_RFID_READER.Resources;
using Newtonsoft.Json;

namespace UHF_RFID_READER.DAO
{
    public class DbConnection
    {
        private static string ip = ConfigurationManager.AppSettings["DatabaseIP"];
        private static string user = ConfigurationManager.AppSettings["UsernameDb"];
        private static string pass = ConfigurationManager.AppSettings["PasswordDb"];
        private static string database = ConfigurationManager.AppSettings["DatabaseName"];
        public string connectionString = $"Data Source={ip};Initial Catalog={database};User ID={user};Password={pass};";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            try
            {

                DataTable data = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    if (IsConnectionOpen(conn))
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        int i = 0;
                        if (parameter != null)
                        {
                            string[] listPara = query.Split(' ');
                            foreach (string item in listPara)
                            {
                                if (item.Contains('@'))
                                {
                                    cmd.Parameters.AddWithValue(item, parameter[i]);
                                    i++;
                                }
                            }
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(data);
                    }
                    else
                    {
                        //MessageBox.Show($"Cannot connect to database: {ip}, please check your database information / database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Helper.WriteLogError($"Error: {DateTime.Now} Cannot READ FROM database: {ip}, please check your database information / database)", $"Log DATABASE CONNECTION");
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {DateTime.Now} - Execute Query {JsonConvert.SerializeObject(query)} to  database: {ip})", $"Log DATABASE EXECUTEQUERY");
                return null;
            }
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    if (IsConnectionOpen(connection))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        int i = 0;
                        if (parameter != null)
                        {
                            string[] listPara = query.Split(' ');
                            foreach (string item in listPara)
                            {
                                if (item.Contains('@'))
                                {
                                    command.Parameters.AddWithValue(item, parameter[i]);
                                    i++;
                                }
                            }
                        }

                        data = command.ExecuteNonQuery();
                    }
                    else
                    {
                        Helper.WriteLogError($"Error: {DateTime.Now} Cannot READ FROM database: {ip}, please check your database information / database)", $"Log DATABASE CONNECTION");
                    }
                }

                return data;
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {DateTime.Now} - Execute NON Query {JsonConvert.SerializeObject(query)} to  database: {ip})", $"Log DATABASE EXECUTENONQUERY");
                return data;
            }
        }

        public int ExecuteNonQueryTranSaction(string query, object[] parameters = null)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            if (parameters != null)
                            {
                                string[] parameterNames = query.Split(' ')
                                    .Where(p => p.StartsWith("@"))
                                    .ToArray();

                                for (int i = 0; i < parameters.Length; i++)
                                {
                                    command.Parameters.AddWithValue(parameterNames[i], parameters[i]);
                                }
                            }
                            result = command.ExecuteNonQuery();
                        }
                        // Commit transaction if no exception
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now}", "InsertTransaction");
                        transaction.Rollback();
                    }
                }
            }

            return result;
        }

        private bool IsConnectionOpen(SqlConnection connection)
        {
            try
            {
                connection.Open();
                return connection.State == ConnectionState.Open;
            }
            catch
            {
                return false;
            }
        }
    }
}
