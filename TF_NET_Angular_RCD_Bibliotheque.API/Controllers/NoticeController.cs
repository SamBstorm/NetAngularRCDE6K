using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TF_NET_Angular_RCD_Bibliotheque.BLL.Services;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Notices;

namespace TF_NET_Angular_RCD_Bibliotheque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeService _noticeService;

        public NoticeController(INoticeService noticeService)
        {
            _noticeService = noticeService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] NoticeFormDTO notice)
        {
            try
            {
                int id = _noticeService.Add(notice).Id;
                return Created($"/api/notice/{id}",id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetOne()
        {
            return Ok(_noticeService.GetMany());
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            try
            {
                return Ok(_noticeService.GetOne(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] NoticeFormDTO notice)
        {
            try
            {
                if (_noticeService.Update(id, notice))
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

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (_noticeService.Delete(id))
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
