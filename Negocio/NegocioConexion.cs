using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioConexion
    {
        public static void SetUp()
        {
            ConexionBaseDeDatos.ConexionConfig.Server = "DESKTOP-F8TM6K2";
            ConexionBaseDeDatos.ConexionConfig.Database = "TestA";
        }
    }
}
