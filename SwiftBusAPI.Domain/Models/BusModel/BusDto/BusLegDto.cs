using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.BusModel.BusDto
{
    public class BusLegDto
    {
        public string Route { get; set; }  
        public string Time { get; set; }   
        public decimal FullFlexi { get; set; }
        public decimal Flexi { get; set; }
        public decimal Saver
        {
            get; set;
        }
    }
}
