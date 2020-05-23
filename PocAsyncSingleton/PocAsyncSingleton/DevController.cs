using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PocAsyncSingleton.Services;

namespace PocAsyncSingleton
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {
        private readonly IAsyncService _service;
        private readonly IDoSomethingService _doSomethingService;
        public DevController(IAsyncService service, IDoSomethingService doSomethingService)
        {
            _service = service;
            _doSomethingService = doSomethingService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string message)
        {
            Func<Task> function = () => Task.Run(() => _doSomethingService.WriteMessageAtDebug(message, 10));
            _service.DoWork(function);

            return Ok("works");
        }
    }
}
