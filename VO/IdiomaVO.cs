using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class IdiomaVO
    {
        private int _id_idioma;
        private string _nombre;

        public int id_idioma { get => _id_idioma; set => _id_idioma = value; }
        public string nombre { get => _nombre; set => _nombre = value; }

        public IdiomaVO()
        {
            id_idioma = 0;
            nombre = String.Empty;
        }
        public IdiomaVO(DataRow dr)
        {
            id_idioma = int.Parse(dr["id_idioma"].ToString());
            nombre = dr["nombre"].ToString();
        }
    }
}
