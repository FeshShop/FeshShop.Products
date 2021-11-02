namespace FeshShop.Products.Dto
{
    using FeshShop.Common.Mediator.Types;
    using Newtonsoft.Json;
    using System;

    public class CreateProductInputModel : ICommand
    {
        [JsonConstructor]
        public CreateProductInputModel(Guid id, string name, string description, string vendor, decimal price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Vendor = vendor;
            this.Price = price;
            this.Quantity = quantity;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public string Vendor { get; }

        public decimal Price { get; }

        public int Quantity { get; }
    }
}
