using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDAL
{
    public class DALEditoriales
    {

        //LISTAR EDITORIALES
        public static List<EditorialVO> GetlistEditorial()
        {
            List<EditorialVO> listaeditoriales = new List<EditorialVO>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("sp_ListarEditoriales");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaeditoriales.Add(new EditorialVO(dr));
                }
                return listaeditoriales;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        //INSERTAR
        public static void InsertarEditorial(string nombre, string ciudad, string telefono, string email, string url_foto)
        {
            try
            {
                int result;
                //se usa try catch porque la variable resultado está guardando la peticion y podría ha
                //voy a llamar a la clase de metodo datos
                //se puede pasar el array sin los [], visualmente se ve mejor
                result = MetodoDatos.ExecuteNonQuery("sp_InsertarEditorial",
                    "@nombre", nombre,                      
                    "@ciudad", ciudad,    
                    "@telefono", telefono,    
                    "@email", email,
                    "@url_foto", url_foto 
                    );
            }
            catch (Exception)
            {

            }

        }
        //EDITORIAL POR ID
        public static EditorialVO GetEditorialById(int id_editorial)
        {
            try
            {
                DataSet dsEditorial = MetodoDatos.ExecuteDataSet("sp_ObtenerEditorialPorID", "@id_editorial", id_editorial);
                if (dsEditorial.Tables[0].Rows.Count > 0)
                {
                    //aqui recuperamos
                    DataRow dr = dsEditorial.Tables[0].Rows[0];
                    //recuperar, se inializa con el constructor
                    return new EditorialVO(dr);
                }
                else
                {
                    return new EditorialVO();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR EDITORIAL
        public static void UpdateEditorial(int id_editorial, string nombre, string ciudad, string telefono, string email, string url_foto)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarEditorial",
                    "@id_editorial", id_editorial,
                    "@nombre", nombre,     
                    "@ciudad", ciudad,    
                    "@telefono", telefono,
                    "@email", email,     
                    "@url_foto", url_foto     
                    );
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ELIMINAR EDITORIAL
        public static void DeleteEditorial(int id_editorial)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarEditorial",
                    "@id_editorial", id_editorial);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
