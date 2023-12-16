﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceProject.Application.Abstraction.Services;
using ECommerceProject.Application.Abstraction.Token;
using ECommerceProject.Application.DTOs;
using ECommerceProject.Domain.Concrete;
using ECommerceProject.Domain.Ultilities.Results;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Persistence.Services
{
    public class AuthService: IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;
        

        public AuthService(ITokenHandler tokenHandler, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            AppUser? user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                return new ErrorResult("Kullanıcı bulunamadı!");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded) //Authentication başarılı!
            {
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                
                return new SuccessDataResult<Token>(token,"Token Gönderildi.");
            }
            return new ErrorResult("Kullanıcı adı veya şifre hatalı!");
        }

    }
}
