using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnet_docker_example.Models
{
    public class User
    {
        [Required]
        public int Age { get; set; }

        [Key]
        public string Username { get; set; }
    }
}