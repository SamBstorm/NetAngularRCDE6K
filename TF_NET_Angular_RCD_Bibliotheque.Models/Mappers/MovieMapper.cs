using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Movies;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.Models.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToDAL(this MovieFormDTO dto)
        {
            return new Movie()
            {
                Title = dto.Title,
                Release = dto.Release,
                Genre = dto.Genre,
                ImageUrl = dto.ImageUrl,
                TrailerUrl = dto.TrailerUrl,
            };
        }

        public static MovieSimpleDTO ToBLL(this Movie m)
        {
            return new MovieSimpleDTO()
            {
                Id = m.Id,
                Title = m.Title,
                Release = m.Release,
                Genre = m.Genre,
                ImageUrl = m.ImageUrl,
                TrailerUrl = m.TrailerUrl,
            };
        }
    }
}
