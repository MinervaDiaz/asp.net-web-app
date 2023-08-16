using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class PaisVO
    {
        private int _id_pais;
        private string _nombre;

        public int id_pais { get => _id_pais; set => _id_pais = value; }
        public string nombre { get => _nombre; set => _nombre = value; }

        public PaisVO() {
            id_pais= 0;
            string nombre = String.Empty;
        }
        public PaisVO(DataRow dr)
        {
            id_pais = int.Parse(dr["id_pais"].ToString());
            nombre = dr["nombre"].ToString();
        }
    }
}
