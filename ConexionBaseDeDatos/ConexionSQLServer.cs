using System;
using System.Collections.Generic;
using System.Data;
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
        public string ConectionString { get => conectionString; set => conectionString = value; }
        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }

        public ConexionSQLServer()
        {
            ConectionString = @"Server = DESKTOP-F8TM6K2; Database = TestA; Trusted_Connection = True;";
            SqlConnection = new SqlConnection(ConectionString);
        }

        public void Open()
        {
            try
            {
                SqlConnection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en \"ConexionSQLServer.Open()\" \n\n" + ex.Message);
            }
        }

        public void Close()
        {
            try
            {
                SqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en \"ConexionSQLServer.Close()\" \n\n" + ex.Message);
            }
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


        public DataTable Select(string table, string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                
            }
            catch(Exception ex)
            {

            }

            return dataTable;
        }

        public void NoSelect(string query)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }


        public void ConsoleTest()
        {
            ConexionSQLServer con = new ConexionSQLServer();

            Console.WriteLine("Conectado: " + con.isOpen());
            con.Open();
            Console.WriteLine("Conectado: " + con.isOpen());
            con.Close();
            Console.WriteLine("Conectado: " + con.isOpen());

            Console.ReadKey();
        }
    }
}
