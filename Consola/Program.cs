﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConexionBaseDeDatos;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConexionSQLServer().ConsoleTest();
        }
    }
}
