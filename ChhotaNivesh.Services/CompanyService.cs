using MongoDB.Driver;
using ChhotaNivesh.DBCore;
using ChhotaNivesh.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public class CompanyService : ICompanyService
    {
        private IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<IEnumerable<Company>> GetAll() =>
            _companyRepository.GetAll();

        public Task<Company> Get(string id) =>
            _companyRepository.Get(id);

        public Task<Company> Create(Company company) =>
            _companyRepository.Create(company);

        public Task<bool> Update(string id, Company company) =>
            _companyRepository.Update(id, company);

      

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
