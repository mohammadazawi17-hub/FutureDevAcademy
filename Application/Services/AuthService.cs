using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly IUnitOfWork _uow;
        private readonly IJwtTokenGenerator _jwt;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(
            IUserRepository users,
            IUnitOfWork uow,
            IJwtTokenGenerator jwt,
            IPasswordHasher<User> passwordHasher)
        {
            _users = users;
            _uow = uow;
            _jwt = jwt;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> RegisterStudentAsync(RegisterStudentDto dto)
        {
            if (await _users.GetByEmailAsync(dto.Email) != null)
                return Result.Fail("Email already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth,
                Role = UserRole.Student,
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            await _users.AddAsync(user);
            await _uow.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result<string>> LoginAsync(LoginDto dto)
        {
            var user = await _users.GetByEmailAsync(dto.Email);

            if (user == null)
                return Result<string>.Fail("Invalid credentials");

            var verifyResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (verifyResult != PasswordVerificationResult.Success)
                return Result<string>.Fail("Invalid credentials");

            var token = _jwt.Generate(user);
            return Result<string>.Ok(token);
        }
    }
}
