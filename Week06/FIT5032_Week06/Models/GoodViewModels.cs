using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FIT5032_Week06.Models
{
    public class GoodViewModels
    {
    }

    public class GoodFormViewModel
    {
        [Required]
        [Display(Name = "Good Name")]
        public string GoodName { get; set; }
        public int GoodNumber { get; set; }
    }
}