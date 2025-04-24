using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BusModel.BusDto
{
    public class BusJourneyDto
    {
        public string Summary { get; set; } 
        public List<BusLegDto> Legs { get; set; }
    }
}

