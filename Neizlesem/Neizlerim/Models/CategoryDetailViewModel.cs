using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim.Models
{
    public class CategoryDetailViewModel
    {
        public List<FilmDto> FilmDto { get; set; }
        public List<Category> Categories { get; set; }
    }
}
