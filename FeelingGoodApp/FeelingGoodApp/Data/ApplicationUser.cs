using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FeelingGoodApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
