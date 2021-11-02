namespace FeshShop.Products.Handlers
{
    using FeshShop.Common.Mediator.Types;
    using FeshShop.Products.Dto;
    using FeshShop.Products.Repositories;
    using Mapster;
    using System.Threading.Tasks;

    public sealed class GetProductHandler : IQueryHandler<GetProductInputModel, GetProductViewModel>
    {
        private readonly IProductRepository productRepository;

        public GetProductHandler(IProductRepository productRepository) => this.productRepository = productRepository;

        public async Task<GetProductViewModel> HandleAsync(GetProductInputModel model)
        {
            var product = await this.productRepository.GetByIdAsync(model.Id);

            return product?.Adapt<GetProductViewModel>();
        }
    }
}
