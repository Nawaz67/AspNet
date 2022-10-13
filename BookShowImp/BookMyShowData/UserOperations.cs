using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookMyShowData
{
    public class UserOperations
    {
        MovieDbContext db = null;
        public UserOperations(MovieDbContext db)
        {
            this.db = db;
        }   
        public string AddUser(User user)
        {
            db = new MovieDbContext();
            db.users.Add(user);
            db.SaveChanges();
            return "Added";
        }
        public string UpdateUser(User user)
        {
            db=new MovieDbContext();
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return "Updated";

        }
        public string DeleteUser(int userId)
        {
            User userObj=db.users.Find(userId);
            db.Entry(userObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "Deleted";

        }
        public List<User> ShowAllUsers()
        {
            db = new MovieDbContext();
            List<User> userList = db.users.ToList();
            return userList;
        }
    }
}
