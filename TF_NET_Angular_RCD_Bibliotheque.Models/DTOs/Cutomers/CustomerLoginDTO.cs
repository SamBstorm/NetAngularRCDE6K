using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers
{
    public class CustomerLoginDTO
    {
        public int Id { get; set; }
        [Required]
        public string Pseudo { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
