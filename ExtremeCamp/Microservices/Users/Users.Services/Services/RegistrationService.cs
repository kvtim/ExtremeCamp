﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Core.Models;
using Users.Core.Security;
using Users.Core.Services;
using Users.Core.UnitOfWork;
using Users.Core.Dtos.User;
using Users.Core.ErrorHandling;

namespace Users.Services.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTTokenService _tokenService;
        private readonly IHasher _hasher;
        private readonly IMapper _mapper;

        public RegistrationService(
            IUnitOfWork unitOfWork,
            IJWTTokenService tokenService,
            IHasher hasher,
            IMapper mapper
        )
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _hasher = hasher;
            _mapper = mapper;
        }

        public async Task<Result<JWTToken>> Registration(RegisterUserDto registerUserDto)
        {
            var user = await _unitOfWork.UserRepository.GetByUserNameAsync(registerUserDto.UserName);

            if (user != null)
            {
                return Result.Failure(ErrorType.BadRequest, "User already exists");
            }

            user = _mapper.Map<User>(registerUserDto);
            user.Password = _hasher.Hash(user.Password);

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            return Result.Ok(await _tokenService.CreateToken(user));
        }
    }
}
