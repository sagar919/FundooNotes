


using CommonLayer.Model;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        ResponseModel Get(LoginModel loginModel);
        bool Add(RegisterModel user);
        bool Add(LoginModel loginModel);
        bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId);
    }
}
