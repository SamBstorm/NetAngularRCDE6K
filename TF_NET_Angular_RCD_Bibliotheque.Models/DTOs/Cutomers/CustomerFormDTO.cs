using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers
{
    public class CustomerFormDTO
    {
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Firstname { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
