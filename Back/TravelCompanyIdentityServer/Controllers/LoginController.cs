using IdentityModel.Client;
using IdentityTestWebApi.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityServerWebApi.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDTO logIn)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(logIn.Name);

            if (user != null && (await _signInManager.CheckPasswordSignInAsync(user, logIn.Pass, false)) == Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                var tokenResponse = await TokenRequest();

                if (!tokenResponse.IsError)
                {
                    return Ok(tokenResponse.AccessToken);
                }
                else
                {
                    return Ok(tokenResponse.Error);
                }
            } else return BadRequest("Invalid username or password");
        }
        
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO signUp)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(signUp.Name);

            if (user != null)
            {
                if (user.Email == signUp.Email)
                    return BadRequest("This email address already in use!");
                else  return BadRequest("This nickname already in use!");
            }

            user = new IdentityUser {UserName=signUp.Name, Email=signUp.Email, EmailConfirmed=true};

            await _userManager.CreateAsync(user, signUp.Pass);
            
            return Ok(TokenRequest().Result.AccessToken);
        }

        private static async Task<TokenResponse> TokenRequest()
        {
            var client = new HttpClient();
            return await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://localhost:44307/connect/token",
                ClientId = "cwm.client",
                Scope = "myApi.read",
                ClientSecret = "secret"
            });
        }
    }
}
