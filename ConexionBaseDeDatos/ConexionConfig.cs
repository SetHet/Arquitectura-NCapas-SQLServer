using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionBaseDeDatos
{
    public static class ConexionConfig
    {
        private static string server;
        private static string database;

        public static string Server { get => server; set => server = value; }
        public static string Database { get => database; set => database = value; }
    }
}
