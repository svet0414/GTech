using System;
using Microsoft.AspNetCore.Mvc;

namespace GTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StatusController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(DateTime.UtcNow + "  Running ");
        }
    }
}
