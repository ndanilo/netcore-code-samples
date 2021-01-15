using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FolderWatcherLinux.Areas.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("works");
        }
    }
}