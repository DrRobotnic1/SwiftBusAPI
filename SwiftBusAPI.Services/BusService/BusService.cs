using Domain.Data;
using Domain.Models.BusModel;
using Domain.Models.BusModel.BusDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusServices
{
    public class BusService : IBusService
    {
        private readonly SwiftBusDataContext _context;
        public BusService(SwiftBusDataContext context)
        {
            _context = context;
        }

        public async Task<BusJourneyDto> GetBusJourneyAsync(BusAvailabilityFilterDto filter)
        {
            var schedules = await _context.schedules
               .Include(s => s.Route).ThenInclude(r => r.DepartureCity)
               .Include(s => s.Route).ThenInclude(r => r.ArrivalCity)
               .Include(s => s.Bus)
               .Where(s =>
                   s.Route.DepartureCity.CityName.ToLower() == filter.DepartureCityName.ToLower() &&
                   s.DepartureTime.Date == filter.DepartureDate.Date &&
                   s.TotalSeats > s.BookedSeats)
               .OrderBy(s => s.DepartureTime)
               .ToListAsync();

            if (!schedules.Any()) return null;

            var cityPath = string.Join(" to ", schedules.Select(s => s.Route.DepartureCity.CityName)
                .Concat(new[] { schedules.Last().Route.ArrivalCity.CityName }));

            var timePath = string.Join(" then ", schedules.Select(s => $"{s.DepartureTime:HH:mm} to {s.ArrivalTime:HH:mm}"));

            var summary = $"{cityPath} ({timePath})";

            var legs = schedules.Select(s => new BusLegDto
            {
                Route = $"{s.Route.DepartureCity.CityName} to {s.Route.ArrivalCity.CityName}",
                Time = $"{s.DepartureTime:HH:mm} to {s.ArrivalTime:HH:mm}",
                FullFlexi = s.Route.DistanceKm * 1.00m,
                Flexi = s.Route.DistanceKm * 0.95m,
                Saver = s.Route.DistanceKm * 0.85m
            }).ToList();

            return new BusJourneyDto
            {
                Summary = summary,
                Legs = legs  
            };

        }
    }
}
