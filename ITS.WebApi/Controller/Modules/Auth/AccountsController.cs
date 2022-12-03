using ITS.Repository.Implements.Identity;
using ITS.WebApi.Controller.Modules.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.WebApi.Controller.Modules.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountsController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }


        // POST api/accounts
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FullName=model.FullName,
                RegisterDate = DateTime.Now,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userIdentity, "Guest");



                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
                //var callbackUrl = Url.Action(
                //    "ConfirmEmail",
                //    "Accounts",
                //    new { userId = userIdentity.Id, code = code },
                //    protocol: HttpContext.Request.Scheme);
                //EmailService emailService = new EmailService();
                //await emailService.SendEmailAsync(model.Email, "Confirm your account",
                //    $"Please click in link for activation your accounts: <a href='{callbackUrl}'>link</a>");
            }


            if (!result.Succeeded)
            {
                //return Ok(result);
                return GetErrorResult(result);

            }

            return Ok(result);
            return new OkObjectResult("Account created");
        }


        protected IActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return BadRequest();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        [Route("users/{id:guid}/roles")]
        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AssignRolesToUser(string id, string[] rolesToAssign)
        {
            if (rolesToAssign == null)
            {
                return this.BadRequest("No roles specified");
            }

            ///find the user we want to assign roles to
            var appUser = await this._userManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var userIdentity = _userManager.Users.Where(x => x.Id == id).Select(x => x).SingleOrDefault();

            ///check if the user currently has any roles
            var currentRoles = await this._userManager.GetRolesAsync(userIdentity);


            var rolesNotExist = rolesToAssign.Except(_roleManager.Roles.Select(x => x.Name)).ToArray();


            if (rolesNotExist.Count() > 0)
            {
                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExist)));
                return this.BadRequest(ModelState);
            }

            ///remove user from current roles, if any
            IdentityResult removeResult = await this._userManager.RemoveFromRolesAsync(userIdentity, currentRoles.ToArray());


            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            ///assign user to the new roles
            IdentityResult addResult = await this._userManager.AddToRolesAsync(userIdentity, rolesToAssign);


            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok(new { userId = id, rolesAssigned = rolesToAssign });
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            //code = HttpUtility.UrlDecode(code);

            if (userId == null || code == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            //return View(result.Succeeded ? "ConfirmEmail" : "Error");
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("IsAuthorized")]
        public async Task<ActionResult> IsAuthorized()
        {
            return Ok(true);
        }

       
    }
}
