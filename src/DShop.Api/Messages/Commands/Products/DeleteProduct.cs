using Newtonsoft.Json;
using System;
using DShop.Common.Messages;

namespace DShop.Api.Messages.Commands
{
    [MessageNamespace("products")]
	public class DeleteProduct : ICommand
	{
        public Guid Id { get; }

        [JsonConstructor]
        public DeleteProduct(Guid id)
        {
            Id = id;
        }
	}
}