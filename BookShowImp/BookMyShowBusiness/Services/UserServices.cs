using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBusiness.Services
{
    public class UserServices
    {
        IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }
        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }
        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
        public User UserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
        public void Register(User user)
        {
            _userRepository.Register(user);
        }
        public User Login(User user)
        {
            return _userRepository.Login(user);
        }
    }
}
