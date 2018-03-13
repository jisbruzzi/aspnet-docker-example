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
        /*
        The DbContext is obtained through the constructor
         */
        private readonly ExampleContext _context;
        public UsersController(ExampleContext context)
        {
            _context=context;
        }

        /**
        This accesses the DbSet we added and returns it as a list.
        The Entity Framework handles transforming that into json
         */
        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        /**
        This method searches for a user by it's username and returns it 
        nested inside an ObjectResult instance. This allows the framework 
        to add the 200 (Ok) code to the response.
        NotFound means the response is a 404.
        Note that we search the Users DbSet.
         */
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
        /**
        POST could throw an exception if a username is added twice. 
        In such case, it's a BadRequest (400).
        Else, a Created object is returned together with a 201 code.
        Note that we modify the Users DbSet and then call SaveChanges().
         */
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
