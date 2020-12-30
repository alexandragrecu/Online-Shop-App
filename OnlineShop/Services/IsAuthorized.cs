using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// just admins are allowed to add add products in app
namespace OnlineShop.Services
{
    public class IsAuthorized : Attribute, IActionFilter

    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["role"]))
            {
                context.Result = new UnauthorizedResult();  
            }
            if (!ValidateRole(context.HttpContext.Request.Headers["role"], context.RouteData.Values["action"].ToString()))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
         
        }

        private bool ValidateRole(string role, string method)
        {
            if (role == "admin" && method == "AddProduct")
            {
                return true;
            }
            else
            { return false;  }
        }
    }
}
