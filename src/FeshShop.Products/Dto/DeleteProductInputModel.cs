namespace FeshShop.Products.Dto
{
    using FeshShop.Common.Mediator.Types;
    using System;

    public class DeleteProductInputModel : ICommand
    {
        public Guid Id { get; set; }
    }
}
