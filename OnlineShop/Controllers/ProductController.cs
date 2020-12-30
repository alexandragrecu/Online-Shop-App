using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DAL;
using OnlineShop.Models;
using OnlineShop.Services;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("/getProduct/{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = DBServices.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpGet("/getProducts")]
        public IActionResult GetProducts()
        {
            return Ok(DBServices.GetProducts());
        }

        [IsAuthorized]
        [HttpPost("/addProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (DBServices.AddProduct(product))
            {
                return Ok($"User {product.Name} has been added!");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/updateProduct")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            if (product.Id < 1)
            {
                return BadRequest();
            }
            try
            {
                DBServices.UpdateProduct(product);
                return Ok($"Product has been successfully updated!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/deleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {

            if (id < 1)
            {
                return BadRequest();
            }
            try
            {
                DBServices.DeleteProduct(id);
                return Ok($"Product has been successfully deleted!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
