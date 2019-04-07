using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Core;
using Project.Bll.Core.Dto;
using Project.Bll.Core.Services;

namespace Atol.ControlPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService) 
            => _userService = userService;

        [HttpGet("all/{skip}/{take}")]
        public ActionResult<IEnumerable<UserModel>> GetAll(int skip, int take) 
            => _userService.GetAll(Filter.NoFilter, skip, take);

        [HttpPost("addNew")]
        public IActionResult AddNew([FromBody]UserModel userModel)
        {
            try
            {
                _userService.AddNew(userModel);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("deleteById")]
        public IActionResult Delete([FromBody]Guid id)
        {
            try
            {
                _userService.DeleteById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
