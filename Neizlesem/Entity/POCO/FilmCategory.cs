using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
   public  class FilmCategory : IBaseEntity
    {
        public int FilmId { get; set; }
        public int CategoryId { get; set; }
        public virtual Film Film { get; set; }
        public virtual FilmImage FilmImage{ get; set; }
        public virtual Category Category  { get; set; }
    }
}
