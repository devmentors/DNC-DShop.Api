using Newtonsoft.Json;
using System;
using DShop.Common.Messages;

namespace DShop.Api.Messages.Commands
{
    [MessageNamespace("orders")]
    public class CompleteOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CompleteOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
