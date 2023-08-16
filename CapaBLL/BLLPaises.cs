using CapaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaBLL
{
    public class BLLPaises
    {
        //LISTAR 
        public static List<PaisVO> GetlistPais()
        {
            List<PaisVO> listResultado = new List<PaisVO>();
            listResultado = DALPaises.GetlistPais();
            return listResultado;
        }

        //INSERTAR 
        public static void InsertarPais(string nombre)
        {
            try
            {
                DALPaises.InsertarPais(nombre);
            }
            catch (Exception)
            {
            }
        }
        //OBTENER POR ID
        public static PaisVO GetPaisById(int id_pais)
        {
            return DALPaises.GetPaisById(id_pais);
        }

        //DELETE 
        public static void DeletePais(int id_pais)
        {
            try
            {
                PaisVO Pais = DALPaises.GetPaisById(id_pais);
                DALPaises.DeletePais(id_pais);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR 
        public static void UpdatePais(int id_pais, string nombre)
        {
            DALPaises.UpdatePais(id_pais, nombre);

        }
    }
}
