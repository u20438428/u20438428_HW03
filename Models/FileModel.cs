using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace u20438428_HW03.Models
{
    public class FileModel
    {
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "Please select file.")]
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] Files { get; set; }
    }
}