using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDAL
{
    public class DALAutores
    {
        //LISTAR EDITORIALES
        public static List<AutorVO> GetlistAutores()
        {
            List<AutorVO> listaautores = new List<AutorVO>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("sp_ListarAutores");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaautores.Add(new AutorVO(dr));
                }
                return listaautores;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        //INSERTAR
        public static void InsertarAutores(string nombre, string apellido_paterno, string apellido_materno, int pais_id, string url_foto)
        {
            try
            {
                int result;
                //se usa try catch porque la variable resultado está guardando la peticion y podría ha
                //voy a llamar a la clase de metodo datos
                //se puede pasar el array sin los [], visualmente se ve mejor
                result = MetodoDatos.ExecuteNonQuery("sp_InsertarAutores",
                    "@nombre", nombre,
                    "@apellido_paterno", apellido_paterno,
                    "@apellido_materno", apellido_materno,
                    "@pais_id", pais_id,
                    "@url_foto", url_foto
                    );
            }
            catch (Exception)
            {

            }

        }
        //EDITORIAL POR ID
        public static AutorVO GetAutorById(int id_autor)
        {
            try
            {
                DataSet dsAutor = MetodoDatos.ExecuteDataSet("sp_ObtenerAutorPorID", "@id_autor", id_autor);
                if (dsAutor.Tables[0].Rows.Count > 0)
                {
                    //aqui recuperamos
                    DataRow dr = dsAutor.Tables[0].Rows[0];
                    //recuperar, se inializa con el constructor
                    return new AutorVO(dr);
                }
                else
                {
                    return new AutorVO();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR EDITORIAL
        public static void UpdateAutor(int id_autor,string nombre, string apellido_paterno, string apellido_materno, int pais_id, string url_foto)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarAutores",
                    "@id_autor", id_autor,
                    "@nombre", nombre,
                    "@apellido_paterno", apellido_paterno,
                    "@apellido_materno", apellido_materno,
                    "@pais_id", pais_id,
                    "@url_foto", url_foto
                    );
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ELIMINAR EDITORIAL
        public static void DeleteAutor(int id_autor)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarAutor",
                    "@id_autor", id_autor);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
