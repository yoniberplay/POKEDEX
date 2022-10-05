using System;

namespace Persistencia.Models
{
    public class Pokemons
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImgUrl { get; set; }
        public int PrimaryType { get; set; }
        public int SecondaryType { get; set; }
        public int RegionId { get; set; }
        public int Id { get; set; }

        //navigation property
        public regions regions { get; set; }
        public tipos tipos { get; set; }

        public static explicit operator Pokemons(Task<Pokemons> v)
        {
            throw new NotImplementedException();
        }
    }
}
