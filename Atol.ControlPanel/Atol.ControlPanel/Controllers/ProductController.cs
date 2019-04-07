using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Core.Dto;

namespace Atol.ControlPanel.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("all")]
        public ActionResult<IEnumerable<ProductModel>> GetAll()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpPost("addNew")]
        public IActionResult AddNew([FromBody]ProductModel productModel)
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
