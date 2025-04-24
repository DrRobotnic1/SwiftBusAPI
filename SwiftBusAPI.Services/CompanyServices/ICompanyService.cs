using Domain.Models.CompanyModel;
using SwiftBusAPI.Domain.Models.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.CompanyServices
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task<CompanyDto> GetByIdAsync(Guid id);
        Task<CompanyDto> AddAsync(CompanyDto addCompanyDto);
        Task<CompanyDto?> UpdateAsync(Guid id, CompanyDto addCompanyDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
