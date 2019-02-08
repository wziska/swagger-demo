
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    /// <summary>
    /// Users controller - manages user
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private static IList<User> values = new List<User> { new User { Name = "Bob", Age = 77 } };

        /// <summary>
        /// Gets all users
        /// </summary>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return values.ToArray();
        }

        /// <summary>
        /// Gets specific user
        /// </summary>
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return values[id];
        }

        // POST api/values
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <remarks>
        /// Nothing special here
        /// </remarks>
        /// <param name="newUser">New user to be added.</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPost]
        public void Post([FromBody] User newUser)
        {
            values.Add(newUser);
        }

        /// <summary>
        /// Updates user
        /// </summary>
        /// <param name="id">User index</param>
        /// <param name="updateUser">User data to update</param>
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User updateUser)
        {
            values[id] = updateUser;
        }

        // DELETE api/values/5
        /// <summary>
        /// Deletes user
        /// </summary>
        /// <param name="id">User index</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            values.RemoveAt(id);
        }
    }

    public class User
    {
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User age
        /// </summary>
        public int Age { get; set; }
    }
}
