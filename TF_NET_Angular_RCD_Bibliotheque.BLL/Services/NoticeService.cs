using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Notices;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;
using TF_NET_Angular_RCD_Bibliotheque.Models.Mappers;

namespace TF_NET_Angular_RCD_Bibliotheque.BLL.Services
{
    public class NoticeService : INoticeService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly INoticeRepository _noticeRepository;

        public NoticeService(IMovieRepository movieRepository, ICustomerRepository customerRepository, INoticeRepository noticeRepository)
        {
            _movieRepository = movieRepository;
            _customerRepository = customerRepository;
            _noticeRepository = noticeRepository;
        }

        public Notice Add(NoticeFormDTO dto)
        {
            Movie? m = _movieRepository.GetOne(m => m.Id == dto.MovieId);
            Customer? c = _customerRepository.GetOne(c => c.Id == dto.CustomerId);
            if(m is null || c is null)
            {
                throw new KeyNotFoundException("Soit le customer,soit le film n'existe pas");
            }
            Notice n = dto.ToDAL();
            n.Movie = m;
            n.Customer = c;

            return _noticeRepository.Add(n);
        }

        public Notice GetOne(int id)
        {
            Notice? n = _noticeRepository.GetOne(n => n.Id == id);
            if(n is null)
            {
                throw new KeyNotFoundException("L'avis n'existe pas");
            }
            return n;
        }

        public IEnumerable<Notice> GetMany()
        {
            return _noticeRepository.GetMany();
        }

        public bool Update(int id, NoticeFormDTO dto)
        {
            Notice? existingNotice = _noticeRepository.GetOne(n => n.Id == id);
            if (existingNotice is null)
            {
                throw new KeyNotFoundException("L'avis n'existe pas");
            }
            existingNotice.Title = dto.Title;
            existingNotice.Note = dto.Note;

            return _noticeRepository.Update(existingNotice);
        }

        public bool Delete(int id)
        {
            Notice? existingNotice = _noticeRepository.GetOne(n => n.Id == id);
            if (existingNotice is null)
            {
                throw new KeyNotFoundException("L'avis n'existe pas");
            }
            return _noticeRepository.Delete(existingNotice);
        }
    }
}
