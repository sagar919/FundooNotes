
using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        readonly UserContext _userContext;
        public UserRL(UserContext context)
        {
            _userContext = context;
        }
        public bool Add(RegisterModel user)
        {
            User userEntity = new User();
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            userEntity.CreatedAt = DateTime.Now;
            _userContext.Users.Add(userEntity);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add(LoginModel loginModel)
        {
            User userEntity = new User();

            userEntity.Email = loginModel.Email;
            userEntity.Password = loginModel.Password;

            _userContext.Users.Add(userEntity);
            int result = _userContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public void Delete(User user)
        //{
        //    _userContext.Users.Remove(user);
        //    _userContext.SaveChanges();
        //}

        public User Get(long id)
        {
            return _userContext.Users.FirstOrDefault(e => e.UserId == id);
        }

        public ResponseModel Get(LoginModel loginModel)
        {

            try
            {
                User user = _userContext.Users.FirstOrDefault(e => e.Email == loginModel.Email && e.Password == loginModel.Password);
                ResponseModel responseModel = new ResponseModel()
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                };
                return responseModel;
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public IEnumerable<User> GetAll()
        {
            return _userContext.Users.ToList();
        }

        public bool ResetPassword(ResetPasswordModel resetPasswordModel, long userId)
        {
            User user = _userContext.Users.FirstOrDefault(e => e.UserId == userId);

            try
            {

                user.Password = resetPasswordModel.newPassword;
                _userContext.Users.Update(user);
                int result = _userContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public void Update(User user, User user1)
        //{
        //    user.FirstName = user1.FirstName;
        //    user.LastName = user1.LastName;
        //    user.Email = user1.Email;
        //    user.Password = user1.Password;
        //    user.CreatedAt = user1.CreatedAt;
        //    user.ModifiedAt = user1.ModifiedAt;
        //    _userContext.SaveChanges();
        //}
    }
}
