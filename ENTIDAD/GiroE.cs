using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class GiroE
    {
        [Key]
        public int Id_Giro { get; set; }

        [Required, Display(Name = "Descripcion del giro")]
        public string Giro_Recibido { get; set; }

        [Required, Display(Name = "Ciduad")]
        public CiudadE ciudadE = new CiudadE();
    }
}
