using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BusModel.BusDto
{
    public class BusAvailabilityFilterDto
    {
        public string DepartureCityName { get; set; }
        public string ArrivalCityName { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
