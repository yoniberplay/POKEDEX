using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.viewModels
{
    public class PokeviewModel
    {

        public String Name { get; set; }
        public String Description { get; set; }
        public String ImgUrl { get; set; }
        public int PrimaryType { get; set; }
        public int SecondaryType { get; set; }
        public int RegionId { get; set; }
        public int Id { get; set; }

    }
}
