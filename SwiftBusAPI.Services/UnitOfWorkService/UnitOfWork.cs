using Domain.Data;
using Domain.Models.ScheduleModel;
using Services.GenericRepo;
using SwiftBusAPI.Domain.Models.BusModel;
using SwiftBusAPI.Domain.Models.CityModel;
using SwiftBusAPI.Domain.Models.CompanyModel;
using SwiftBusAPI.Domain.Models.TicketModel;
using SwiftBusAPI.Domain.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitOfWorkService
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SwiftBusDataContext _context;

        public IGenericRepository<Company> Companies { get; private set; }
        public IGenericRepository<City> Cities { get; private set; }
        public IGenericRepository<User> Users { get; private set; }
        public IGenericRepository<Bus> Buses { get; private set; }

        public UnitOfWork(SwiftBusDataContext context)
        {
            _context = context;

            Companies = new GenericRepository<Company>(_context);
            Cities = new GenericRepository<City>(_context);
            Users = new GenericRepository<User>(_context);
            Buses = new GenericRepository<Bus>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
