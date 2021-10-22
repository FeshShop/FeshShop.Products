namespace FeshShop.Products.Services
{
    using FeshShop.Products.Dto;
    using System;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<GetProductViewModel> GetProductByIdAsync(Guid id);

        Task CreateProductAsync(CreateProductInputModel model);

        Task UpdateProductAsync(Guid id, UpdateProductInputModel model);
    }
}
