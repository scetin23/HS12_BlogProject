using HS12_BlogProject.Application.Models.DTOs;
using Microsoft.AspNetCore.Identity;


namespace HS12_BlogProject.Application.Services.AppUserService
{
    public interface IAppUserService 
    {
        Task<IdentityResult> Register(RegisterDTO model);
        Task<SignInResult> Login(LoginDTO model); 
        Task<UpdateProfileDTO> GetByUserName(string userName);
        Task UpdateUser(UpdateProfileDTO model); 
        Task Logout(); 
    }
}
