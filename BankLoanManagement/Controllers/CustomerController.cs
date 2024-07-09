using BankLoanManagement.Interfaces;
using BankLoanManagement.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankLoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;

        }
        [HttpGet]
        public IActionResult Get()

        {
            try
            {
                var customer = _customerService.GetAllCustomers();
                return Ok(customer);
            }
            catch (ListNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetCustomerById")]
        public IActionResult Get(int customerId)
        {
            
            var customer = _customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);

        }
    }

    

}
