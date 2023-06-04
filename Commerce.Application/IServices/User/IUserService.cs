using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Application.Dtos;

namespace Commerce.Application.IServices.User
{
    public interface IUserService
    {
        public Task AddUser(CreateUserDto user);
    }
}