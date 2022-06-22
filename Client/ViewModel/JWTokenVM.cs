using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public class JWTokenVM
    {
        public int statusCode { set; get; }
        public string idToken { set; get; }
        public string message { set; get; }
    }
}
