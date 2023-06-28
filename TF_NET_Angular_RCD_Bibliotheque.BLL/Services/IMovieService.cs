using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Movies;

namespace TF_NET_Angular_RCD_Bibliotheque.BLL.Services
{
    public interface IMovieService
    {
        public MovieSimpleDTO Add(MovieFormDTO movie);
        public MovieSimpleDTO GetOne(int id);
        public List<MovieSimpleDTO> GetMany(MovieSearchDTO movie);
        public bool Update(int id, MovieFormDTO movie);
        public bool Delete(int id);

    }
}
