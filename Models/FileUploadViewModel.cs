using Microsoft.AspNetCore.Http;

namespace AspNetCore_FileUpload.Models
{
    public class FileUploadViewModel
    {
         public IFormFile Files { get; set; }
    }
}