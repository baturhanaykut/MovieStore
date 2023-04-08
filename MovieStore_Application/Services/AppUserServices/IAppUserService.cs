using Microsoft.AspNetCore.Identity;
using MovieStore_Application.Models.DTOs.AppUserDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Services.AppUserServices
{
    public interface IAppUserService
    {
        Task<IdentityResult> Register(RegisterDTO model);

        Task<SignInResult> Login(LoginDTO model);

        Task<UpdateProfileDTO> GetByUserName(string userName);

        Task UpdateUser(UpdateProfileDTO model);

        Task LogOut();
    }
}
