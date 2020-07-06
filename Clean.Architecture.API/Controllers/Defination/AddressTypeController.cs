using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;
using System;

namespace Clean.Architecture.API.Controllers.Defination
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        private readonly IAddressTypeService _addressTypeService;
        private readonly ILoggerManager _loggerManager;
        public AddressTypeController(IAddressTypeService addressType, ILoggerManager logger)
        {
            _addressTypeService = addressType;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult GetAddressTypes()
        {
            try
            {
                return Ok(_addressTypeService.GetAddressTypes());
            }
            catch (Exception Ex)
            {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
    }
}