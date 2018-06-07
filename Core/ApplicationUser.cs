using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiJwt.Core
{ 
    public class ApplicationUser : IdentityUser
    {
        [MinLength(5)]
        [MaxLength(100)]
        [Required]
        public string FullName { get; set; }
    }
}
