using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExcellenceServer.Models;
using ExcellenceServer.Services;
using City = ExcellenceServer.Entities.City;
using Microsoft.Extensions.Logging;

namespace ExcellenceServer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPartnersController : ControllerBase
    {
        private IBusinessPartnerService _businessPartnerService;
        private IBuisnessPartnerFormService _buisnessPartnerFormService;
        private readonly ILogger _logger;
      
        public BusinessPartnersController( IBusinessPartnerService businessPartnerService,IBuisnessPartnerFormService buisnessPartnerFormService, ILogger<BusinessPartnersController> logger)
        {
            _businessPartnerService = businessPartnerService;
            _buisnessPartnerFormService = buisnessPartnerFormService;
            _logger = logger;
        }

        [HttpGet("getBusinessPartners")]
        public async Task<ActionResult<IEnumerable<BusinessPartnerModel>>> GetBusinessPartners()
        {
            try
            {
                var businessPartnerModel = new ObjectResult(await _businessPartnerService.GetAllPartners());
                if (businessPartnerModel == null)
                    return BadRequest();
                return businessPartnerModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Massage = "Error GetBusinessPartners " });
            }
        }

        [HttpGet("getAllCities")]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            try
            {
                var cities = new ObjectResult(await _buisnessPartnerFormService.GetAllCities());
                if (cities == null)
                    return BadRequest(new { message = "Error get cities" });
                return cities;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Massage = "Error GetAllCities " });
            }

        }

        [HttpGet("getAllBanksAndBrunches")]
        public async Task<ActionResult<IEnumerable<JsonModelBanksAndBrunches>>> GetAllBanksAndBrunches()
        {
            try
            {
                var jsonModel = new ObjectResult(await _buisnessPartnerFormService.GetAllBanksAndBrunches());
                if (jsonModel == null)
                    return BadRequest(new { message = "Error get banks and brunches from external api" });
                return jsonModel;
            }
          
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(  new { Massage = "Error GetAllBanksAndBrunches " });
            }
        }

        [HttpPost("CreateBusinessPartner")]
        public async Task<ActionResult> CreateBusinessPartner(BusinessPartnerModel businessPartner)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new { message ="error validation" });

                if (businessPartner == null)
                    return BadRequest(new { message = "BusinessPartner is null" });

                var result = await _businessPartnerService.CreatePartner(businessPartner);

                if (result == "Success")
                    return Ok();
               
                return BadRequest(new { message = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Massage = "Error CreateBusinessPartner " });
            }
        }

        [HttpDelete("{identityCard}")]
        public async Task<ActionResult> DeleteBusinessPartner(string identityCard)
        {
            try
            {
                var result = await _businessPartnerService.DeletePartner(identityCard);

                if (result == "Success")
                    return Ok();
                return BadRequest(new { message = result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Massage = "Error DeleteBusinessPartner " });
            }
        }

    }
}
