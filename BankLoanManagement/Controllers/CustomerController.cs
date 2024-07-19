using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;
using BankLoanManagement.Models.DTOs;
using BankLoanManagement.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BankLoanManagement.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;

        }
     

        [HttpGet("/GetAll")]
        public IActionResult GetAllCustomer()
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
      
        public ActionResult<CustomerDTO> GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
       
        [HttpPost("AddNewCustomer")]
       
        public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest("Customer data is null");
            }

            var result =  _customerService.AddCustomer(customerDTO);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding customer");
            }

            return CreatedAtAction(nameof(AddCustomer), new { id = result.CustomerId }, result);
        }



        [HttpDelete("DeleteCustomer/{CustomerId}")]
        public ActionResult<Customer> DeleteCustomerById(int CustomerId)
        {
            var customer = _customerService.DeleteCustomerById(CustomerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


       

        [HttpPut("UpdateCustomer")]


        public IActionResult UpdateCustomer([FromBody] CustomerDTO customerDto)
        {
            var updatedCustomer = _customerService.UpdateCustomer(customerDto);

            if (updatedCustomer == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(updatedCustomer);
        }



    }



}
