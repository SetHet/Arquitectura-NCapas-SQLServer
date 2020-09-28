using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using ModeloDeDatos;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            NegocioConexion.SetUp();

            NegocioUsuario nUser = new NegocioUsuario();

            //nUser.AddUser("Kevin");
            int index = 0;
            while (true)
            {
                Usuario user = nUser.GetUser(index++);

                if (user != null)
                {
                    Console.WriteLine(user.ToString());
                }
                else
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
