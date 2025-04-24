using SwiftBusAPI.Domain.Models.BusModel;
using SwiftBusAPI.Domain.Models.RouteModel;
using SwiftBusAPI.Domain.Models.TicketModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ScheduleModel
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid RouteId { get; set; }
        public Guid BusId { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }

        public Route Route { get; set; }
        public Bus Bus { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
