using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.TODOList.Entities;

namespace WebApi.TODOList.Services
{
    public interface ITodosRepository
    {
        IEnumerable<Todo> GetTodos();
        Todo GetTodo(int todoId);
        void CreateTodo(Todo todo);
        void DeleteTodo(Todo todo);
        void UpdateTodo(Todo todo);
        bool Save();
    }
}
