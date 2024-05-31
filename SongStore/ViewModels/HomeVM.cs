using SongStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.ViewModels
{
    public class HomeVM
    {
        public bool IsAdmin { get; set; }

        [Display(Name = "Search by Song Title")]
        public string SearchSongTitle { get; set; }


        [Display(Name = "Artists?")]
        public List<Artist> Artists { get; set; }

        [Display(Name = "Genres?")]
        public List<Genre> Genres { get; set; }

        public List<short?> YearRecorded { get; set; }

    }
}
