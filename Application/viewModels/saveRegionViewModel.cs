using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.viewModels
{
    public class saveRegionViewModel
    {
        [Required(ErrorMessage = "Debe colocar el nombre de la region")]
        public String Name { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe colocar una descripcion de la region")]
        public String Description { get; set; }
    }
}
