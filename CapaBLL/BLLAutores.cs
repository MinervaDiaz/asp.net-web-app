using CapaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaBLL
{
    public class BLLAutores
    {
        //LISTAR EDITORIALES
        public static List<AutorVO> GetlistAutores()
        {
            List<AutorVO> listResultado = new List<AutorVO>();
            listResultado = DALAutores.GetlistAutores();
            return listResultado;
        }

        //INSERTAR AUTOR
        public static void InsertarAutores(string nombre, string apellido_paterno, string apellido_materno, int pais_id, string url_foto)
        {
            try
            {
                DALAutores.InsertarAutores(nombre, apellido_paterno, apellido_materno, pais_id, url_foto);
            }
            catch (Exception)
            {

            }
        }
        //EDITORIAL POR ID
        public static AutorVO GetAutorById(int id_autor)
        {
            return DALAutores.GetAutorById(id_autor);
        }

        //DELETE EDITORIAL
        public static void DeleteAutor(int id_autor)
        {
            try
            {
                AutorVO Autor = DALAutores.GetAutorById(id_autor);
                DALAutores.DeleteAutor(id_autor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR EDITORIAL
        public static void UpdateAutor(int id_autor, string nombre, string apellido_paterno, string apellido_materno, int pais_id, string _url_foto)
        {
            DALAutores.UpdateAutor(id_autor, nombre, apellido_paterno, apellido_materno, pais_id, _url_foto);

        }
    }
}
