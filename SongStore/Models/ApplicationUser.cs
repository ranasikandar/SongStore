using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Display(Name = "Last Name")]
        [MaxLength(256, ErrorMessage = "Name cannot exceed 256 characters")]
        public string Name { get; set; }

        //just delete email,password and set isdeleted 1
        public bool? IsDeleted { get; set; }
    }
}
