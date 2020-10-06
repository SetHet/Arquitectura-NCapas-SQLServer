using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionBaseDeDatos
{
    public class ConexionSQLServer
    {
        private string conectionString;
        private SqlConnection sqlConnection;
        private string server = "";
        private string database = "";

        public ConexionSQLServer()
        {
            SqlConnection = new SqlConnection();
        }

        public string ConectionString { get => conectionString; set => conectionString = value; }
        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public string Server { get => server; set => server = value; }
        public string Database { get => database; set => database = value; }

        public bool Connect()
        {
            if (Server.Equals(String.Empty))
            {
                MessageBox.Show("Error nombre servidor", "Sistema");
                return false;
            }
            if (Database.Equals(String.Empty))
            {
                MessageBox.Show("Error nombre base de datos", "Sistema");
                return false;
            }
            
            ConectionString = $"Server = {Server}; Database = {Database}; Trusted_Connection = True;";
            
            try
            {
                SqlConnection = new SqlConnection(ConectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexion\n" + ex.Message, "Sistema");
                return false;
            }

            return true;
        }

        public bool Open()
        {
            try
            {
                this.SqlConnection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en \"ConexionSQLServer.Open()\" \n\n" + ex.Message);
                return false;
            }
            return true;
        }

        public bool Close()
        {
            try
            {
                this.SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en \"ConexionSQLServer.Close()\" \n\n" + ex.Message);
                return false;
            }
            return true;
        }

        public bool isOpen()
        {
            bool active = false;

            try
            {
                active = (SqlConnection.State == ConnectionState.Open);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en \"ConexionSQLServer.isOpen()\" \n\n" + ex.Message);
                active = false;
            }

            return active;
        }


        public DataTable Select(string query)
        {
            DataTable dataTable = new DataTable();

            this.Open();

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, SqlConnection);
                dataAdapter.Fill(dataTable);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en el \"ConexionSQLServer.Select\" \n" + ex.Message, "Sistema");
            }

            this.Close();

            return dataTable;
        }

        public void NoSelect(string query)
        {
            this.Open();

            try
            {
                SqlCommand command = new SqlCommand(query, SqlConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en el \"ConexionSQLServer.NoSelect\" \n" + ex.Message, "Sistema");
            }

            this.Close();
        }


        public void ConsoleTest()
        {
            ConexionSQLServer con = new ConexionSQLServer();
            con.Server = "DESKTOP-F8TM6K2";
            con.Database = "TestA";
            con.Connect();

            Console.WriteLine("Conectado: " + con.isOpen());
            con.Open();
            Console.WriteLine("Conectado: " + con.isOpen());
            con.Close();
            Console.WriteLine("Conectado: " + con.isOpen());

            Console.ReadKey();
        }
    }
}
