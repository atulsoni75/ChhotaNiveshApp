using ChhotaNivesh.Models.Company;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAll();

        Task<Company> Get(string id);

        Task<Company> Create(Company company);

        Task<bool> Update(string id, Company company);


        Task Delete(string id);

    }
}
