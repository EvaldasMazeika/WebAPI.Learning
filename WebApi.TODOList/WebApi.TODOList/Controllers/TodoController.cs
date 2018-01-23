using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.TODOList.Models;
using WebApi.TODOList.Services;

namespace WebApi.TODOList.Controllers
{
    [Route("api/todos")]
    public class TodoController : Controller
    {
        private ITodosRepository _todosRepository;

        public TodoController(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        [HttpGet()]
        public IActionResult GetTodos()
        {
            var todos = _todosRepository.GetTodos();

            var results = new List<TodoDto>();

            foreach (var item in todos)
            {
                results.Add(new TodoDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    CreateDate = item.CreateDate,
                    EditDate = item.EditedDate
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetTodo(int id)
        {
            var todo = _todosRepository.GetTodo(id);

            if (todo == null)
            {
                return NotFound();
            }

            var result = new TodoDto()
            {
                Id = todo.Id,
                Name = todo.Name,
                Description = todo.Description,
                CreateDate = todo.CreateDate,
                EditDate = todo.EditedDate
            };
            return Ok(result);
        }

    }
}