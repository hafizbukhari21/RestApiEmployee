﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{

    public class Variable
    {
        

        //production status
        public static bool isProduction = false;

        //message Api
        public static Object messageObj = new {
            time = DateTime.Now,
            author = "Hafiz Bukhari",
            Ver = "v1",
            //isProduction  
        };

        public const float EMAIL_NOT_FOUND = -1;
        public const float PASSWORD_NOT_FOUND = -2;



    }


}
