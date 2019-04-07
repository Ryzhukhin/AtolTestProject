using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Core.Dto;

namespace Atol.ControlPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<IEnumerable<UserModel>> GetAll()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpPost("addNew")]
        public IActionResult AddNew([FromBody]UserModel userModel)
        {
            return Ok();
        }

        [HttpDelete("deleteById")]
        public IActionResult Delete([FromBody]Guid id)
        {
            return Ok();
        }
    }
}
