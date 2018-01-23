using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.TODOList.Entities;

namespace WebApi.TODOList.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TodosContext context)
        {
            context.Database.EnsureCreated();

            if (context.Todo.Any())
            {
                return;
            }

            var tasks = new Todo[]
            {
                new Todo{Name="First task",Description="whaaat m8, no wei hello"},
                new Todo{Name="Second task",Description="whaaat m8, no wei hello"}
            };

            foreach (var item in tasks)
            {
                context.Todo.Add(item);
            }
            context.SaveChanges();

        }
    }
}
