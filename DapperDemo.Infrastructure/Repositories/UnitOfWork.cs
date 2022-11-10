using System;
using DapperDemo.Application.Interfaces;

namespace DapperDemo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            User = userRepository;
        }
        public IUserRepository User { get; set; }
    }
}

