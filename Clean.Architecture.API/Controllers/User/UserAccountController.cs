using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.Application.Interfaces.Application.User;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;
using Clean.Architecture.Domain.User;
using System;

namespace Clean.Architecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        private readonly ILoggerManager _loggerManager;
        public UserAccountController(IUserAccountService userAccount, ILoggerManager logger)
        {
            _userAccountService = userAccount;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult CheckAvailability(string UserName)
        {
            try
            {
                return Ok(_userAccountService.CheckAvailability(UserName));
            }
            catch (Exception Ex)
            {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult SaveUser([FromBody]UserAccount userAccount)
        {
            try
            {
                return CreatedAtRoute("DefaultApi", new { id = _userAccountService.SaveUser(userAccount) }, userAccount);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}