using System;
using Newtonsoft.Json;
using DShop.Common.Messages;

namespace DShop.Api.Messages.Commands
{
    public class DeleteProductFromCart : ICommand
    {
        public Guid CustomerId { get; }
        public Guid ProductId { get; }

        [JsonConstructor]
        public DeleteProductFromCart(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}