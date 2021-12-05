using ChhotaNivesh.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> Get(string id);

        Task<string> Create(Product product);

        Task<bool> Update(string id, Product product);


        Task Delete(string id);

    }
}
