using System;
using SQLite;
namespace FSMChildVersion.Repository.DomainModels
{
    [Table(nameof(MakeUp))]
    public class MakeUp
    {
        [PrimaryKey, Unique, NotNull]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ImageLink { get; set; }
        public string ProductLink { get; set; }
        public string WebsiteLink { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }
        public string Category { get; set; }
        public string ProductType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ProductApiUrl { get; set; }
        public string ApiFeaturedImage { get; set; }
        public string TimeText { get; set; }
    }
}
