using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Interface
{
    public interface IUserBL
    {
        IEnumerable<User> GetAll();

        User Get(long id);
        ResponseModel Get(LoginModel loginModel);

        bool Add(RegisterModel user);
        bool Add(LoginModel loginModel);
        bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId);
    }
}
