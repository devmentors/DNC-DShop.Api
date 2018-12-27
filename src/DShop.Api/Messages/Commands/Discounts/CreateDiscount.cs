using System;
using DShop.Common.Messages;
using Newtonsoft.Json;

namespace DShop.Api.Messages.Commands.Discounts
{
    [MessageNamespace("discounts")]
    public class CreateDiscount : ICommand
    {
        public Guid Id { get; }
        public Guid CustomerId { get; }
        public string Code { get; }
        public double Percentage { get; }

        [JsonConstructor]
        public CreateDiscount(Guid id, Guid customerId,
            string code, double percentage)
        {
            Id = id;
            CustomerId = customerId;
            Code = code;
            Percentage = percentage;
        }
    }
}