using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.viewModels
{
    public class SavePokeViewModel
    {

        [Required(ErrorMessage = "Debe colocar el nombre del pokemon")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Debe colocar la Description")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Debe colocar url del la imagen")]
        public String ImgUrl { get; set; }

        [Required(ErrorMessage = "**")]
        public int PrimaryType { get; set; }

        public int SecondaryType { get; set; }

        [Required(ErrorMessage = "**")]
        public int RegionId { get; set; }
        public int Id { get; set; }


    }
}
