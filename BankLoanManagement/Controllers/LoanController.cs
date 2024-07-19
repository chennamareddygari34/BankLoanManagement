using BankLoanManagement.Interfaces;
using BankLoanManagement.Models.DTOs;
using BankLoanManagement.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankLoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

      

        [HttpGet]
        public IActionResult GetLoanById(int loanId)
        {
            var loan = _loanService.GetLoanById(loanId);
            if (loan == null) 
            {
                return NotFound();
            }
            return Ok(loan);


        }
        [HttpPost("apply")]
        public ActionResult<LoanResponseDTO> ApplyForLoan(LoanRequestDTO loanRequest)
        {
            try
            {
                var response = _loanService.ApplyForLoan(loanRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
