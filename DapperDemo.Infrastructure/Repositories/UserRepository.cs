using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperDemo.Application.Interfaces;
using DapperDemo.Core.Entities;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;

namespace DapperDemo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> Add(User entity)
        {
            var sql = "INSERT INTO Usuario (UserEmail, UserPassword, UserName, UserLastName, UserDNI, UserAge) VALUES (@UserEmail, @UserPassword, @UserName, @UserLastName, @UserDNI, @UserAge);";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Usuario WHERE id = @id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { id = id});
                return affectedRows;
            }
        }

        public async Task<User> Get(int id)
        {
            var sql = "SELECT * FROM Usuario WHERE id = @id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql, new { id = id });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = "SELECT * FROM Usuario;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result;
            }
        }

        public async Task<int> Update(User entity)
        {
            var sql = "UPDATE Usuario SET UserEmail = @UserEmail, UserPassword = @UserPassword, UserName = @UserName, UserLastName = @UserLastName, UserDNI = @UserDNI, UserAge = @UserAge WHERE id = @id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql,entity);
                return affectedRows;
            }
        }
    }
}

