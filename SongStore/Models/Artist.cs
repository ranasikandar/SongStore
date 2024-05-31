using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int ArtistId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Artist can not exceed 100 characters")]
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
