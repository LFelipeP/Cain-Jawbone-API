using Cain.Jawbone.Infra.Data.Contexts.Interfaces;
using cain_jawbone_domains;
using Microsoft.Azure.Cosmos;

namespace Cain.Jawbone.Infra.Data.Contexts
{
    public class PageContext : CosmosDbContext<Page>, IPageContext
    {
        public const string DatabaseId = "Cache";
        public const string ContainerId = "Passengers";
        public const string KeyPath = "/Id";

        public PageContext(CosmosClient client) : base(client.GetContainer(DatabaseId, ContainerId))
        {
        }
    }
}
