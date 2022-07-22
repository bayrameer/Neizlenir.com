using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neizlerim.CustomValidation
{
    public class ErrorİDiscriberAccount : IdentityErrorDescriber
    {
        public override IdentityError InvalidEmail(string email)
        {
            IdentityError identityError
                  = new IdentityError();

            identityError.Description = "Lütfen Geçerli bir email adresi yazınız!";
            identityError.Code = "EmailDeyerli";
            return identityError;
          
        }
    }
}
