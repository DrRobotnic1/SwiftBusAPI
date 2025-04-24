using Domain.Models.CompanyModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CompanyServices;
using Services.UnitOfWorkService;
using SwiftBusAPI.Domain.Models.CompanyModel;

namespace SwiftBusAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyService _companyService;

        public CompaniesController(IUnitOfWork unitOfWork, ICompanyService companyService)
        {
          _unitOfWork = unitOfWork;
            _companyService = companyService;
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompaniesAsync()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();
            return Ok(companies);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetCompanyByIdAsync(Guid Id)
        {
            return Ok(await _unitOfWork.Companies.GetByIdAsync(Id));
        }
    
        [HttpPost("AddCompany")]
        public async Task<IActionResult> AddCompanyAsync([FromBody] CompanyDto companyDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _companyService.AddAsync(companyDto);

            if (result == null)
                return StatusCode(500, "Failed to create company");

            return Ok("Company succesfully Added.");
        }
        [HttpPost("UpdateCompany")]
        public async Task<IActionResult> UpdateCompanyAsync(Guid id, CompanyDto updateCompanyDto)
        {
            var result = await _companyService.UpdateAsync(id, updateCompanyDto);

            if(result == null)
                return StatusCode(500, "Failed to update company");

            return Ok("Company succesfully Updatetd");

        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCompanyAsync(Guid Id)
        {
            var existingCompany = await _companyService.GetByIdAsync(Id);

            if(existingCompany == null)
                return StatusCode(500, "Failed to update company");

            return Ok("Unable to delete Company");

        }



    }
}
