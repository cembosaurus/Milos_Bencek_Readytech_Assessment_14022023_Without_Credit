﻿using Coffee.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {

        private readonly ICoffeeService _coffeeService;
        private readonly ICounterService _counterService;


        public CoffeeController(ICoffeeService coffeeService, ICounterService counterService)
        {
            _coffeeService = coffeeService;
            _counterService = counterService;
        }



        [HttpGet("brew-coffee")]
        public ActionResult GetCoffee()
        {
            return _counterService.IsFifth ? StatusCode(503, "") : Ok(_coffeeService.GetCoffee().Data);
        }




    }
}
