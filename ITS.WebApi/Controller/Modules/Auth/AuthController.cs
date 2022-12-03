using AutoWrapper.Wrappers;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ITS.WebApi.Controller.Modules.Auth
{
    [ApiController, Route("api/[controller]/[action]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactoryBussiness _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        public AuthController(UserManager<ApplicationUser> userManager, IJwtFactoryBussiness jwtFactory,
            IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Login(CredentialsViewModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _userManager.Users.Where(x => x.Email == credentials.Email).Select(x => x)
                .SingleOrDefault();

            //var userIdentity = _mapper.Map<ApplicationUser>(credentials);
            if (userIdentity == null)
            {
                ModelState.AddModelError("error", "User Or Password Not Currect");
                return BadRequest(ModelState);
            }
            if (!await _userManager.IsEmailConfirmedAsync(userIdentity))
            {
                ModelState.AddModelError("error", "Please Active Your Accounts!");
                return BadRequest(ModelState);
            }


            var identity = await GetClaimsIdentity(credentials.Email, credentials.Password);
            if (identity == null)
            {
                ModelState.AddModelError("login_failure", "Invalid username or password.");
                return BadRequest(ModelState);
            }

            var response = new
            {
                token = await _jwtFactory.GenerateEncodedToken(credentials.Email,identity, userIdentity.SiteCustomerId), //Todo: Search SitecustomerEmploye
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
                username = userIdentity.UserName,
                email = userIdentity.Email
                //companyName = companyInfo.Name,
                //logoId = companyInfo.LogoId
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {

                IList<string> Roles = await _userManager.GetRolesAsync(userToVerify);
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName,  Roles.FirstOrDefault()));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
