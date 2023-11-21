using Cain.Jawbone.Infra.Data.Contexts.Interfaces;
using Cain.Jawbone.Domain;
using Microsoft.Azure.Cosmos;

namespace Cain.Jawbone.Infra.Data.Contexts
{
    public class PageContext : CosmosDbContext<Page>, IPageContext
    {
        public const string DatabaseId = "CainJawbone";
        public const string ContainerId = "Page";
        public const string KeyPath = "/id";

        public PageContext(CosmosClient client) : base(client.GetContainer(DatabaseId, ContainerId))
        {
        }
    }
}
