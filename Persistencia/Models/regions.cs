using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Models
{
    public  class regions
    {
        public String Name { get; set; }
        public int Id { get; set; }
        public String Description { get; set; }
        public ICollection<Pokemons> Pokemons { get; set; }
    }
}
