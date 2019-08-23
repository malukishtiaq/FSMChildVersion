using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FSMChildVersion.Repository.DomainModels
{

    [Table(nameof(FarmerVisit))]
    public class FarmerVisit : BaseTable
    {
        [PrimaryKey, Unique, NotNull]
        public long SQId { get; set; }
        public long Id { get; set; }
        public string MobileNo { get; set; } 
        public string FarmerName { get; set; } 
        public string Crop { get; set; } 
        public string Location { get; set; }
    }
}
