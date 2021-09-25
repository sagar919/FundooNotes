
using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        IEnumerable<User> GetAll();
        User Get(long id);
        ResponseModel Login(LoginModel loginModel);
        bool Register(RegisterModel user);
       
        bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId);

        ResponseModel ForgotPassword(ForgotPasswordModel model);
        
      
    }
}
