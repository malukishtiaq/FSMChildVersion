using System;
using SQLite;

namespace FSMChildVersion.Repository.DomainModels
{

    [Table(nameof(Farmer))]
    public class Farmer : BaseTable
    {
        public Farmer()
        {
        }

        [PrimaryKey, Unique, NotNull]
        public long SQId { get; set; }
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string FarmerName { get; set; }
        public string Acre { get; set; }
        public string Area { get; set; } 
    }
}
