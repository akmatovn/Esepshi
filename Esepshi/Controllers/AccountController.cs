using ClientAuth.Models;
using ClientAuth.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esepshi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [Route("api/[controller]"), Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _accountService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountService"></param>
        public AccountController(IAuthService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Метод для авторизации пользователя и получения токена
        /// </summary>
        /// <param name="model">Username, Password</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("Authentication")]
        [ProducesResponseType(typeof(AccountModel), 200)]
        [ProducesErrorResponseType(typeof(string))]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _accountService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username или password указано невеверно" });

            return Ok(user);
        }
    }
}