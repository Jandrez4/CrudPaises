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
    public class GiroD
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();


        public List<GiroE> ListadoGiros()
        {
            List<GiroE> listadoGiro = new List<GiroE>();
            try
            {
                conn.Open();
                cmd = new SqlCommand("spListar_Giros", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    GiroE giroE = new GiroE();
                    giroE.Id_Giro = Convert.ToInt32(dr["ID"]);
                    giroE.Giro_Recibido = dr["DESCRIPCION GIRO"].ToString();
                    giroE.ciudadE.Nombre = dr["CIUDAD"].ToString();


                    listadoGiro.Add(giroE);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listadoGiro;
        }

       

         public bool CrearGiro(GiroE giroE)
         {
             bool respuesta = false;
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spAgregar_Giro", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pDesGiro = new SqlParameter();
                 pDesGiro.ParameterName = "@giro";
                 pDesGiro.SqlDbType = SqlDbType.VarChar;
                 pDesGiro.Size = 20;
                 pDesGiro.Value = giroE.Giro_Recibido;

                 SqlParameter pId_Ciudad = new SqlParameter();
                 pId_Ciudad.ParameterName = "@id_ciudad";
                 pId_Ciudad.SqlDbType = SqlDbType.Int;
                 pId_Ciudad.Value = giroE.ciudadE.Id_Ciudad;

                 cmd.Parameters.Add(pDesGiro);
                 cmd.Parameters.Add(pId_Ciudad);


                 cmd.ExecuteNonQuery();

                 respuesta = true;

             }
             catch(Exception)
             {
                throw;
             }


             return respuesta;
         }

         public GiroE BuscarGiroId(int IdGiro)
         {
             GiroE giroE = new GiroE();
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spBuscar_Giro_Id", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pGiroId = new SqlParameter();
                 pGiroId.ParameterName = "@id_giro";
                 pGiroId.SqlDbType = SqlDbType.Int;
                 pGiroId.Value = IdGiro;

                 cmd.Parameters.Add(pGiroId);

                 SqlDataReader dr = cmd.ExecuteReader();
                 dr.Read();

                 if (dr.HasRows)
                 {
                     giroE.Id_Giro = Convert.ToInt32(dr["ID"]);
                     giroE.Giro_Recibido = dr["DESCRIPCION"].ToString();
                     giroE.ciudadE.Id_Ciudad = Convert.ToInt32(dr["CIUDAD"]);

                 }
             }
             catch (Exception)
             {
                 throw;
             }


             return giroE;
         }

         public bool ActualizarGiro(GiroE giroE)
         {
             bool actualizar = false;
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spActualizar_Giro", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pGiroId = new SqlParameter();
                 pGiroId.ParameterName = "@id_giro";
                 pGiroId.SqlDbType = SqlDbType.Int;
                 pGiroId.Value = giroE.Id_Giro;

                 SqlParameter pNombre = new SqlParameter();
                 pNombre.ParameterName = "@giro";
                 pNombre.SqlDbType = SqlDbType.VarChar;
                 pNombre.Size = 30;
                 pNombre.Value = giroE.Giro_Recibido;

                 SqlParameter pCiudadId = new SqlParameter();
                 pCiudadId.ParameterName = "@id_ciudad";
                 pCiudadId.SqlDbType = SqlDbType.Int;
                 pCiudadId.Value = giroE.ciudadE.Id_Ciudad;

                 cmd.Parameters.Add(pGiroId);
                 cmd.Parameters.Add(pNombre);
                 cmd.Parameters.Add(pCiudadId);

                 cmd.ExecuteNonQuery();

                 actualizar = true;
             }
             catch (Exception)
             {
                throw;
             }

             return actualizar;



         }

         public bool EliminarPais(int idGiro)
         {
             bool eliminado = false;
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spEliminar_Giro", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pIdGiro = new SqlParameter();
                 pIdGiro.ParameterName = "@id_giro";
                 pIdGiro.SqlDbType = SqlDbType.Int;
                 pIdGiro.Value = idGiro;

                 cmd.Parameters.Add(pIdGiro);

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
