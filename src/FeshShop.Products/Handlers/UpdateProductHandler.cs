namespace FeshShop.Products.Handlers
{
    using FeshShop.Common.Mediator.Types;
    using FeshShop.Products.Dto;
    using FeshShop.Products.Repositories;
    using System;
    using System.Threading.Tasks;

    public sealed class UpdateProductHandler : ICommandHandler<UpdateProductInputModel>
    {
        private readonly IProductRepository productRepository;

        public UpdateProductHandler(IProductRepository productRepository) => this.productRepository = productRepository;

        public async Task HandleAsync(UpdateProductInputModel model)
        {
            var product = await this.productRepository.GetByIdAsync(model.Id);

            if (product == null)
                throw new Exception($"Product with id: '{model.Id}' was not found.");

            product.SetName(model.Name);
            product.SetDescription(model.Description);
            product.SetVendor(model.Vendor);
            product.SetPrice(model.Price);
            product.SetQuantity(model.Quantity);

            await this.productRepository.UpdateAsync(product);
        }
    }
}
