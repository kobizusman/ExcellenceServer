using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcellenceServer.Models
{

    public class JsonModelBanksAndBrunches
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public Data data { get; set; }

    }

    public class Data
    {
        public List<Bank> Banks { get; set; }

        public List<BankBranch> BankBranches { get; set; }
    }

    public class BankBranch
    {
        public int BankCode { get; set; }
        public int BranchNumber { get; set; }
        public string BranchName { get; set; }

    }

    public class Bank
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

    }



}
