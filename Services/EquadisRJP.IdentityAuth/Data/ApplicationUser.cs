using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EquadisRJP.IdentityAuth.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(254)]
        public string? Name { get; set; }

    }
}
