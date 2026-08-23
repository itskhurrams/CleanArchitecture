using Clean.Architecture.Application.Interfaces.Application.User;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;
using Clean.Architecture.Domain.User;

using Microsoft.AspNetCore.Mvc;

using System;

namespace Clean.Architecture.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase {
        private readonly IUserAccountService _userAccountService;
        private readonly ILoggerManager _loggerManager;
        public UserAccountController(IUserAccountService userAccount, ILoggerManager logger) {
            _userAccountService = userAccount;
            _loggerManager = logger;
        }

        [HttpGet]
        public IActionResult GetUsers() {
            try {
                return Ok(_userAccountService.GetUsers());
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:long}")]
        public IActionResult GetUserById(long id) {
            try {
                var user = _userAccountService.GetUserById(id);
                if (user == null) {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("check-availability")]
        public IActionResult CheckAvailability([FromQuery] string UserName) {
            try {
                return Ok(_userAccountService.CheckAvailability(UserName));
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult SaveUser([FromBody] UserAccount userAccount) {
            try {
                long id = _userAccountService.SaveUser(userAccount);
                return CreatedAtAction(nameof(GetUserById), new { id = id }, userAccount);
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
    }
}