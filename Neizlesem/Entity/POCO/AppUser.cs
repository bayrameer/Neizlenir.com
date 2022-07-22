using Core.Entity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entity.POCO
{
    public class AppUser: IdentityUser<int>
    {
        public string Adress { get; set; }
    }
}
