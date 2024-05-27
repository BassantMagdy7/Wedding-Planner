using Business_Logic_Layer.Dtos.AccountDtos;
using Business_Logic_Layer.Service.AccountServices;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Wedding_Planner_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private Business_Logic_Layer.Service.AccountServices.IAccountBLL _accountBLL;


        public AccountController(Business_Logic_Layer.Service.AccountServices.IAccountBLL accountBLL)
        {
            _accountBLL = accountBLL;

        }

        //create account "post" new user  "registration"
        [HttpPost("register")] //api/account/register
        public async Task<IActionResult> Registration(RegisterUserDto UserDto)
        {
            if (ModelState.IsValid)
            {

                var result = await _accountBLL.Registration(UserDto);
                if (result.Success)
                {
                    return Ok(new { message = "success", user = result.Data });
                }
            }
            return BadRequest(ModelState);
        }

        // check Account Valid "login" "post"
        [HttpPost("Login")] //api/account /login
        public async Task<IActionResult> LoginAsync(LoginUserDto userDto)
        {
            var result = await _accountBLL.LoginAsync(userDto);

            if (result.Success)
            {

                return Ok(result);
            }
            return Unauthorized(result.Message);
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto model)
        {
            var result = await _accountBLL.ForgetPasswordAsync(model);
            if (result.Success)
            {
                return NoContent();
            }
            return BadRequest();
     
        }


        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            await _accountBLL.ResetPassword(model);
            return Ok();
        }

    }

}



