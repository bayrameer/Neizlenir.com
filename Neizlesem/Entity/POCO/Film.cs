using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class Film : BaseEntity
    {
        
        public string Name { get; set; }

        public int Puan { get; set; }

        public int YapimYili { get; set; }
        public int YonetmenId { get; set; }
        public int FilmDetayId { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<FilmImage> FilmImages { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
        




    }
}
