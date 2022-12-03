using Meetup_API.EventData.Interfaces;
using Meetup_EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meetup_API.Controllers
{
    [ApiController]
    public class GetController : Controller
    {
        private IGetListFromTo _getListFromTo;
        private IGetAll _getAll;

        public GetController(IGetListFromTo getListFromTo, IGetAll getAll)
        {
            _getListFromTo = getListFromTo; 
            _getAll = getAll;
        }

        [HttpPost]
        [Route("api/GetList/{n1}-{n2}")]
        public IActionResult GetList(int n1, int n2)
        {
            List<Event> events = _getListFromTo.Get(n1, n2);
            if (events.Count == 0)
                return BadRequest();
            return Ok(events);
        }

        [HttpPost]
        [Route("api/GetListWithSkip/{n1}-{n2}")]
        public IActionResult GetSkip(int n1, int n2)
        {
            List<Event> events = _getListFromTo.Skip(n1, n2);
            if (events.Count == 0)
                return BadRequest();
            return Ok(events);
        }

        [HttpGet]
        [Route("api/GetAll/")]
        public IActionResult GetAll()
        {
            return Ok(_getAll.Get());
        }

        [HttpPost]
        [Route("api/GetCount/")]
        public IActionResult GetCount()
        {
            return Ok(_getAll.GetCount());
        }

    }
}
