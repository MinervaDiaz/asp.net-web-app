using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDAL
{
    public class DALIdiomas
    {
        //LISTAR 
        public static List<IdiomaVO> GetlistIdioma()
        {
            List<IdiomaVO> listaIdiomas = new List<IdiomaVO>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("sp_ListarIdiomas");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaIdiomas.Add(new IdiomaVO(dr));
                }
                return listaIdiomas;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        //INSERTAR 
        public static void InsertarIdioma(string nombre)
        {
            try
            {
                int result;
                result = MetodoDatos.ExecuteNonQuery("sp_InsertarIdioma",
                    "@nombre", nombre
                    );
            }
            catch (Exception)
            {
            }

        }
        //obtener por id
        public static IdiomaVO GetIdiomaById(int id_idioma)
        {
            try
            {
                DataSet dsIdioma = MetodoDatos.ExecuteDataSet("sp_ObtenerIdiomaPorID", "@id_idioma", id_idioma);
                if (dsIdioma.Tables[0].Rows.Count > 0)
                {
                    //aqui recuperamos
                    DataRow dr = dsIdioma.Tables[0].Rows[0];
                    //recuperar, se inializa con el constructor
                    return new IdiomaVO(dr);
                }
                else
                {
                    return new IdiomaVO();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR 
        public static void UpdateIdioma(int id_idioma, string nombre)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarIdioma",
                    "@id_idioma", id_idioma,
                    "@nombre", nombre
                    );
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ELIMINAR
        public static void DeleteIdioma(int id_idioma)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarIdioma",
                    "@id_idioma", id_idioma);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
