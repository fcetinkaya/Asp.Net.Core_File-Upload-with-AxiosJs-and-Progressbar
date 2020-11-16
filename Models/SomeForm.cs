using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_FileUpload.Models
{
    public class SomeForm
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
