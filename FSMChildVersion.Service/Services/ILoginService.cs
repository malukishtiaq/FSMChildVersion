using System;
using System.Linq;
using System.Threading.Tasks;
using FSMChildVersion.Common.RequestResponseModel;
using FSMChildVersion.Common.RequestResponseModel.Login;
using FSMChildVersion.Repository.APIManager;
using FSMChildVersion.Repository.DomainModels;

namespace FSMChildVersion.Service.Services
{
    public class LoginService : ApiManager, ILoginService
    {
        public LoginService()
        {
        }

        public Task<UserModel> LoginAsync(LoginRequest userModel)
        {
            if (userModel is null)
                throw new ArgumentNullException(nameof(userModel));

            UnitOfWork.GenericHandler<User>().Insert(new User() { Username = "f", Password = "f" });
            UnitOfWork.Save();

            User model = UnitOfWork.GenericHandler<User>().GetAsQuerable(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
            if (!(model is null))
            {
                model.IsLogin = true;
                UnitOfWork.GenericHandler<User>().Update(model);
                UnitOfWork.Save();
            }

            return Task.FromResult(AutoMapper.Map<UserModel>(model));
        }

        public Task<UserModel> IsLogedInAsync()
        {
            User model = UnitOfWork.GenericHandler<User>().GetAsQuerable(x => x.IsLogin == true).FirstOrDefault();
            return Task.FromResult(AutoMapper.Map<UserModel>(model));
        }
        public Task<UserModel> LogOutAsync()
        {
            User model = UnitOfWork.GenericHandler<User>().GetAsQuerable(x => x.IsLogin == true).FirstOrDefault();
            model.IsLogin = false;
            UnitOfWork.GenericHandler<User>().Update(model);
            UnitOfWork.Save();

            return Task.FromResult(AutoMapper.Map<UserModel>(model));
        }

    }

    public interface ILoginService
    {
        Task<UserModel> IsLogedInAsync();
        Task<UserModel> LoginAsync(LoginRequest userModel);
        Task<UserModel> LogOutAsync();
    }
}
