﻿using DevFreela.Core.Entities;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task CreateUser(User user);
        Task<User> GetByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
