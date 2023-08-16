using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaDAL
{
    public class DALPaises
    {
        //LISTAR 
        public static List<PaisVO> GetlistPais()
        {
            List<PaisVO> listaPaises = new List<PaisVO>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("sp_ListarPaises");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    listaPaises.Add(new PaisVO(dr));
                }
                return listaPaises;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        //INSERTAR 
        public static void InsertarPais(string nombre)
        {
            try
            {
                int result;
                result = MetodoDatos.ExecuteNonQuery("sp_InsertarPais",
                    "@nombre", nombre
                    );
            }
            catch (Exception)
            {
            }

        }
        //obtener por id
        public static PaisVO GetPaisById(int id_pais)
        {
            try
            {
                DataSet dsPais = MetodoDatos.ExecuteDataSet("sp_ObtenerPaisPorID", "@id_pais", id_pais);
                if (dsPais.Tables[0].Rows.Count > 0)
                {
                    //aqui recuperamos
                    DataRow dr = dsPais.Tables[0].Rows[0];
                    //recuperar, se inializa con el constructor
                    return new PaisVO(dr);
                }
                else
                {
                    return new PaisVO();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR 
        public static void UpdatePais(int id_pais, string nombre)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_ActualizarPaises",
                    "@id_pais", id_pais,
                    "@nombre", nombre
                    );
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ELIMINAR
        public static void DeletePais(int id_pais)
        {
            try
            {
                MetodoDatos.ExecuteNonQuery("sp_EliminarPais",
                    "@id_pais", id_pais);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
