using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Movies;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;
using TF_NET_Angular_RCD_Bibliotheque.Models.Mappers;

namespace TF_NET_Angular_RCD_Bibliotheque.BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly INoticeRepository _noticeRepository;

        public MovieService(IMovieRepository movieRepository, INoticeRepository noticeRepository)
        {
            _movieRepository = movieRepository;
            _noticeRepository = noticeRepository;
        }

        public MovieSimpleDTO Add(MovieFormDTO movie)
        {
            return _movieRepository.Add(movie.ToDAL()).ToBLL();
        }

        public MovieSimpleDTO GetOne(int id)
        {
            Movie? movie = _movieRepository.GetOne(m => m.Id == id);
            if(movie is null)
            {
                throw new KeyNotFoundException("Aucun film avec cet id.");
            }
            return movie.ToBLL();
        }

        public List<MovieSimpleDTO> GetMany(MovieSearchDTO movie)
        {
            return _movieRepository.GetMany()
                .Where(m => m.Release == movie.Release || movie.Release is null)
                .Where(m => m.Title == movie.Title || movie.Title is null)
                .Where(m => m.Genre == movie.Genre || movie.Genre is null)
                .Where(m => _noticeRepository.AvgNotice(m.Id) > movie.NoteAvg || movie.NoteAvg is null)
                .Select(m => m.ToBLL()).ToList();
        }

        public bool Update(int id, MovieFormDTO movie)
        {
            Movie? existingMovie = _movieRepository.GetOne(m => m.Id == id);
            if (existingMovie is null)
            {
                throw new KeyNotFoundException("Aucun film avec cet id.");
            }
            existingMovie.Title = movie.Title;
            existingMovie.Release = movie.Release;
            existingMovie.TrailerUrl = movie.TrailerUrl;
            existingMovie.ImageUrl = movie.ImageUrl;
            existingMovie.Genre = movie.Genre;

            return _movieRepository.Update(existingMovie);
        }

        public bool Delete(int id)
        {
            Movie? movie = _movieRepository.GetOne(m => m.Id == id);
            if (movie is null)
            {
                throw new KeyNotFoundException("Aucun film avec cet id.");
            }

            return _movieRepository.Delete(movie);
        }
    }
}
