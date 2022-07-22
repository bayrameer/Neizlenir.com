using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu Alan!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email  Zorunlu Alan!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre Zorunlu Alan!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar Zorunlu Alan!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
