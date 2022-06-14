using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ResponseFormatter : Controller
    {
        private static Object messageObj = Variable.messageObj;
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ResponseFormater(int statusCodeSuccess, int statusCodeFail, string statusSuccess, string statusFailed, int f)
        {
          
            return f > 0 ?
                 StatusCode(statusCodeSuccess, new { Status = statusSuccess, Message = messageObj }) :
                 StatusCode(statusCodeFail, new { Status = statusFailed, Message = messageObj });
             
        }

        public ActionResult ResponseFormater(int statusCodeSuccess, int statusCodeFail, string statusSuccess, string statusFailed, Object payload)
        {
          return payload != null ?
                 StatusCode(statusCodeSuccess, new { Status = statusSuccess, Message = messageObj, Payload = payload }) :
                 StatusCode(statusCodeFail, new { Status = statusFailed, Message = messageObj });
           
        }

        public ActionResult ResponseError(int statuscode, string message,Object stacktrace, bool IsProduction)
        {
          return  IsProduction ? 
                 StatusCode(statuscode, new { Status = "TerjadiKesalahan pada sistem atau - " + message, Message = messageObj }):
                 StatusCode(500, new { stacktrace = stacktrace});
        }

      
    }
}
