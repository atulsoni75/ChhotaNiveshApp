using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ChhotaNivesh.Business;
using ChhotaNivesh.Common.Models;
using ChhotaNivesh.Models;
using ChhotaNivesh.Models.Users;
using ChhotaNivesh.Services;
using ChhotaNiveshToolApp.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChhotaNiveshToolApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _userManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly AppSettings _appSettings;
        private readonly IUsersService _userService;

        public UsersController(IUsersManager userManager,
            IAuthenticationService authenticationService, IOptions<AppSettings> appSettings, IUsersService userService)
        {
            _userManager = userManager;
            _authenticationService = authenticationService;
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ResultModel> Register(RegisterModel registerModel)
        {
            try
            {
                var response = await _userManager.Register(registerModel);

                if (!string.IsNullOrEmpty(response))
                {

                    return new ResultModel()
                    {
                        Result = response,
                        Message = "Registration completed successfully.",
                        Status = StatusCodes.Status200OK
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Result = string.Empty,
                        Message = "Something went wrong. Please try again.",
                        Status = StatusCodes.Status204NoContent
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Result = string.Empty,
                    Message = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                };
            }
        }

        [HttpPost("Login")]
        public async Task<ResultModel> Login(LoginModel loginModel)
        {
            try
            {
                var response = await _userManager.Login(loginModel);

                if (response != null && !string.IsNullOrEmpty(response.Id))
                {
                    // Authenticate
                    response.Token = _authenticationService.Authenticate(response.UserId,response.Id);

                    return new ResultModel()
                    {
                        Result = response,
                        Message = "Login completed successfully.",
                        Status = StatusCodes.Status200OK
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Result = string.Empty,
                        Message = "Something went wrong. Please try again.",
                        Status = StatusCodes.Status204NoContent
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Result = string.Empty,
                    Message = ex.Message,
                    Status = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
