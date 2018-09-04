using System;
using Newtonsoft.Json;
using DShop.Common.Messages;

namespace DShop.Api.Messages.Commands
{
    [MessageNamespace("customers")]
    public class ClearCart : ICommand
    {
        public Guid CustomerId { get; }

        [JsonConstructor]
        public ClearCart(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}