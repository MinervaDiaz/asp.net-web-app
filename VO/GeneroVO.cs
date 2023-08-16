using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class GeneroVO
    {
        private int _id_genero;
        private string _nombre;

        public int id_genero { get => _id_genero; set => _id_genero = value; }
        public string nombre { get => _nombre; set => _nombre = value; }

        public GeneroVO()
        {
            id_genero = 0;
            nombre = String.Empty;
        }
        public GeneroVO(DataRow dr)
        {
            id_genero = int.Parse(dr["id_genero"].ToString());
            nombre = dr["nombre"].ToString();
        }
    }
}
