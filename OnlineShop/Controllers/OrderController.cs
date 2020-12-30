using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.DAL;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet("/getOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = DBServices.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(order);
            }
        }
        
        [HttpGet("/getOrders")]
        public IActionResult GetOrders()
        {
            return Ok(DBServices.GetOrders());
        }

        [HttpPost("/addOrder")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            if (DBServices.AddOrder(order))
            {
                return Ok($"Order {order.Name} has been added!");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/updateOrder")]
        public IActionResult UpdateOrder([FromBody] Order order)
        {
            if (order.Id < 1)
            {
                return BadRequest();
            }

            if (DBServices.UpdateOrder(order))
            {
                return Ok($"Order {order.Id} has been successfully updated!");
            } 
            else
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/deleteOrder/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            if (DBServices.DeleteOrder(id))
            {
                return Ok($"Order {id} has been successfully deleted!");
            } 
            else
            {
                return StatusCode(500);
            }
        }

    }

}
