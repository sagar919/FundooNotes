using BusinessLibrary.Interface;
using CommonLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.Services
{
    public class UserBL : IUserBL
    {
        private IUserRL _userRL;
        public UserBL(IUserRL userRL)
        {
            this._userRL = userRL;
        }

        public bool Add(RegisterModel user)
        {
            try
            {
                return this._userRL.Add(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Add(LoginModel loginModel)
        {
            try
            {
                return this._userRL.Add(loginModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Get(long id)
        {
            try
            {
                return this._userRL.Get(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ResponseModel Get(LoginModel loginModel)
        {
            try
            {
                return this._userRL.Get(loginModel);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return this._userRL.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId)
        {
            try
            {
                return this._userRL.ResetPassword(resetPasswordModel, userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
