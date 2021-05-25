using AutoMapper;
using ExcellenceServer.Entities;
using ExcellenceServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExcellenceServer.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BusinessPartnerModel, BusinessPartner>();
            CreateMap<BusinessPartner, BusinessPartnerModel>(); 
        }
    }
}
