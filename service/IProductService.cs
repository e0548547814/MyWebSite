using Entity;

namespace service
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
    }
}