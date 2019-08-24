using MediatR;

namespace FSMChildVersion.Common.Model.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = false;


        public static LoginRequest CreateLoginRequest(string username, string password)
        {
            return new LoginRequest(username, password);
        }
        public LoginRequest()
        {

        }
        public LoginRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
