using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DATA;
using ENTIDAD;

namespace LOGICA
{
    public class CiudadL
    {
        CiudadDATA ciudadData = new CiudadDATA();

        public List<CiudadE> ListadoCiudad()
        {
            return ciudadData.ListadoCiudad();
        }

        public List<CiudadE> DropCiudad(string obtener, int i_pais)
        {
            return ciudadData.DropCiudad(obtener, i_pais);
        }

        public bool CrearCiudad(CiudadE ciudadE)
        {
            return ciudadData.CrearCiudad(ciudadE);
        }

        public CiudadE BuscarCiudadId(int IdCiudad)
        {
            return ciudadData.BuscarCiudadId(IdCiudad);
        }

        public bool ActualizarCiudad(CiudadE ciudadE)
        {
            return ciudadData.ActualizarCiudad(ciudadE);
        }

        public bool EliminarCiudad(int idCiudad)
        {
            return ciudadData.EliminarCiudad(idCiudad);
        }
    }
}
