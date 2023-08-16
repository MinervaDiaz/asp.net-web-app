using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDAL
{
    public class DALGeneros
    {
        //LISTAR 
        public static List<GeneroVO> GetlistGenero()
        {
            List<GeneroVO> listaGeneros = new List<GeneroVO>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("sp_ListarGeneros");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaGeneros.Add(new GeneroVO(dr));
                }
                return listaGeneros;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        //INSERTAR 
        public static void InsertarGenero(string nombre)
        {
            try
            {
                int result;
                result = MetodoDatos.ExecuteNonQuery("sp_InsertarGeneros",
                    "@nombre", nombre
                    );
            }
            catch (Exception)
            {
            }

        }
        //obtener por id
        public static GeneroVO GetGeneroById(int id_genero)
        {
            try
            {
                DataSet dsGenero = MetodoDatos.ExecuteDataSet("sp_ObtenerGeneroPorID", "@id_genero", id_genero);
                if (dsGenero.Tables[0].Rows.Count > 0)
                {
                    //aqui recuperamos
                    DataRow dr = dsGenero.Tables[0].Rows[0];
                    //recuperar, se inializa con el constructor
                    return new GeneroVO(dr);
                }
                else
                {
                    return new GeneroVO();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR 
        public static void UpdateGenero(int id_genero, string nombre)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarGeneros",
                    "@id_genero", id_genero,
                    "@nombre", nombre
                    );
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ELIMINAR
        public static void DeleteGenero(int id_genero)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarGenero",
                    "@id_genero", id_genero);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
