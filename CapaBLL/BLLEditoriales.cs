using CapaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaBLL
{
    public class BLLEditoriales
    {
        //LISTAR EDITORIALES
        public static List<EditorialVO> GetlistEditorial()
        {
            List<EditorialVO> listResultado = new List<EditorialVO>();
            listResultado = DALEditoriales.GetlistEditorial();
            return listResultado;
        }

        //INSERTAR EDITORIAL
        public static void InsertarEditorial(string nombre, string ciudad, string telefono, string email, string url_foto)
        {
            try
            {
                DALEditoriales.InsertarEditorial(nombre, ciudad, telefono, email, url_foto);
            }
            catch (Exception)
            {

            }
        }
        //EDITORIAL POR ID
        public static EditorialVO GetEditorialById(int id_editorial)
        {
            return DALEditoriales.GetEditorialById(id_editorial);
        }

        //DELETE EDITORIAL
        public static void DeleteEditorial(int id_editorial)
        {
            try
            {
                EditorialVO Editorial = DALEditoriales.GetEditorialById(id_editorial);
                DALEditoriales.DeleteEditorial(id_editorial);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR EDITORIAL
        public static void UpdateEditorial(int id_editorial, string nombre, string ciudad, string telefono, string email, string _url_foto)
        {
            DALEditoriales.UpdateEditorial(id_editorial, nombre, ciudad, telefono, email, _url_foto);

        }
    }
}
