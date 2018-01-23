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

        public Todo GetTodo(int todoId)
        {
            return _context.Todo.Where(x => x.Id == todoId).FirstOrDefault();
        }

        public IEnumerable<Todo> GetTodos()
        {
            return _context.Todo.OrderBy(o => o.CreateDate).ToList();
        }
    }
}
