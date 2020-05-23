using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocAsyncSingleton.Services;

namespace PocAsyncSingleton
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        private readonly IAsyncService _service;
        public DevController(IAsyncService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string message)
        {
            _service.DoWork(message, 10);
            return Ok("works");
        }
    }
}
