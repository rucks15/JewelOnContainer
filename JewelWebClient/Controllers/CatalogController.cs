using JewelWebClient.Services;
using JewelWebClient.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JewelWebClient.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogservice) 
        {
            _catalogService = catalogservice;
        }
        public async Task<IActionResult> Index(int? page, int? brandFilterApplied, int? typeFilterApplied)
        {
            int itemsOnPage = 10;
            var catalog = await _catalogService.GetCatalogItemAsync(page ?? 0, itemsOnPage, brandFilterApplied, typeFilterApplied);

            var vm = new CatalogItemIndexPage
            {
                Brands = await _catalogService.GetBrandsAsync(),
                Types = await _catalogService.GetTypesAsync(),
                CatalogItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = catalog.PageIndex,
                    TotalItems = catalog.Count,
                    ItemsPerPage = catalog.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                BrandFilterApplied = brandFilterApplied,
                TypeFilterApplied = typeFilterApplied
            };
            return View(vm);
        }
    }
}
