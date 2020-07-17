using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;

using Microsoft.AspNetCore.Mvc;

using System;

namespace Clean.Architecture.API.Controllers.Defination {
    [Route("api/[controller]")]
    [ApiController]
    public class PrefixController : ControllerBase {
        private readonly IPrefixService _prefixService;
        private readonly ILoggerManager _loggerManager;
        public PrefixController(IPrefixService prefix, ILoggerManager logger) {
            _prefixService = prefix;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult GetSufixes() {
            try {
                return Ok(_prefixService.GetPrefixes());
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }

        }
    }
}