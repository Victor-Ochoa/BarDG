using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.Jwt.Model;
using NetDevPack.Identity.Model;

namespace BarDG.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppJwtSettings _appJwtSettings;

        public AuthController(SignInManager<IdentityUser> signInManager,
                      UserManager<IdentityUser> userManager,
                      IOptions<AppJwtSettings> appJwtSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appJwtSettings = appJwtSettings.Value;
        }


        //[HttpPost("register")]
        //public async Task<ActionResult> Register(RegisterUser registerUser)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);

        //    var user = new IdentityUser
        //    {
        //        UserName = registerUser.Email,
        //        Email = registerUser.Email,
        //        EmailConfirmed = true
        //    };

        //    var result = await _userManager.CreateAsync(user, registerUser.Password);

        //    if (result.Succeeded)
        //    {
        //        return Ok(GetUserResponse(user.Email));
        //    }

        //    return BadRequest(result.Errors);
        //}

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                var fullJwt = GetFullJwt(loginUser.Email);
                return Ok(fullJwt);
            }

            if (result.IsLockedOut)
            {
                return BadRequest("This user is blocked");
            }

            return BadRequest("Incorrect user or password");
        }

        //private UserResponse GetUserResponse(string email)
        //{
        //    return new JwtBuilder()
        //        .WithUserManager(_userManager)
        //        .WithJwtSettings(_appJwtSettings)
        //        .WithEmail(email)
        //        .WithJwtClaims()
        //        .WithUserClaims()
        //        .WithUserRoles()
        //        .BuildUserResponse() as UserResponse;
        //}

        private string GetFullJwt(string email)
        {
            return new JwtBuilder()
                .WithUserManager(_userManager)
                .WithJwtSettings(_appJwtSettings)
                .WithEmail(email)
                .WithJwtClaims()
                .WithUserClaims()
                .WithUserRoles()
                .BuildToken();
        }
    
    }
}
