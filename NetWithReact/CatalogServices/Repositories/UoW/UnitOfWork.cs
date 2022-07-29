using CatalogServices.Repositories;

namespace CatalogServices.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICatalogItemRepository catalogItemRepository)
        {
            catalogItems = catalogItemRepository;
        }
        public ICatalogItemRepository catalogItems { get; set; }
    }
}
