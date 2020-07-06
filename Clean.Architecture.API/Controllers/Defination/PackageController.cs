using Microsoft.AspNetCore.Mvc;
using Clean.Architecture.Application.Interfaces.Application.Defination;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;
using System;

namespace Clean.Architecture.API.Controllers.Defination
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        private readonly ILoggerManager _loggerManager;
        public PackageController(IPackageService package, ILoggerManager logger)
        {
            _packageService = package;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult GetPackages()
        {
            try
            {
                return Ok(_packageService.GetPackages());
            }
            catch (Exception Ex)
            {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
    }
}