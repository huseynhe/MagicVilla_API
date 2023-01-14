using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto requestDto) {

            var loginResponse = await _userRepository.Login(requestDto);
                       
            if (loginResponse.User==null|| string.IsNullOrEmpty(loginResponse.Token))
            {
                return BadRequest(new { message = "UserName or passowr is incorret" });
            }
            return Ok(loginResponse);
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDto model)
        {
            bool ifUserNameUnique = _userRepository.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                return BadRequest(new { message = "User name already taken" });
            }
            var user = await _userRepository.Register(model);
            if (user==null)
            {
                return BadRequest(new { message = "User dont create" });
            }
            return Ok(user);
        }
    
    }
}
