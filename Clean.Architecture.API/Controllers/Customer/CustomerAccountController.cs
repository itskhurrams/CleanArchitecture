using Clean.Architecture.Application.Interfaces.Application.Customer;
using Clean.Architecture.Application.Interfaces.Infastructure.Logging;
using Clean.Architecture.Domain.Customer;

using Microsoft.AspNetCore.Mvc;

using System;

namespace Clean.Architecture.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase {
        private readonly ICustomerAccountService _customerAccountService;
        private readonly ILoggerManager _loggerManager;
        public CustomerAccountController(ICustomerAccountService customerAccount, ILoggerManager logger) {
            _customerAccountService = customerAccount;
            _loggerManager = logger;
        }
        [HttpGet]
        public IActionResult GetCustomers() {
            try {
                return Ok(_customerAccountService.GetCustomers());
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public IActionResult CheckAvailability(string UserName) {
            try {
                return Ok(_customerAccountService.CheckAvailability(UserName));
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.InnerException.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult SaveCustomer([FromBody] CustomerAccount customerAccount) {
            try {
                return CreatedAtRoute("DefaultApi", new { id = _customerAccountService.SaveCustomer(customerAccount) }, customerAccount);
            }
            catch (Exception) {
                throw;
            }
        }
    }
}