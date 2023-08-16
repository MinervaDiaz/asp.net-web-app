using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    internal class Configuracion
    {
        static string cadenaConexion = @"Data Source = LB\SQLEXPRESS; Initial Catalog=Libros; Integrated Security=True";
        public static string CadenaConexion
        {
            get
            {
                return cadenaConexion;
            }
        }
    }
}
