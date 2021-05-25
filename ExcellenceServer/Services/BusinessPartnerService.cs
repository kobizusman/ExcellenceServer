using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExcellenceServer.DAL;
using ExcellenceServer.Entities;
using ExcellenceServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExcellenceServer.Services
{

    public interface IBusinessPartnerService
    {
        Task<IEnumerable<BusinessPartnerModel>> GetAllPartners();
        Task<string> CreatePartner(BusinessPartnerModel businessPartner);
        Task<string> DeletePartner(string id);
    }

    public class BusinessPartnerService : IBusinessPartnerService
    {

        private DataContext _context;
        private IMapper _mapper;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public BusinessPartnerService(DataContext context, IMapper mapper ,ILogger<BusinessPartnerService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> CreatePartner(BusinessPartnerModel businessPartnerModelRequest)
        {
            try
            {
                var businessPartner = _mapper.Map<BusinessPartner>(businessPartnerModelRequest);
                if (ValidatePartnerIsExist(businessPartner))
                    return "Partner existing";
                            
                _context.BusinessPartners.Add(businessPartner);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return e.Message;
            }
        }
 
        public async Task<IEnumerable<BusinessPartnerModel>> GetAllPartners()
        {
            try
            {             
                var BusinessPartners = await _context.BusinessPartners.ToListAsync();
                var businessPartnersModel = _mapper.Map<List<BusinessPartner>, List<BusinessPartnerModel>>(BusinessPartners);
                foreach (var item in businessPartnersModel)
                {
                    item.CityName = _context.Cities.Find(item.CityId).Name;
                }
                return businessPartnersModel.OrderBy(p=>p.FullName);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<string> DeletePartner(string id)
        {
            try
            {
                var businessPartner =  _context.BusinessPartners.Find(id);
                var businessPartnerModel = _mapper.Map<BusinessPartnerModel>(businessPartner);
                if (businessPartner == null)
                    return "Partner not existing";

                _context.BusinessPartners.Remove(businessPartner);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return "error deleted";
            }
        }

        private bool ValidatePartnerIsExist(BusinessPartner businessPartner)
        {
            try
            {
                return _context.BusinessPartners.Any(b => b.IdentityCard == businessPartner.IdentityCard);
            }
           
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}
