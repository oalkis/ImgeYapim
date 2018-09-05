using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ImgeYapim.Models
{
    public class User: IdentityUser
    {
        [NotMapped] // Does not effect with your database
        [Required]
        public string Password { get; set; }

        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}