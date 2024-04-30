using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.CommonServices
{
  
        public class ErrorResponse
        {
            public string apiVersion { get; set; }
            public Error error { get; set; }
        }

        public class Error
        {
            public int code { get; set; }
            public string message { get; set; }
            public List<Errors> errors { get; set; }
        }

        public class Errors
        {
            public string domain { get; set; }
            public string message { get; set; }
            public string reason { get; set; }

        }
    }
