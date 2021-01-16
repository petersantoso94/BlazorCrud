using System;
using Microsoft.AspNetCore.Mvc;

namespace BlazorServerCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumberController : ControllerBase
    {
        [HttpGet]
        public ObjectResult Get()
        {
            Random rd = new Random();
            return Ok(rd.Next(100, 20000000));
        }
    }
}