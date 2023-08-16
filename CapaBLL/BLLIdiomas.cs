using CapaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaBLL
{
    public class BLLIdiomas
    {
        //LISTAR 
        public static List<IdiomaVO> GetlistIdioma()
        {
            List<IdiomaVO> listResultado = new List<IdiomaVO>();
            listResultado = DALIdiomas.GetlistIdioma();
            return listResultado;
        }

        //INSERTAR 
        public static void InsertarIdioma(string nombre)
        {
            try
            {
                DALIdiomas.InsertarIdioma(nombre);
            }
            catch (Exception)
            {
            }
        }
        //OBTENER POR ID
        public static IdiomaVO GetIdiomaById(int id_idioma)
        {
            return DALIdiomas.GetIdiomaById(id_idioma);
        }

        //DELETE 
        public static void DeleteIdioma(int id_idioma)
        {
            try
            {
                IdiomaVO Idioma = DALIdiomas.GetIdiomaById(id_idioma);
                DALIdiomas.DeleteIdioma(id_idioma);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR 
        public static void UpdateIdioma(int id_idioma, string nombre)
        {
            DALIdiomas.UpdateIdioma(id_idioma, nombre);

        }
    }
}
