using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData.Repository
{
    public class UserRepository : IUserRepository
    {
        MovieDbContext _movieDbContext;
        public UserRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void AddUser(User user)
        {
            _movieDbContext.users.Add(user);
            _movieDbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _movieDbContext.users.Find(userId);
            _movieDbContext.users.Remove(user);
            _movieDbContext.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _movieDbContext.users.ToList();
        }

        public void UpdateUser(User user)
        {
            _movieDbContext.Entry(user).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            return _movieDbContext.users.Find(userId);
        }
        public User Login(User user)
        {
            User user1=null;
            var result=_movieDbContext.users.Where(obj => obj.Email == user.Email && obj.Phone == user.Phone).ToList();
            if (result.Count > 0)
            {
                user1 = result[0];
            }
            return user1;
        }

        public void Register(User user)
        {
            _movieDbContext.users.Add(user);
            _movieDbContext.SaveChanges();
        }
    }
}
