﻿using HS12_BlogProject.Application.Models.DTOs;
using HS12_BlogProject.Domain.Entities;
using HS12_BlogProject.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS12_BlogProject.Application.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository; 

        private readonly SignInManager<AppUser> _signInManager; 
		private readonly UserManager<AppUser> _userManager;

        public AppUserService(IAppUserRepository appUserRepository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _appUserRepository = appUserRepository;
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public async Task<UpdateProfileDTO> GetByUserName(string userName) 
        {
			UpdateProfileDTO result = await _appUserRepository.GetFilteredFirstOrDefault(
				select: x => new UpdateProfileDTO 
                {
                    UserName = x.UserName, 
                    Id = x.Id,
                    Password = x.PasswordHash,
                    Email = x.Email,
					ImagePath = x.ImagePath,

                }, 
                where: x => x.UserName == userName 
                );

            return result; 
        }

        public async Task<SignInResult> Login(LoginDTO model) 
		{
            return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false , false); 
		}


        public async Task Logout()
        {
            await _signInManager.SignOutAsync(); 
		}
        public async Task<IdentityResult> Register(RegisterDTO model) 
		{
            AppUser user = new AppUser()
            {
                UserName = model.UserName, 
                Email = model.Email,
                CreateDate = model.CreateDate,

            };
            IdentityResult result = await _userManager.CreateAsync(user,model.Password);

            if(result.Succeeded) 
                _signInManager.SignInAsync(user,isPersistent:false); 

            return result;

        }
        public async Task UpdateUser(UpdateProfileDTO model) 

		{
			AppUser user = await _appUserRepository.GetDefault(x => x.Id == model.Id);

            if(model.Password !=null)
            {
				user.PasswordHash= _userManager.PasswordHasher.HashPassword(user, model.Password); 

				await _userManager.UpdateAsync(user); 
            }
            if(model.Email !=null) 
            {
                AppUser isUserEmailExits =await _userManager.FindByEmailAsync(model.Email);
				if (isUserEmailExits ==null) 
					await _userManager.SetEmailAsync(user,model.Email); 
            }
            
        }
    }
}
