using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExcellenceServer.Entities
{
    public class BusinessPartner
    {
     //   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string FullName { get; set; }
        public string FullNameEnglish { get; set; }
        public DateTime BirthDay { get; set; }
        [Key]
        public string IdentityCard { get; set; }
        public int BankCode { get; set; }
        public int BranchNumber { get; set; }
        public string AccountNumber { get; set; }
        public string BankDescription { get; set; }
        public string BranchName { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}

