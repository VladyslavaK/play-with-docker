using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleAPI.Infrastructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        { }

        public DbSet<ToDoTask> Tasks { get; set; }
    }
    public abstract class Entity 
    {
        public int Id { get; set; }
    }

    public class ToDoTask : Entity
    {        
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
