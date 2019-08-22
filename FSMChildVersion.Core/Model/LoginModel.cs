using System.ComponentModel;
using Plugin.FluentValidationRules;
using PropertyChanged;

namespace FSMChildVersion.Core.Model
{
    public class LoginModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Username { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
    }
}
