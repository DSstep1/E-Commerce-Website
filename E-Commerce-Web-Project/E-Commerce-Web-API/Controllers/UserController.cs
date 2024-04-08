using AutoMapper;
using E_Comemerce_Web_DAL;
using E_commerce_Web_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Commerce_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly E_Commerce_Web_DBContext _dbContext;
        private readonly IMapper _mapper;

        public UsersController(E_Commerce_Web_DBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public List<UserDTO> GetUsers()
        {
            return _mapper.Map<List<UserDTO>>(_dbContext.Users.ToList<User>());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public UserDTO GetUserById(int id)
        {
            return _mapper.Map<UserDTO>(_dbContext.Users.Find(id));
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult AddUser(UserDTO newUser)
        {
            try
            {
                var user = _mapper.Map<User>(newUser);
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return Ok(newUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public ActionResult UpdateUser([FromRoute] int id, UserDTO user)
        {
            try
            {
                var myUser = _dbContext.Users.Find(id);
                if (myUser == null)
                {
                    return NotFound();
                }

                myUser.Name = user.Name;
                myUser.Email = user.Email;
                myUser.Password = user.Password;

                _dbContext.SaveChanges();
                return Ok(myUser);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var user = _dbContext.Users.Find(id);
                if (user == null)
                    return NotFound();

                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
    }
}
