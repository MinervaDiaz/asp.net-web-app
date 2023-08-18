using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class AutorVO
    {
        private int _id_autor;
        private string _nombre;
        private string _apellido_paterno;
        private string _apellido_materno;
        private int _pais_id;
        private string _url_foto;

        public int id_autor { get => _id_autor; set => _id_autor = value; }
        public string nombre { get => _nombre; set => _nombre = value; }
        public string apellido_paterno { get => _apellido_paterno; set => _apellido_paterno = value; }
        public string apellido_materno { get => _apellido_materno; set => _apellido_materno = value; }
        public int pais_id { get => _pais_id; set => _pais_id = value; }
        public string url_foto { get => _url_foto; set => _url_foto = value; }

        public AutorVO()
        {
            //CONSTRUCTOR BASICO PARA DAR VALORES MINIMOS, QUE NO ESTÉN VACÍOS
            id_autor = 0;
            nombre = String.Empty;
            apellido_paterno = String.Empty;
            apellido_materno = String.Empty;
            pais_id = 0;
            url_foto = String.Empty;
        }

        public AutorVO(DataRow dr)
        //este constructor es para cuando manejemos una rejilla en la capa de construccion
        {
            id_autor = int.Parse(dr["id_autor"].ToString());
            nombre = dr["nombre"].ToString();
            apellido_paterno = dr["apellido_paterno"].ToString();
            apellido_materno = dr["apellido_materno"].ToString();
            pais_id = int.Parse(dr["pais_id"].ToString());
            url_foto = dr["url_foto"].ToString();
        }

    }
}
