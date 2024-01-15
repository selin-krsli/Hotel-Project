using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;
        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var lists = _subscribeService.TGetList();
            return Ok(lists);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe subscribe)
        {
            _subscribeService.TInsert(subscribe);  
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe subscribe)
        {
            _subscribeService.TUpdate(subscribe);
            return Ok();    
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var findId = _subscribeService.TGetByID(id);
            _subscribeService.TDelete(findId);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdSubscribe(int id)
        {
            var findId = _subscribeService.TGetByID(id);
            return Ok(findId);
        }
    }
}
