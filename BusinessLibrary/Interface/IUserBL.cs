using CommonLayer.Model;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary.Interface
{
    public interface IUserBL
    {
        IEnumerable<User> GetAll();

        User Get(long id);

        ResponseModel Login(LoginModel loginModel);

        bool Register(RegisterModel user);

        

        bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId);

        ResponseModel ForgotPassword(ForgotPasswordModel model);

        
    }

    
}
