﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            var lists = _serviceService.TGetList();
            return Ok(lists);
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceService.TInsert(service);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var findId = _serviceService.TGetByID(id);
            _serviceService.TDelete(findId);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdService(int id)
        {
            var findId = _serviceService.TGetByID(id);
            return Ok(findId);
        }
    }
}
