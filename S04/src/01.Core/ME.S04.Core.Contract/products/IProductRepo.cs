using ME.S04.Core.DomainModel.products.DTO;

namespace ME.S04.Core.Contract.products
{
    public interface IProductRepo : IRepo
    {
        ProductDTO Add(ProductDTO productInput);
    }
}
