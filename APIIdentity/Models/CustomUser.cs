using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APIIdentity.Models
{
    public class CustomUser : IdentityUser
    {
        [Required, Display(Name = "Fullname"), StringLength(75)]
        public string Fullname { get; set; }
    }
}
