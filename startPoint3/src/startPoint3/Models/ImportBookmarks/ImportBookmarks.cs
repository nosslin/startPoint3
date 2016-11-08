using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace startPoint3.Models.ImportBookmarks
{
    public class ImportBookmarks
    {
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Bucket { get; set; }
        [Required]
        public IFormFile NetscapeBookmarkFile { get; set; }
    }
}
