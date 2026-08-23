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
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id:long}")]
        public IActionResult GetCustomerById(long id) {
            try {
                var customer = _customerAccountService.GetCustomerById(id);
                if (customer == null) {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("check-availability")]
        public IActionResult CheckAvailability([FromQuery] string UserName) {
            try {
                return Ok(_customerAccountService.CheckAvailability(UserName));
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult SaveCustomer([FromBody] CustomerAccount customerAccount) {
            try {
                long id = _customerAccountService.SaveCustomer(customerAccount);
                return CreatedAtAction(nameof(GetCustomerById), new { id = id }, customerAccount);
            }
            catch (Exception Ex) {
                _loggerManager.LogError(Ex.ToString());
                return StatusCode(500, "Internal server error");
            }
        }
    }
}