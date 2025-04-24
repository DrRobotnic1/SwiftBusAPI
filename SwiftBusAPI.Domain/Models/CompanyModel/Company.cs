using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBusAPI.Domain.Models.BusModel;

namespace SwiftBusAPI.Domain.Models.CompanyModel
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CompName { get; set; } = string.Empty;

        public ICollection<Bus> Buses { get; set; }
    }
}
