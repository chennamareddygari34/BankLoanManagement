﻿using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;

namespace BankLoanManagement.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly BankLoanApplicationContext _context;

        public UserRepository(BankLoanApplicationContext context)
        {
            _context = context;
        }
        public User Add(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
            return item;
        }

        public User Delete(string key)
        {
            var user = Get(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return null;
        }

        public User Get(string key)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == key);
            return user;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(User item)
        {
            _context.Entry<User>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
