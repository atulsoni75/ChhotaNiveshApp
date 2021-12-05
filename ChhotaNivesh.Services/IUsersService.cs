using ChhotaNivesh.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAll();

        Task<Users> Get(string id);

        Task<Users> Create(Users users);

        Task<bool> Update(string id, Users users);

        Task Delete(string id);

    }
}
