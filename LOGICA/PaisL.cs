using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ENTIDAD;
using DATA;

namespace LOGICA
{
    public class PaisL
    {
        PaisD paisD = new PaisD();

        public List<PaisE> ListadoPaises()
        {
            return paisD.ListadoPaises();
        }

        public List<PaisE> DropdownPaises(string obtener)
        {
            return paisD.DropdwonPaises(obtener);
        }

        public bool CrearPais(PaisE paisE)
        {
            return paisD.CrearPais(paisE);
        }

        public PaisE BuscarPaisId(int IdPais)
        {
            return paisD.BuscarPaisId(IdPais);
        }

        public bool ActualizarPais(PaisE paisE)
        {
            return paisD.ActualizarPais(paisE);
        }

        public bool EliminarPais(int idPais)
        {
            return paisD.EliminarPais(idPais);
        }
    }
}
