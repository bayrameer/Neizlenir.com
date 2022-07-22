using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class FilmImage : BaseEntity
    {
        public string Url { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
    }
}
