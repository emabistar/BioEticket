using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace bioticket.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
