using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.DAL.DataContext;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories
{
    public class NoticeRepository : BaseRepository<Notice>, INoticeRepository
    {
        public NoticeRepository(LibraryContext dbContext) : base(dbContext) { }

        public int AvgNotice(int movieId)
        {
            IEnumerable<int> result = _entities.Include(n => n.Movie)
                .Where(n => n.Movie.Id == movieId)
                .Select(n => n.Note);
            
            return result.Any() ? (int)result.Average() : 0;
        }
    }
}
