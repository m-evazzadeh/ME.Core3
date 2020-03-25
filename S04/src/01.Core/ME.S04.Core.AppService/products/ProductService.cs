using ME.S04.Core.Contract;
using ME.S04.Core.Contract.products;
using ME.S04.Core.DomainModel.products.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Core.AppService.products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ProductDTO Add(ProductDTO productInput)
        {
            return unitOfWork.ProductRepo.Add(productInput);
        }

        public ProductDTO Get(int id)
        {
            return unitOfWork.ProductRepo.Get(id);
        }
    }
}
