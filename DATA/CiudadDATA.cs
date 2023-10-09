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
    public class CiudadDATA
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd = new SqlCommand();

        public List<CiudadE> ListadoCiudad()
        {
            List<CiudadE> listado = new List<CiudadE>();
            try
            {
                conn.Open();
                cmd = new SqlCommand("spListar_Ciudad", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CiudadE ciudadE = new CiudadE();
                    ciudadE.Id_Ciudad = Convert.ToInt32(dr["ID"]);
                    ciudadE.Nombre = dr["NOMBRE"].ToString();
                    ciudadE.paisE.Nombre = dr["PAIS"].ToString();


                    listado.Add(ciudadE);
                }
            }
            catch (Exception)
            {

            }

            return listado;
        }


        public List<CiudadE> DropCiudad(string obtener, int i_pais)
        {
            List<CiudadE> listado = new List<CiudadE>();
            CiudadE ciudad = new CiudadE();


            conn.Open();
            cmd = new SqlCommand("spDrop_Ciudad", conn);
            cmd.Parameters.AddWithValue("obtener", obtener);
            cmd.Parameters.AddWithValue("i_pais", i_pais);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listado.Add(new CiudadE
                {
                    Id_Ciudad = Convert.ToInt32(dr["ID"]),
                    Nombre = dr["NOMBRE"].ToString(),
                });
               
            }


            return listado;
        }

        public bool CrearCiudad(CiudadE ciudadE)
         {
             bool creada = false;
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spAgregar_Ciudad", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pNombre = new SqlParameter();
                 pNombre.ParameterName = "@ciudad";
                 pNombre.SqlDbType = SqlDbType.VarChar;
                 pNombre.Size = 20;
                 pNombre.Value = ciudadE.Nombre;

                 SqlParameter pId_Pais = new SqlParameter();
                 pId_Pais.ParameterName = "@id_pais";
                 pId_Pais.SqlDbType = SqlDbType.Int;
                 pId_Pais.Value = ciudadE.paisE.Id_Pais;

                 cmd.Parameters.Add(pNombre);
                 cmd.Parameters.Add(pId_Pais);

                 cmd.ExecuteNonQuery();

                 creada = true;

             }
             catch (Exception)
             {

             }


             return creada;
         }

        public CiudadE BuscarCiudadId(int IdCiudad)
         {
             CiudadE ciudadE = new CiudadE();
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spBuscar_Ciudad_Id", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pCiudadId = new SqlParameter();
                 pCiudadId.ParameterName = "@id_ciudad";
                 pCiudadId.SqlDbType = SqlDbType.Int;
                 pCiudadId.Value = IdCiudad;

                 cmd.Parameters.Add(pCiudadId);

                 SqlDataReader dr = cmd.ExecuteReader();
                 dr.Read();

                 if (dr.HasRows)
                 {
                     ciudadE.Id_Ciudad = Convert.ToInt32(dr["ID"]);
                     ciudadE.Nombre = dr["NOMBRE"].ToString();
                     ciudadE.paisE.Id_Pais = Convert.ToInt32(dr["ID"]);

                 }
             }
             catch (Exception)
             {
                 throw;
             }


             return ciudadE;
         }

        public bool ActualizarCiudad(CiudadE ciudadE)
         {
             bool actualizar = false;
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spActualizar_Ciudad", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pCiudadId = new SqlParameter();
                 pCiudadId.ParameterName = "@id_ciudad";
                 pCiudadId.SqlDbType = SqlDbType.Int;
                 pCiudadId.Value = ciudadE.Id_Ciudad;

                 SqlParameter pNombre = new SqlParameter();
                 pNombre.ParameterName = "@nombre";
                 pNombre.SqlDbType = SqlDbType.VarChar;
                 pNombre.Size = 20;
                 pNombre.Value = ciudadE.Nombre;

                 SqlParameter pPaisId = new SqlParameter();
                 pPaisId.ParameterName = "@id_pais";
                 pPaisId.SqlDbType = SqlDbType.Int;
                 pPaisId.Value = ciudadE.paisE.Id_Pais;

                 cmd.Parameters.Add(pCiudadId);
                 cmd.Parameters.Add(pNombre);
                 cmd.Parameters.Add(pPaisId);

                 cmd.ExecuteNonQuery();

                 actualizar = true;
             }
             catch (Exception)
             {
                throw;
             }

             return actualizar;
         }

        public bool EliminarCiudad(int idCiudad)
         {
             bool eliminado = false;
             try
             {
                 conn.Open();
                 cmd = new SqlCommand("spEliminar_Ciudad", conn);
                 cmd.CommandType = CommandType.StoredProcedure;

                 SqlParameter pIdCiudad = new SqlParameter();
                 pIdCiudad.ParameterName = "@id_ciudad";
                 pIdCiudad.SqlDbType = SqlDbType.Int;
                 pIdCiudad.Value = idCiudad;

                 cmd.Parameters.Add(pIdCiudad);

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
