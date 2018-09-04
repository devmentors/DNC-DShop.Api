using Newtonsoft.Json;
using System;
using DShop.Common.Messages;

namespace DShop.Api.Messages.Commands
{
    [MessageNamespace("orders")]
    public class CancelOrder : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }

        [JsonConstructor]
        public CancelOrder(Guid id, Guid customerId)
        {
            Id = id;
            CustomerId = customerId;
        }
    }
}
