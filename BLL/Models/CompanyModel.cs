using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLL.Models
{
    public class CompanyModel
    {
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Company Size")]
        public int CompanySize { get; set; }

        [Required]
        [Display(Name = "Organizational Legal Form")]
        public string OrganizationalLegalForm { get; set; }
    }
}