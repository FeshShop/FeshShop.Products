namespace FeshShop.Products.Services
{
    using FeshShop.Products.Domain;
    using FeshShop.Products.Dto;
    using FeshShop.Products.Repositories;
    using Mapster;
    using System;
    using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository) => this.productRepository = productRepository;

        public async Task<GetProductViewModel> GetProductByIdAsync(Guid id)
        {
            var product = await this.productRepository.GetByIdAsync(id);

            return product?.Adapt<GetProductViewModel>();
        }

        public async Task CreateProductAsync(CreateProductInputModel model)
        {
            if (model.Quantity < 0)
            {
                throw new Exception("Product quantity cannot be negative.");
            }

            if (await this.productRepository.ExistsAsync(model.Name))
            {
                throw new Exception($"Product: '{model.Name}' already exists.");
            }

            var product = new Product(model.Id, model.Name, model.Description, model.Vendor, model.Price, model.Quantity);
            await productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Guid id, UpdateProductInputModel model)
        {
            var product = await this.productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new Exception($"Product with id: '{id}' was not found.");
            }

            product.SetName(model.Name);
            product.SetDescription(model.Description);
            product.SetVendor(model.Vendor);
            product.SetPrice(model.Price);
            product.SetQuantity(model.Quantity);

            await this.productRepository.UpdateAsync(product);
        }
    }
}
