using System.ComponentModel;

namespace FSMChildVersion.Common.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public bool IsLogin { get; set; }
    }
}
