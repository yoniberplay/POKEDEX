using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.viewModels
{
    public class saveTipoViewModel
    {

        [Required(ErrorMessage = "Debe colocar el nombre")]
        public String Name { get; set; }
        [Required(ErrorMessage = "**")]
        public int Id { get; set; }
       
    }
}
