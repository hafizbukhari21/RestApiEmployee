using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.VIewFormatter
{
    public class ResponseFormatter
    {
        public string status { set; get; }
        public Message message { set; get; }
        public IEnumerable<Employee> payload { set; get; }
    }


    public class Message
    {
        public DateTime time { set; get; }
        public string author { set; get; }

        public string ver { set; get; }

    }
}
