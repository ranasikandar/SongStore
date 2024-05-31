using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int SongId { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Song title can not exceed 300 characters")]
        [Display(Name = "Title")]
        public string SongTitle { get; set; }

        [Display(Name = "Year Recorded")]
        //[MaxLength(4, ErrorMessage = "Year Recorded can not exceed 4 digits")]
        [Range(200, 2050, ErrorMessage = "Year Recorded can can be from 200 to 2050")]
        public Int16? YearRecorded { get; set; }

        //FK
        [Required]
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        //FK
        [Required]
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }

        public string ImageLocation { get; set; }
        public string SongFileLocation { get; set; }

        public bool IsDeleted { get; set; }
    }
}
