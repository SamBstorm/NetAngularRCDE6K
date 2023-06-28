using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Notices;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.Mappers
{
    public static class NoticeMapper
    {
        public static Notice ToDAL(this NoticeFormDTO dto)
        {
            return new Notice()
            {
                Title = dto.Title,
                Note = dto.Note,
            };
        }
    }
}
