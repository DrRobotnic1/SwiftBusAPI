using Services.GenericRepo;
using SwiftBusAPI.Domain.Models.BusModel;
using SwiftBusAPI.Domain.Models.CityModel;
using SwiftBusAPI.Domain.Models.CompanyModel;
using SwiftBusAPI.Domain.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitOfWorkService
{
    public interface IUnitOfWork
    {
        IGenericRepository<Company> Companies { get; }
        IGenericRepository<City> Cities { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Bus> Buses { get; }


        Task<int> SaveAsync();
    }
}
