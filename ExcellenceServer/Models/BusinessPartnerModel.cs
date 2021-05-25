using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellenceServer.Models
{
    public class BusinessPartnerModel
    {
        [Required]
        [MaxLength(20)]
        [RegularExpression("^[\u0590-\u05FF -']+$")]
        public string FullName { get; set; }

        [MaxLength(15)]
        [RegularExpression("^[a-z A-Z -']+$")]
        public string FullNameEnglish { get; set; }
        public DateTime BirthDay { get; set; }

        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        [RegularExpression("^[0-9]+$")]
        public string IdentityCard { get; set; }

        [Required]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string BankDescription { get; set; }

        [Required]
        public int BankCode { get; set; }

        [Required]
        public int BranchNumber { get; set; }
        
        public string BranchName { get; set; }

        [Required ]
        [MaxLength(10)]
        [RegularExpression("^[0-9]+$")]
        public string AccountNumber { get; set; }

    }
}
