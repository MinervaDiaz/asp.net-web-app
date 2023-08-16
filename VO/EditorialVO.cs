using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VO
{
    public class EditorialVO
    {
        private int _id_editorial;
        private string _nombre;
        private string _ciudad;
        private string _telefono;
        private string _email;
        private string _url_foto;

        public int id_editorial { get => _id_editorial; set => _id_editorial = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string ciudad { get => _ciudad; set => _ciudad = value; }
        public string telefono { get => _telefono; set => _telefono = value; }
        public string email { get => _email; set => _email = value; }
        public string url_foto { get => _url_foto; set => _url_foto = value; }

        public EditorialVO()
        {
            //CONSTRUCTOR BASICO PARA DAR VALORES MINIMOS, QUE NO ESTÉN VACÍOS
            id_editorial = 0;
            nombre = String.Empty;
            ciudad = String.Empty;
            telefono = String.Empty;
            email = String.Empty;
            url_foto = String.Empty;
        }
        public EditorialVO(DataRow dr)
        //este constructor es para cuando manejemos una rejilla en la capa de construccion
        {
            id_editorial = int.Parse(dr["id_editorial"].ToString());
            nombre = dr["nombre"].ToString();
            ciudad = dr["ciudad"].ToString();
            telefono = dr["telefono"].ToString();
            email = dr["email"].ToString();
            url_foto = dr["url_foto"].ToString();
        }
    }
}

