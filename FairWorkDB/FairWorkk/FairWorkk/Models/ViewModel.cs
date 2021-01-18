using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FairWorkk.Models
{
    public class ViewModel
    {
        public IEnumerable<Contract> ContractModel { get; set; }
        public IEnumerable<AdditionalStandMaterial> ASMModel { get; set; }
        public IEnumerable<FreeArea> FreeAreaModel { get; set; }
        public IEnumerable<SalesPerson> SalesPersonModel { get; set; }
    }
}