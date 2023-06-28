using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Notices;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.BLL.Services
{
    public interface INoticeService
    {
        public Notice Add(NoticeFormDTO dto);
        public Notice GetOne(int id);
        public List<Notice> GetMany();
        public bool Update(int id, NoticeFormDTO dto);
        public bool Delete(int id);
    }
}
