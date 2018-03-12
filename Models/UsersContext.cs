using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace aspnet_docker_example.Models
{
    public class UsersContext:DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            :base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}