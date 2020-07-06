using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;
using System;

namespace Clean.Architecture.API.Controllers.Defination
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessTypeController : ControllerBase
    {
        private readonly IBusinessTypeService _businessTypeService;
        private readonly ILoggerManager _loggerManager;
        public BusinessTypeController(IBusinessTypeService businessType, ILoggerManager logger)
        {
            _businessTypeService = businessType;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult GetMeritalStatuses()
        {
            try
            {
                return Ok(_businessTypeService.GetBusinessTypes());
            }
            catch (Exception Ex)
            {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
    }
}