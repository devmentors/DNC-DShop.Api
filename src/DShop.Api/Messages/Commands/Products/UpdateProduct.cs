using System;
using DShop.Common.Messages;
using Newtonsoft.Json;

namespace DShop.Api.Messages.Commands.Products
{
    [MessageNamespace("products")]
    public class UpdateProduct : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }

        [JsonConstructor]
        public UpdateProduct(Guid id, string name,
            string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}