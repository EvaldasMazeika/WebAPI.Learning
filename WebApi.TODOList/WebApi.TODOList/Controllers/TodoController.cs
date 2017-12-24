using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.TODOList.Controllers
{
    [Route("api/todos")]
    public class TodoController : Controller
    {

        [HttpGet()]
        public IActionResult GetTodos()
        {
            return Ok();
        }
    }
}