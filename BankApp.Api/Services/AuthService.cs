using BankAccountCore;
using BankApp.Api.DTOs;
using BankApp.Api.Interfaces;
using BankApp.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BankApp.Api.Services
{
    public class AuthService : Interfaces.IAuthService
    {

        private readonly IBankAccountRepository _repository;
        private readonly IAccountNumberGenerator _generator;

        public AuthService(IBankAccountRepository repository, IAccountNumberGenerator generator)
        {
            _repository = repository;
            _generator = generator;
        }
        public async Task<string> Login(LoginDto dto)
        {
            var username = dto.UserName;
            var user = await _repository.GetByUsernameAsync(username);
            if (user == null)
            {
                throw new Exception();
            }
            var password = dto.Password;
            var hashedPassword = user.Password;
            bool isValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            if (!isValid)
            {
                throw new InvalidCredentialsException();
            }
           
            return "Password ok";
        }

        public async Task Register(RegisterDto dto)
        {
            var username = dto.UserName;
            var user = await _repository.GetByUsernameAsync(username);
            if (user != null)
            {
                throw new UserAlreadyExistsException();
            }
            var password = dto.Password;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var accountNumber = _generator.Generate();
            var newUser = new BankAccountEntity
            {
                UserName = dto.UserName,
                OwnerName = dto.OwnerName,
                Password = passwordHash,
                AccountNumber = accountNumber
            };
            await _repository.CreateAsync(newUser);
        }
    }
}

