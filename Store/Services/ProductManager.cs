using Repositories.Contracts;
using Services.Contracts;
using Store.Entities.Models;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager repositoryManager)
        {
            _manager = repositoryManager;
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
           return _manager.Product.GetAllProducts(trackChanges);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);
            if (product is null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }
    }
}
