using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.TODOList.Services;

namespace WebApi.TODOList.Controllers
{
    [Route("api/todo/{todos}/comment")]
    public class CommentsController : Controller
    {
        private readonly ITodosRepository _todoRepository;

        public CommentsController(ITodosRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet()]
        public IActionResult GetCommentsList()
        {
            return Ok();
        }
    }
}