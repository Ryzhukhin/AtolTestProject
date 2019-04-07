using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Core;
using Project.Bll.Core.Dto;
using Project.Bll.Core.Services;

namespace Atol.ControlPanel.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService) 
            => _productService = productService;

        [HttpGet("all/{skip}/{take}")]
        public ActionResult<IEnumerable<ProductModel>> GetAll(int skip, int take) 
            => _productService.GetAll(Filter.NoFilter, skip, take);

        [HttpPost("addNew")]
        public IActionResult AddNew([FromBody]ProductModel productModel)
        {
            try
            {
                _productService.AddNew(productModel);
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
                _productService.DeleteById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
