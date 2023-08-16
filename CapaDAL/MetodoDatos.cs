using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDAL
{
    internal class MetodoDatos
    {
        public static DataSet ExecuteDataSet(string sp, params object[] parametros)
        {
            DataSet ds = new DataSet();
            string cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection con = new SqlConnection(cadenaConexion);
            try
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;
                    if(parametros != null && parametros.Length %2 != 0)
                    {
                        throw new Exception("Los parametros deben estar en pares (Clave: valor)");
                    }
                    else
                    {
                        for(int i=0; i < parametros.Length; i = i + 2)
                        {
                            cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                        }
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        con.Close();
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public static int ExecuteScalar(string sp, params object[] parametros)
        {
            int id = 0;
            string cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection con = new SqlConnection(cadenaConexion);
            try
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;
                    for(int i = 0; i< parametros.Length; i = i + 2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }
                    con.Open();
                    id = int.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
                return id;
            }
            catch(Exception ex)
            {
                return id;
            }
            finally
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
        public static int ExecuteNonQuery(string sp, params object[] parametros)
        {
            int IdOrigenDestino = 0;
            string cadenaConexion = Configuracion.CadenaConexion;
            SqlConnection con = new SqlConnection(cadenaConexion);
            try
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sp;
                    for(int i= 0; i< parametros.Length; i=i+2)
                    {
                        cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                    IdOrigenDestino = 1;
                    con.Close();
               }
                return IdOrigenDestino = 1;
            }
            catch(Exception ex)
            {
                return IdOrigenDestino = 1;
            }
            finally
            {
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
