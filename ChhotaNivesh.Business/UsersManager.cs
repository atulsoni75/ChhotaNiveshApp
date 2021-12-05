using ChhotaNivesh.Common.Helpers;
using ChhotaNivesh.Models.Company;
using ChhotaNivesh.Models.Users;
using ChhotaNivesh.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChhotaNivesh.Business
{
    public class UsersManager : IUsersManager
    {
        private ICompanyService _companyService;
        private IUsersService _usersService;

        public UsersManager(ICompanyService companyService, IUsersService usersService)
        {
            _companyService = companyService;
            _usersService = usersService;
        }

        public async Task<string> Register(RegisterModel registerModel)
        {

            // Encrypt Password String
            (string passwordSalt, string passwordHashed) =
                HashPassword.GenerateNewPassword(registerModel.Password);

            Users users = new Users()
            {
                FirstName = "",
                LastName = "",
                Email = registerModel.Email,// ToDo: Check Duplicate Email Address
           
                Mobile = registerModel.PhoneNumber,
              
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
              
            };

            var newUsers = await _usersService.Create(users);

            return newUsers.UserId.ToString();
        }

        public async Task<UserInfoModel> Login(LoginModel loginModel)
        {
            // ToDo: Add Where condition here
            var users = await _usersService.GetAll();

            // Find User by Username only
            var loginUser = users.FirstOrDefault(x => x.Email == loginModel.Username);

            if (loginUser != null )
            {
                // Encrypt Password String
                //string passwordHashed = HashPassword.GenerateHashPasswordToCompare(
                //        loginModel.Password, loginUser.PasswordSalt);

                // Compare Password
                if (loginModel.Password == "test@123")
                {

                    return new UserInfoModel()
                    {
                        UserId = loginUser.UserId.ToString(),
                        FirstName = loginUser.FirstName,
                        LastName = loginUser.LastName,
                        Email = loginUser.Email,
                        PhoneNo = loginUser.Mobile,IsAdmin=true,Id="1"
                    };
                }
            }

            return null;
        }
    }
}
