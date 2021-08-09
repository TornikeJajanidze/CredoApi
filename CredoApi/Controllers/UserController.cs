using CredoApi.Model;
using CredoApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredoApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;
        public UserController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)

        {
            var user = _repository.GetUserById(id);
            if (user == null)
                return NotFound("user not found");
            return Ok(user);
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return Ok(users);

        }
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            var createdUser = _repository.CreateUser(user);
            _repository.SaveChanges();
            return Ok(createdUser);

        }
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var userToDelete = _repository.GetUserById(id);
            if (userToDelete == null)
                return NotFound("not found user tavidan cade");
            _repository.DeleteUser(userToDelete);
            _repository.SaveChanges();
            return Ok(userToDelete);
        }
        [HttpPut]
        public ActionResult<User> UpdateUser(User user)
        {
            _repository.UpdateUser(user);
            _repository.SaveChanges();
            return Ok(user);

        }
    }
}
