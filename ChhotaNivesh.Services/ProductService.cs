using ChhotaNivesh.DBCore;
using ChhotaNivesh.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChhotaNivesh.Services
{
    public class ProductService : IProductService
    {        
        private IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAll() =>
            _productRepository.GetAll();

        public Task<Product> Get(string id) =>
            _productRepository.Get(id);

        public async Task<string> Create(Product product)
        {
            var productResponse = await _productRepository.Create(product);

            return productResponse.Id;
        }

        public Task<bool> Update(string id, Product product) =>
            _productRepository.Update(id, product);

    

        public Task Delete(string id) =>
            _productRepository.Delete(id);
    }
}
