using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services.Abstracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICarService service;

        public HomeController(ICarService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            List<Car> cars = await service.GetAllAsync();
            return Ok(cars);
        }
    }
}
