using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class CreateGenericResponseDto
    {
        public int ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class DeleteGenericResponseDto
    {
        public int ID { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}