using FeshShop.Common.Mongo.Contracts;
using FeshShop.Products.Domain;
using System;
using System.Threading.Tasks;

namespace FeshShop.Products.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoRepository<Product> mongoRepository;

        public ProductRepository(IMongoRepository<Product> mongoRepository) => this.mongoRepository = mongoRepository;

        public async Task<Product> GetByIdAsync(Guid id) => await this.mongoRepository.GetByIdAsync(id);

        public async Task AddAsync(Product product) => await this.mongoRepository.AddAsync(product);

        public async Task UpdateAsync(Product product) => await this.mongoRepository.UpdateAsync(product);

        public async Task<bool> ExistsAsync(string name) 
            => await this.mongoRepository.ExistsAsync(p => p.Name == name.ToLowerInvariant());
    }
}
