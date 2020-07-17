using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;

using Microsoft.AspNetCore.Mvc;

using System;

namespace Clean.Architecture.API.Controllers.Defination {
    [Route("api/[controller]")]
    [ApiController]
    public class MeritalStatusController : ControllerBase {
        private readonly IMeritalStatusService _meritalStatusService;
        private readonly ILoggerManager _loggerManager;
        public MeritalStatusController(IMeritalStatusService meritalStatus, ILoggerManager logger) {
            _meritalStatusService = meritalStatus;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult GetMeritalStatuses() {
            try {
                return Ok(_meritalStatusService.GetMeritalStatuses());
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
    }
}