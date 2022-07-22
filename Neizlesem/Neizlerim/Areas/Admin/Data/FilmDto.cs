using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Entity.POCO;

namespace Neizlerim.Areas.Admin.Data
{
    public class FilmDto
    {
        [Required(ErrorMessage ="Film Adı Zorunludur!")]
        [Display(Name = "Film Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Film Puanı Zorunludur!")]
        [Display(Name = "Film Puanı")]
        public int Puan { get; set; }
        [Required(ErrorMessage = "Film Yapım Yılı Zorunludur!")]
        [Display(Name = "Film Yapım Yılı")]
        public int YapimYili { get; set; }
        [Display(Name = "Ürün Resimlerini Yükle")]
        public List<IFormFile> Images { get; set; }
        public int[] Categories { get; set; }




    }
}
