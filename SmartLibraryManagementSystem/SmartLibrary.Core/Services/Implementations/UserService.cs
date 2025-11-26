using SmartLibrary.Core.DTOs.Users;
using SmartLibrary.Core.Entities;
using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepo.GetAllAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                BorrowLimit = u.BorrowLimit,
                UserType = u.UserType
            }).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                BorrowLimit = user.BorrowLimit,
                UserType = user.UserType
            };
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            int borrowLimit = dto.UserType == "Student" ? 3 : 5;

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                BorrowLimit = borrowLimit,
                UserType = dto.UserType
            };

            await _userRepo.AddAsync(user);

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                BorrowLimit = borrowLimit,
                UserType = user.UserType
            };
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            user.FullName = dto.FullName;
            user.Email = dto.Email;

            await _userRepo.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepo.DeleteAsync(user.Id);
            return true;
        }
    }
}
