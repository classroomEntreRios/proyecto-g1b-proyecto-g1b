﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes365RestApi.Dtos;
using Viajes365RestApi.Entities;
using Viajes365RestApi.Helpers;
using Viajes365RestApi.Services;

namespace Viajes365RestApi.Builders
{
    public class DataContextSeedData
    {
        private DataContext _context;
        private IUserService _userService;
        IMapper _mapper;

        public DataContextSeedData(DataContext context, IUserService userService, IMapper mapper)
        {
            _context = context;
            _userService = userService;
            _mapper = mapper;
        }

        public void SeedUsers()
        {
            SeedAdminUserAsync().Wait();
            SeedFirstUserAsync().Wait();
        }

        private async Task SeedAdminUserAsync()
        {

            if (!_context.Users.Any(u => u.UserName == "admin"))
            {
                var admin = new UserRegisterDto
                {
                    FirstName = "Admin",
                    LastName = "Modo Dios",
                    UserName = "admin",
                    Email = "admin@viajes365.com",
                    Password = "admin",
                    TermsAndConditionsChecked = true,
                    PhotoId = 1L

                };
                // RoleId 2L is Administrador
                User adm = await _userService.Create(_mapper.Map<User>(admin), admin.Password, 2L);
            }
        }

        private async Task SeedFirstUserAsync()
        {
            if (!_context.Users.Any(u => u.UserName == "user"))
            {
                var user = new UserRegisterDto
                {
                    FirstName = "Fulano",
                    LastName = "DeTal",
                    UserName = "user",
                    Email = "user@viajes365.com",
                    Password = "user",
                    TermsAndConditionsChecked = true,
                    PhotoId = 2L
                };
                // RoleId 1L is Usuario
                await _userService.Create(_mapper.Map<User>(user), user.Password, 1L);
            }
        }
    }
}
