using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTO
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Puan { get; set; }

        public int YapimYili { get; set; }
        public int YonetmenId { get; set; }
        public int FilmDetayId { get; set; }
        public string Images { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<object> Category { get; set; }
        public IEnumerable<object> Categories { get; set; }
    }
}
