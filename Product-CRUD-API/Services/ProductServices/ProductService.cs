namespace Product_CRUD_API.Services.ProductServices
{
    public class ProductService : IProductService
    {

        //private static List<Product> products = new List<Product>
        //{
        //    new Product
        //    {
        //        TenantId = 10,
        //        Name = "Product 01",
        //        Description = "Product 01 description",
        //        IsAvailabe = false,
        //        Id = 22,
        //    },
        //    new Product
        //    {
        //        TenantId = 10,
        //        Name = "Product 02",
        //        Description = "Product 02 description",
        //        IsAvailabe = false,
        //        Id = 23,
        //    }
        //};

        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>?> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product is null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>?> UpdateProduct(int id, Product request)
        {
            var product = await _context.Products.FindAsync(id); 

            if (product is null)
            {
                return null;
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.IsAvailabe = request.IsAvailabe;
            product.TenantId = request.TenantId;

            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }
    }
}
