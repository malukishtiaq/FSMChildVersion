using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FSMChildVersion.Repository.DomainModels
{
    [Table(nameof(Feedback))]
    public class Feedback : BaseTable
    {
        [PrimaryKey, Unique, NotNull]
        public long SQId { get; set; }
        public long Id { get; set; }
        public string MobileNo { get; set; }
        public string FarmerName { get; set; }
        public string Crop { get; set; }
        public string Product { get; set; }
        public string Image { get; set; }
    }
}
