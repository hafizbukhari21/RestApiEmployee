using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class ForgotPasswordValidateVM
    {
        public string email { set; get; }
        public string otp { set; get; }
        public string newPassword { set; get; }
        public string validate_newPassword { set; get; }

    }
}
