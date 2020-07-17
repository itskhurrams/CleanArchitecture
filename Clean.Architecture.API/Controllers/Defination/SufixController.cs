using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;

using Microsoft.AspNetCore.Mvc;

using System;

namespace Clean.Architecture.API.Controllers.Defination {
    [Route("api/[controller]")]
    [ApiController]
    public class SufixController : ControllerBase {
        private readonly ISufixService _sufixService;
        private readonly ILoggerManager _loggerManager;
        public SufixController(ISufixService sufix, ILoggerManager logger) {
            _sufixService = sufix;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult GetSufixes() {
            try {
                return Ok(_sufixService.GetSufixes());
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }

        }
    }
}