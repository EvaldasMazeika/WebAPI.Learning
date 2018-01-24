using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.TODOList.Entities;

namespace WebApi.TODOList.Services
{
    public class TodosRepository : ITodosRepository
    {
        private TodosContext _context;

        public TodosRepository(TodosContext context)
        {
            _context = context;
        }

        public void CreateTodo(Todo todo)
        {
            _context.Todo.Add(todo);
        }

        public void DeleteTodo(Todo todo)
        {
            _context.Todo.Remove(todo);
        }

        public Todo GetTodo(int todoId)
        {
            return _context.Todo.Where(x => x.Id == todoId).FirstOrDefault();
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _context.Todo.OrderBy(o => o.CreateDate).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTodo(Todo todo)
        {
            _context.Todo.Update(todo);
        }
    }
}
