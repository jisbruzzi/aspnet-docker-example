using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace aspnet_docker_example.Models
{
    public class ExampleContext:DbContext
    {
        public ExampleContext(DbContextOptions<ExampleContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}