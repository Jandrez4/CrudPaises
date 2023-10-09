using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDAD
{
    public class PaisE
    {
        [Key]
        public int Id_Pais { get; set; }

        [Required, Display(Name = "Nombre pais")]
        public string Nombre { get; set; }
    }
}
