using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAPI.Infrastructure
{
    public class Repository
    {
        private ToDoContext _context; 
        public Repository(ToDoContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoTask> GetTasks()
        {
           return  _context.Set<ToDoTask>().ToList();
        }

        public long AddTask(ToDoTask task)
        {
            return _context.InsertOrUpdate(task);
        }
    }
}
