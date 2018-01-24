using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.TODOList.Entities;
using WebApi.TODOList.Models;
using WebApi.TODOList.Services;

namespace WebApi.TODOList.Controllers
{
    [Route("api/todo")]
    public class TodoController : Controller
    {
        private ITodosRepository _todosRepository;

        public TodoController(ITodosRepository todosRepository)
        {
            _todosRepository = todosRepository;
        }

        [HttpGet()]
        public IActionResult GetTodoList()
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

        [HttpGet("{id}", Name = "GetTodo")]
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

        [HttpPost()]
        public IActionResult CreateTodo([FromBody] Todo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            todo.CreateDate = DateTime.Now;

            _todosRepository.CreateTodo(todo);

            if (!_todosRepository.Save())
            {
                return StatusCode(500, "Error.");
            }

            return CreatedAtRoute("GetTodo", new {id = todo.Id }, todo);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Todo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }

            var ttdo = _todosRepository.GetTodo(id);
            if (ttdo == null)
            {
                return NotFound();
            }

            ttdo.Name = todo.Name;
            ttdo.Description = todo.Description;
            ttdo.EditedDate = DateTime.Now;

            _todosRepository.UpdateTodo(ttdo);
            _todosRepository.Save();

            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
        {

            var todo = _todosRepository.GetTodo(id);

            if (todo == null)
            {
                return NotFound();
            }

            _todosRepository.DeleteTodo(todo);

            if (!_todosRepository.Save())
            {
                return StatusCode(500, "Error.");
            }

            return NoContent();
        }


    }
}