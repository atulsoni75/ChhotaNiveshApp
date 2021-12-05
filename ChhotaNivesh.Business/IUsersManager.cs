using ChhotaNivesh.Models.Company;
using ChhotaNivesh.Models.Users;
using System.Threading.Tasks;

namespace ChhotaNivesh.Business
{
    public interface IUsersManager
    {
        Task<string> Register(RegisterModel registerModel);

        Task<UserInfoModel> Login(LoginModel loginModel);
    }
}
