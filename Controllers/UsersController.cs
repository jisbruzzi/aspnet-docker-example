using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet_docker_example.Models;

namespace aspnet_docker_example.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersContext _context;
        public UsersController(UsersContext context)
        {
            _context=context;
        }
        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/users/joseph
        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var item = _context.Users.FirstOrDefault(t=>t.Username==username);
            if(item==null){
                return NotFound();
            }
            return new ObjectResult(item);
            
        }

        //POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            try{
                if(user==null)
                {
                    return BadRequest();
                }
                _context.Users.Add(user);
                _context.SaveChanges();
            }catch(System.Exception e){
                return BadRequest();
            }
            return Created("/api/users/"+user.Username,user);
        }
    }
}
