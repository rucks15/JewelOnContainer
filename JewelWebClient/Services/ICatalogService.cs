using JewelWebClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace JewelWebClient.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<SelectListItem>> GetBrandsAsync();
        Task<IEnumerable<SelectListItem>> GetTypesAsync();
        Task<Catalog> GetCatalogItemAsync(int page, int size, int? brand, int? type);
    }
}
