using SongStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.ViewModels
{
    public class GenreVM
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Genre can not exceed 100 characters")]
        [Display(Name = "Genre")]
        public string GenreName { get; set; }

        public List<Genre> GenreList { get; set; }
    }
}
