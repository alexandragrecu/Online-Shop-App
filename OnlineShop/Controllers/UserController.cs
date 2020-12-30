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
    public class UserController : ControllerBase
    {
        [HttpGet("/getUser/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = DBServices.GetUser(id);
            
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpGet("/getUsers")]
        public IActionResult GetUsers()
        {
            return Ok(DBServices.GetUsers());
        }

        [HttpPost("/addUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            if (DBServices.AddUser(user))
            {
                return Ok($"User {user.FirstName} has been added!");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost ("/updateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (user.Id < 1)
            {
                return BadRequest();
            }
            try
            {
                DBServices.UpdateUser(user);
                return Ok($"User has been successfully updated!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("/deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {

            if (id < 1)
            {
                return BadRequest();
            }
            try
            {
                DBServices.DeleteUser(id);
                return Ok($"User has been successfully deleted!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
