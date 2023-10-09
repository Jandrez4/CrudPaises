using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DATA
{
    public class PaisD
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<PaisE> ListadoPaises()
        {
            List<PaisE> listado = new List<PaisE>();

            try
            {
                conn.Open();
                cmd = new SqlCommand("spPais_Listado", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    PaisE paisE = new PaisE();
                    paisE.Id_Pais = Convert.ToInt32(dr["ID"]);
                    paisE.Nombre = dr["Nombre pais"].ToString();

                    listado.Add(paisE);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return listado;
        }


        public List<PaisE> DropdwonPaises(string obtener)
        {
            List<PaisE> listadoPais = new List<PaisE>();
            try
            {
                conn.Open();
                cmd = new SqlCommand("spDrop_Lista", conn);
                cmd.Parameters.AddWithValue("obtener", obtener);
                cmd.CommandType = CommandType.StoredProcedure;

                
                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        listadoPais.Add(new PaisE
                        {
                            Id_Pais = Convert.ToInt32(dr["ID"]),
                            Nombre = dr["Nombre"].ToString(),

                        });
                        /*GiroE giroE = new GiroE();
                        giroE.Id_Giro = Convert.ToInt32(dr["ID"]);
                        giroE.Giro_Recibido = dr["DESCRIPCION GIRO"].ToString();
                        giroE.ciudadE.Nombre = dr["CIUDAD"].ToString();*/


                        //listadoGiro.Add(giroE);
                    }
                }
                
            }
            catch (Exception)
            {
                throw;
            }

            return listadoPais;
        }

        public bool CrearPais (PaisE paisE)
        {
            bool respuesta = false;
            try
            {
                conn.Open();
                cmd = new SqlCommand("spPaises_Crear", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pNombre = new SqlParameter();
                pNombre.ParameterName = "@Nombre";
                pNombre.SqlDbType = SqlDbType.VarChar;
                pNombre.Size = 20;
                pNombre.Value = paisE.Nombre;

                cmd.Parameters.Add(pNombre);

                cmd.ExecuteNonQuery();

                respuesta = true; 
            }
            catch(Exception ex)
            {

            }

            return respuesta;
        }


        public PaisE BuscarPaisId(int IdPais)
        {
            PaisE paisE = new PaisE();
            try
            {
                conn.Open();
                cmd = new SqlCommand("spPais_BuscarId", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pPaisId = new SqlParameter();
                pPaisId.ParameterName = "@Id_Pais";
                pPaisId.SqlDbType = SqlDbType.Int;
                pPaisId.Value = IdPais;

                cmd.Parameters.Add(pPaisId);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                if(dr.HasRows)
                {
                    paisE.Id_Pais = Convert.ToInt32(dr["ID"]);
                    paisE.Nombre = dr["Nombre"].ToString();

                }
            }
            catch(Exception ex)
            {
                throw;
            }


            return paisE;
        }


        public bool ActualizarPais(PaisE paisE)
        {
            bool respuesta = false;
            try
            {
                conn.Open();
                cmd = new SqlCommand("spPais_Actualizar", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pPaisId = new SqlParameter();
                pPaisId.ParameterName = "@Id_Pais";
                pPaisId.SqlDbType = SqlDbType.Int;
                pPaisId.Value = paisE.Id_Pais;

                SqlParameter pNombre = new SqlParameter();
                pNombre.ParameterName = "@Nombre";
                pNombre.SqlDbType = SqlDbType.VarChar;
                pNombre.Size = 20;
                pNombre.Value = paisE.Nombre;

                cmd.Parameters.Add(pPaisId);
                cmd.Parameters.Add(pNombre);

                cmd.ExecuteNonQuery();

                respuesta = true;
            }
            catch (Exception)
            {

            }

            return respuesta;
        }

        public bool EliminarPais(int idPais)
        {
            bool eliminado = false;
            try
            {
                conn.Open();
                cmd = new SqlCommand("spPais_Eliminar", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pIdPais = new SqlParameter();
                pIdPais.ParameterName = "@Id_Pais";
                pIdPais.SqlDbType = SqlDbType.Int;
                pIdPais.Value = idPais;

                cmd.Parameters.Add(pIdPais);

                 cmd.ExecuteNonQuery();

                eliminado = true;
            }
            catch
            {
                throw;
            }

            return eliminado;
        }
    
    }
}
