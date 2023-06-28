using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.enums;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Movies
{
    public class MovieFormDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public int Release { get; set; }
        public GenreType Genre { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
    }
}
