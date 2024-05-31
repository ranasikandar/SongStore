using SongStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.ViewModels
{
    public class ArtistVM
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100, ErrorMessage = "Artist can not exceed 100 characters")]
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }

        public List<Artist> ArtistList { get; set; }
    }

}
