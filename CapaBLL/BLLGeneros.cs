using CapaDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace CapaBLL
{
    public class BLLGeneros
    {
        //LISTAR 
        public static List<GeneroVO> GetlistGenero()
        {
            List<GeneroVO> listResultado = new List<GeneroVO>();
            listResultado = DALGeneros.GetlistGenero();
            return listResultado;
        }

        //INSERTAR 
        public static void InsertarGenero(string nombre)
        {
            try
            {
                DALGeneros.InsertarGenero(nombre);
            }
            catch (Exception)
            {
            }
        }
        //OBTENER POR ID
        public static GeneroVO GetGeneroById(int id_genero)
        {
            return DALGeneros.GetGeneroById(id_genero);
        }

        //DELETE 
        public static void DeleteGenero(int id_genero)
        {
            try
            {
                GeneroVO Genero = DALGeneros.GetGeneroById(id_genero);
                DALGeneros.DeleteGenero(id_genero);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //ACTUALIZAR 
        public static void UpdateGenero(int id_genero, string nombre)
        {
            DALGeneros.UpdateGenero(id_genero, nombre);

        }
    }
}
