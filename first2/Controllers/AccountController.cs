using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using first2.DTOs.AccountDto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
//using first2.DTOs.CustomerDTO;
using Microsoft.AspNetCore.Authorization;
using first2.DTOs.AdminDTO;

namespace first2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        UserManager<IdentityUser> UserManager;
        RoleManager<IdentityRole> RoleManager;
        SignInManager<IdentityUser> SignInManager;
        public AccountController(UserManager<IdentityUser> UserManager,
        RoleManager<IdentityRole> RoleManager,
        SignInManager<IdentityUser> SignInManager)
        {
            this.SignInManager = SignInManager;
            this.UserManager = UserManager;
            this.RoleManager = RoleManager;
        }


        [HttpPost]
        public IActionResult login(LoginDto l)
        {
           var item = SignInManager.PasswordSignInAsync(l.user, l.password, false, false).Result;
            var user = UserManager.FindByNameAsync(l.user).Result;
            if (item.Succeeded)
            {
                //generate JWT tokens....
                #region claims
                List<Claim> userdata = new List<Claim>();
                userdata.Add(new Claim(ClaimTypes.Name, l.user)); 
                //userdata.Add(new Claim (ClaimTypes.Nameldentifier, l.));
                var roles = UserManager.GetRolesAsync(user).Result;
                foreach (var itemRole in roles)
                {
                    userdata.Add(new Claim(ClaimTypes.Role, itemRole));

                }
                #endregion
                #region secret key
                string key = "welcome to my secret key mohamed elshafie";
                var secertkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                #endregion
                var signingcer = new SigningCredentials(secertkey, SecurityAlgorithms.HmacSha256);
                #region generate token
                var token = new JwtSecurityToken(
                claims: userdata,
                expires: DateTime.Now.AddDays(1), signingCredentials: signingcer
                );
                //token object => encoded string
                var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
                #endregion
                return Ok(tokenstring);
            }
                

            else return Unauthorized();
        }

        [HttpPost("change_password")]
        [Authorize]
        public IActionResult changepass(ChangePas s)
        {
            //User.Identity.Name
            if (ModelState.IsValid)
            {
                IdentityUser rr = UserManager.FindByNameAsync(User.Identity.Name).Result;
                //IdentityUser r = UserManager.FindByIdAsync(s.id).Result;
                if (rr == null) return BadRequest();
                else
                {
                    IdentityResult ir = UserManager.ChangePasswordAsync(rr, s.oldpass, s.newpass).Result;
                    if (!ir.Succeeded) return BadRequest(ir.Errors);
                    else return Ok();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
        [HttpGet("logout")]
        [Authorize]
        public IActionResult logout()
        {
            SignInManager.SignOutAsync();
            return Ok();
        }

    }
}
