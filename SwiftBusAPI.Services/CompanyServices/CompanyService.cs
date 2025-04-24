using AutoMapper;
using Domain.Models.CompanyModel;
using Microsoft.Extensions.Logging;
using Services.UnitOfWorkService;
using SwiftBusAPI.Domain.Models.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Services.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger? _logger;
        private readonly IMapper _mapper;
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        
        }
        public async Task<CompanyDto> AddAsync(CompanyDto companyDto)
        {
            if (companyDto == null || string.IsNullOrWhiteSpace(companyDto.CompName))
                return null;

            var company = new Company { CompName = companyDto.CompName };

            try
            {
                await _unitOfWork.Companies.AddAsync(company);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating company");
                return null;
            }

            return new CompanyDto { CompName = company.CompName };
        }
        

        public async Task<bool> DeleteAsync(Guid id)
        {
           var company = await _unitOfWork.Companies.GetByIdAsync(id);

            if (company != null)
            {
                  _unitOfWork.Companies.Delete(company);
                await _unitOfWork.SaveAsync();
            }
            return false;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
     
           var companies = await _unitOfWork.Companies.GetAllAsync();
            return companies.Select(c => new CompanyDto {CompName = c.CompName });
        }

        public async Task<CompanyDto> GetByIdAsync(Guid id)
        {
            var company = _unitOfWork.Companies.GetByIdAsync(id);

            if (company == null)
                return null;

           var result = _mapper.Map<CompanyDto>(company);

            return result;
            
        }

        public async Task<CompanyDto?> UpdateAsync(Guid id, CompanyDto addCompanyDto)
        {
            var existingCompany = await _unitOfWork.Companies.GetByIdAsync(id);

            if (existingCompany != null)
                return null;

            
             _unitOfWork.Companies.Update(existingCompany);
                await _unitOfWork.SaveAsync();

            var resultDto = _mapper.Map<CompanyDto>(existingCompany);
            return resultDto;
        }
    }
}
