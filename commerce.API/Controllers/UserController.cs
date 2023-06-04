using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Application.Dtos;
using Commerce.Application.IServices.User;
using Microsoft.AspNetCore.Mvc;

namespace commerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto userDto)
        {
            _userService.AddUser(userDto);
            return Ok();
        }

    }
}