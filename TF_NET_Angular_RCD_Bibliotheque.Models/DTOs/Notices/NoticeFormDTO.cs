using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Notices
{
    public class NoticeFormDTO
    {
        public string Title { get; set; }

        [Range(1, 5)]
        public int Note { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
