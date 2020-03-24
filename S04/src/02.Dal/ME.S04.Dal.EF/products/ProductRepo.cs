using ME.S04.Core.Contract.products;
using ME.S04.Core.DomainModel.products;
using ME.S04.Core.DomainModel.products.DTO;

namespace ME.S04.Dal.EF.products
{
    class ProductRepo : IProductRepo
    {
        private readonly DbContextS04 ctx;

        public ProductRepo(DbContextS04 dbContextS04)
        {
            ctx = dbContextS04;
        }

        public ProductDTO Add(ProductDTO productInput)
        {
            var entry = ctx.Products.Add(new Product { Name = productInput.Name});
            productInput.ProductId = entry.Entity.ProductId;
            return productInput;
        }
    }
}
