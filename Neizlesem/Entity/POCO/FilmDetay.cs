using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.POCO
{
    public class FilmDetay: BaseEntity
    {
        public string FilminKonusu { get; set; }
        public string BasrolOyuncu { get; set; }
        public string Platform { get; set; }
    }
}
