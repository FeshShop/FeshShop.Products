namespace FeshShop.Products.Dto
{
    using FeshShop.Common.Mediator.Types;
    using System;

    public class GetProductInputModel : IQuery<GetProductViewModel>
    {
        public Guid Id { get; set; }
    }
}
