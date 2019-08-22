using SQLite;

namespace FSMChildVersion.Repository.DomainModels
{

    [Table(nameof(User))]
    public class User
    {
        [PrimaryKey, Unique, NotNull]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
    }
}
