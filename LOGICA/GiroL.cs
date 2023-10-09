using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using DATA;

namespace LOGICA
{
    public class GiroL
    {
        GiroD giroD = new GiroD();

        public List<GiroE> ListadoGiros()
        {
            return giroD.ListadoGiros();
        }

        public bool CrearGiro(GiroE giroE)
        {
            return giroD.CrearGiro(giroE);
        }

        public GiroE BuscarGiroId(int IdGiro)
        {
            return giroD.BuscarGiroId(IdGiro);
        }

        public bool ActualizarGiro(GiroE giroE)
        {
            return giroD.ActualizarGiro(giroE);
        }

        public bool EliminarGiro(int idGiro)
        {
            return giroD.EliminarPais(idGiro);
        }
    }
}
