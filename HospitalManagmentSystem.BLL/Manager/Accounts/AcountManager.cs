using HospitalManagmentSystem.BLL.Dtos;
using HospitalManagmentSystem.BLL.Dtos.AccountDtos;
using HospitalManagmentSystem.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.BLL.Manager.Accounts
{
    public class AcountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AcountManager(UserManager<ApplicationUser> userManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<GeneralReposnse> Login(LoginDto loginDto)
        {
            GeneralReposnse generalReposnse = new GeneralReposnse();
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                return null;
            }
            var result =  await _userManager.CheckPasswordAsync(user,loginDto.Password);
            if(result==false)
            {
                return null;
            }
            var claims= await _userManager.GetClaimsAsync(user);
            generalReposnse = GenerateToken(claims);
            return generalReposnse;
        }

        public async Task<GeneralReposnse> Register(RegisterDto registerDto)
        {
            GeneralReposnse generalResponse = new GeneralReposnse();

            ApplicationUser user = new ApplicationUser();
            user.Email=registerDto.Email;
            user.UserName=registerDto.UserName;
            user.Address = "cario";

            IdentityResult result = await  _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded == false)
            {
                return null;
            }

            #region Claims
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim("Name", registerDto.UserName));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            #endregion
            await _userManager.AddClaimsAsync(user, claims);

            generalResponse = GenerateToken(claims);
            return generalResponse;
        }
        private GeneralReposnse GenerateToken(IList<Claim> claims)
        {
            //Generate token
            #region SecretKey
            var SecretKeyString = _configuration.GetSection("SecretKey").Value;
            var SecretKeyBytes = Encoding.ASCII.GetBytes(SecretKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(SecretKeyBytes);
            #endregion

            //Combind SecretKey , HasingAlgorithm
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.Now.AddDays(2);
            JwtSecurityToken jwtSecurity = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: expireDate
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(jwtSecurity);

            return new GeneralReposnse
            {
                Token = token,
                ExpireDate=expireDate
            };
        }
    }
}
