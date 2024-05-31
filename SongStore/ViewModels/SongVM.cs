using Microsoft.AspNetCore.Http;
using SongStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.ViewModels
{
    public class SongVM
    {
        public int SongId { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Song title can not exceed 300 characters")]
        [Display(Name = "Title")]
        public string SongTitle { get; set; }

        [Display(Name = "Year Recorded")]
        [Range(200, 2050, ErrorMessage = "Year Recorded can can be from 200 to 2050")]
        public Int16? YearRecorded { get; set; }


        public List<Genre> Genres { set; get; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is Required")]
        public int SelectedGenre { set; get; }


        public List<Artist> Artists { set; get; }

        [Display(Name = "Artist")]
        [Required(ErrorMessage = "Artist is Required")]
        public int SelectedArtist { set; get; }


        public string ImageLocation { get; set; }

        [Display(Name = "Song Image")]
        public IFormFile UploadPicture { get; set; }


        public string SongFileLocation { get; set; }

        [Display(Name = "Song File")]
        public IFormFile SongFile { get; set; }

    }
}
