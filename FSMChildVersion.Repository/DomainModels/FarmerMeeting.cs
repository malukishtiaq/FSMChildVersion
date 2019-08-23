using SQLite;

namespace FSMChildVersion.Repository.DomainModels
{
    [Table(nameof(FarmerMeeting))]
    public class FarmerMeeting : BaseTable
    {
        [PrimaryKey, Unique, NotNull]
        public long SQId { get; set; }
        public long Id { get; set; }
        public string MobileNo { get; set; }
        public string FarmerName { get; set; }
        public string Area { get; set; }
        public string NoOfParticipent { get; set; }
        public string Image { get; set; }
    }
}
