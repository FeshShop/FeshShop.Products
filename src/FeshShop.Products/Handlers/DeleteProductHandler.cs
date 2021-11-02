﻿namespace FeshShop.Products.Handlers
{
    using FeshShop.Common.Mediator.Types;
    using FeshShop.Products.Dto;
    using FeshShop.Products.Repositories;
    using System;
    using System.Threading.Tasks;

    public class DeleteProductHandler : ICommandHandler<DeleteProductInputModel>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductHandler(IProductRepository productRepository) => this.productRepository = productRepository;

        public async Task HandleAsync(DeleteProductInputModel model)
        {
            if (!await this.productRepository.ExistsAsync(model.Id))
                throw new Exception($"Product with id: '{model.Id}' was not found.");

            await this.productRepository.DeleteAsync(model.Id);
        }
    }
}
