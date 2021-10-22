namespace FeshShop.Products.Repositories
{
    using FeshShop.Products.Domain;
    using System;
    using System.Threading.Tasks;

    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);

        Task AddAsync(Product product);

        Task<bool> ExistsAsync(string name);

        Task UpdateAsync(Product product);
    }
}
