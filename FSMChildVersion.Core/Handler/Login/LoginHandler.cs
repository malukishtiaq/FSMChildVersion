using System.Threading;
using System.Threading.Tasks;
using FSMChildVersion.Core.Model;
using FSMChildVersion.Core.Model.Login;
using FSMChildVersion.Core.Services;
using MediatR;

namespace FSMChildVersion.Core.Handler
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ILoginService loginService;

        public LoginHandler(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            try
            {
                UserModel result = await loginService.LoginAsync(request)
                                                .ConfigureAwait(false);
                if (result == null)
                {
                    return LoginResponse.WithStatusAndMessageAndUser(false, ConstantHandlerMessages.LoginFailure, null);
                }
                else
                {
                    return LoginResponse.WithStatusAndUser(true, result);
                }
            }
            catch (System.Exception ex)
            {
                return LoginResponse.WithStatusAndMessageAndUser(false, ex.Message, null);
            }
        }
    }
}
