using System;
using SQLite;

namespace FSMChildVersion.Repository.DomainModels
{
    [Table(nameof(Attendance))]
    public class Attendance : BaseTable
    {
        [PrimaryKey, Unique, NotNull]
        public long SQId { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Status { get; set; } 
    }
}
