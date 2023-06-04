using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Application.Dtos;
using Commerce.Application.IServices.User;
using Commerce.Domain.Core.UserBoundedContext.IRepository;
using Commerce.Infrastructure.Pattern;

namespace Commerce.Application.Services.User
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _UnitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _UnitOfWork = unitOfWork;
        }

        public async Task AddUser(CreateUserDto userDto)
        {
            var userEntity = Commerce.Domain.Core.UserBoundedContext.User.createUser(
                userDto.Email, userDto.Password, userDto.Password, userDto.IsAdmin
              );
          await  _userRepository.AddUser(userEntity);
           await _UnitOfWork.SaveChanges();


        }


    }
}