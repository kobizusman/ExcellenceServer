using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellenceServer.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string Name { get; set; }

        public IList<BusinessPartner> BusinessPartners { get; set; }
    }
}
