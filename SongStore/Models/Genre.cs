using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SongStore.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int GenreId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Genre can not exceed 100 characters")]
        [Display(Name = "Genre")]
        public string GenreName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
