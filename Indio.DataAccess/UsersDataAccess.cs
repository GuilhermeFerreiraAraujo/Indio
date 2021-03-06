﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Indio.DataAccess.Contracts;
using Indio.Models;
using Indio.Models.Models;
using Indio.Models.Requests;
using Indio.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Indio.DataAccess
{
    public class UsersDataAccess : IUsersDataAccess
    {
        private readonly IndioContext _context;

        public UsersDataAccess(IndioContext context)
        {
            _context = context;
        }

        public List<User> Get()
        {
            return _context.Set<User>().ToList();
        }

        public User GetLoginUser(string email, string password)
        {
            password = GetHashPassword(password);
            return _context.Set<User>()
                .Include(x => x.UserPermissions)
                    .ThenInclude(x => x.Permission)
                .FirstOrDefault(x => x.Email == email && x.Password == password);

        }

        public SignUpResponse SignUpUser(SignUpRequest request)
        {
            var errors = new List<string>();

            var user = _context.Set<User>().FirstOrDefault(x => x.Email == request.Email);

            if (user != null)
            {
                errors.Add("The selected email is already in use.");
            } else
            {
                user = new User
                {
                    Email = request.Email,
                    Name = request.Name,
                    Password = GetHashPassword(request.Password)
                };
            }

            if (errors.Count == 0)
            {
                _context.Add(user);
                _context.SaveChanges();
                return new SignUpResponse { IsRequestCompleted = true };
            }

            return new SignUpResponse { IsRequestCompleted = false, Errors = errors };
        }

        private string GetHashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();  
                return hash;
            }
        }
    }
}
