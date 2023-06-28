using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF_NET_Angular_RCD_Bibliotheque.BLL.Services;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Movies;

namespace TF_NET_Angular_RCD_Bibliotheque.API.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [Authorize("connectedUser")]
        [HttpPost]
        public IActionResult Add([FromBody] MovieFormDTO movie)
        {
            try
            {
                return Ok(_movieService.Add(movie));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetOne([FromQuery] MovieSearchDTO filter)
        {
            return Ok(_movieService.GetMany(filter));
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            try
            {
                return Ok(_movieService.GetOne(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("connectedUser")]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] MovieFormDTO movie)
        {
            try
            {
                if (_movieService.Update(id, movie))
                {
                    return Ok();
                }
                return BadRequest("La MAJ a echoué");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("connectedUser")]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (_movieService.Delete(id))
                {
                    return Ok();
                }
                return BadRequest("La suppresion a echoué");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
