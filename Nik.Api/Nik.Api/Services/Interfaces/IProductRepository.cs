using Nik.Api.Models;

namespace Nik.Api.Services.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> getAllAsync();
        Task<Product> getByIdAsync(int id);
        Task deleteProduct(int id);
        Task putProduct(int id, Product product);
        Task<Product> postProduct(Product product);
    }
}
