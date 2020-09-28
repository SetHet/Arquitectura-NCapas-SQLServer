using ConexionBaseDeDatos;
using ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuario
    {
        private ConexionSQLServer conexionBD;

        public NegocioUsuario()
        {
            ConexionBD = new ConexionSQLServer();
            ConexionBD.Server = ConexionConfig.Server;
            ConexionBD.Database = ConexionConfig.Database;
            ConexionBD.Connect();
        }

        public ConexionSQLServer ConexionBD { get => conexionBD; set => conexionBD = value; }
        

        public Usuario GetUser(int id)
        {
            Usuario usuario = null;
            string sql = $"SELECT * From Usuario Where id='{id}'";
            DataTable dataTable = ConexionBD.Select(sql);
            if (dataTable.Rows.Count > 0) {
                usuario = new Usuario();
                usuario.Id = dataTable.Rows[0].Field<int>("id");
                usuario.Name = dataTable.Rows[0].Field<string>("nombre");
            }
            return usuario;
        }

        public void AddUser(string name)
        {
            string sql = $"INSERT INTO Usuario (nombre) VALUES ('{name}')";
            ConexionBD.NoSelect(sql);
        }
    }
}
