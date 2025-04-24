using AutoMapper;
using Domain.Models.CompanyModel;
using SwiftBusAPI.Domain.Models.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyDto,Company>().ReverseMap();
        }
    }
}
