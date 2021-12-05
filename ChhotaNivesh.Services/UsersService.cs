using ChhotaNivesh.DBCore;
using ChhotaNivesh.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public class UsersService : IUsersService
    {        
        private IRepository<Users> _usersRepository;

        public UsersService(IRepository<Users> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IEnumerable<Users>> GetAll() =>
            _usersRepository.GetAll();

        public Task<Users> Get(string id) =>
            _usersRepository.Get(id);

        public Task<Users> Create(Users users) =>
            _usersRepository.Create(users);

        public Task<bool> Update(string id, Users users) =>
            _usersRepository.Update(id, users);

        public Task Delete(string id) =>
            _usersRepository.Delete(id);

   
    }
}
