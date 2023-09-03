namespace Product_CRUD_API.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetSingleProduct(int id);
        Task<List<Product>> CreateProduct(Product request);
        Task<List<Product>?> UpdateProduct(int id, Product request);
        Task<List<Product>?> DeleteProduct(int id);
    }
}
