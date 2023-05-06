using JewelWebClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JewelWebClient.ViewModels
{
    public class CatalogItemIndexPage
    {
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }

        public IEnumerable<CatalogItem> CatalogItems { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? BrandFilterApplied { get; set; }
        public int? TypeFilterApplied { get; set; }
    }
}
