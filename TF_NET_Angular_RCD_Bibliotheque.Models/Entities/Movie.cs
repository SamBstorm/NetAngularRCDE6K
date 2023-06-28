using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.enums;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Release { get; set; }
        public GenreType Genre { get; set; }
        public string ImageUrl { get; set; }
        public string TrailerUrl { get; set; }
        public List<Notice> Notices { get; set; }
    }
}
