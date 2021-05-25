using ExcellenceServer.DAL;
using ExcellenceServer.Entities;
using ExcellenceServer.Helpers;
using ExcellenceServer.Models;
using log4net.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using City = ExcellenceServer.Entities.City;

namespace ExcellenceServer.Services
{
    public interface IBuisnessPartnerFormService
    {
        Task<IEnumerable<City>> GetAllCities();
        Task<JsonModelBanksAndBrunches> GetAllBanksAndBrunches();
    }

    public class BuisnessPartnerFormService : IBuisnessPartnerFormService
    {
        private DataContext _context;
        private IConfiguration _configuration;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public BuisnessPartnerFormService(DataContext context, IConfiguration configuration, ILogger<BuisnessPartnerFormService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            try
            {
                return await _context.Cities.FromSqlRaw("EXECUTE dbo.GetCities").ToListAsync();   // get from procedure with ef core
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        public async Task<JsonModelBanksAndBrunches> GetAllBanksAndBrunches()
        {
            string externalApiUrl = _configuration["ExternalApiUrl"];   //get external api url from appsettings

            var json = await GetDataFromExternalApi(externalApiUrl);

            if (json == null)
                throw new NullReferenceException();

            JsonModelBanksAndBrunches obj = JsonConvert.DeserializeObject<JsonModelBanksAndBrunches>(json.ToString());  //deserialize json to object

            obj.data.Banks=obj.data.Banks.Where(x => x.Status == true).ToList();                 // filter to get only valid data
            obj.data.BankBranches= obj.data.BankBranches.OrderBy(branch => branch.BranchName).ToList();
            obj.data.Banks= obj.data.Banks.OrderBy(banks => banks.Description).ToList();


            if (obj.Status == "false")
                throw new NullReferenceException();
            return obj;
        }

        private async Task<string> GetDataFromExternalApi(string externalApiUrl)  
        {
            try
            {
                HttpClient http = new HttpClient();
                var Json = await http.GetStringAsync(externalApiUrl);
                return Json;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e.Message);
                return null;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }  
    }
}

