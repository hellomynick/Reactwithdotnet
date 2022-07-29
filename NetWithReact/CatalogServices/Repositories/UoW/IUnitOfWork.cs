using CatalogServices.Repositories.UoW;

namespace CatalogServices.Repositories.UoW
{
    public interface IUnitOfWork
    {
        ICatalogItemRepository catalogItems { get; set; }
    }
}
