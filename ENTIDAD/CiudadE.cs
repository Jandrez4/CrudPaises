using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class CiudadE
    {
        [Key]
        public int Id_Ciudad { get; set; }

        [Required, Display(Name = "Nombre Ciudad")]
        public string Nombre { get; set; }

        [Required, Display(Name = "Pais")]
        public PaisE paisE = new PaisE();
    }
}
