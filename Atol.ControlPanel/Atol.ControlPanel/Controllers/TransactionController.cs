using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Core.Dto;
using Project.Bll.Core.Services;

namespace Atol.ControlPanel.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService) 
            => _transactionService = transactionService;



        //todo не успеваю, но тут тоже самое, что и в product/userController




        [HttpGet("all")]
        public ActionResult<IEnumerable<TransactionModel>> GetAll()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        [HttpPost("addNew")]
        public IActionResult AddNew([FromBody]TransactionModel productModel)
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
