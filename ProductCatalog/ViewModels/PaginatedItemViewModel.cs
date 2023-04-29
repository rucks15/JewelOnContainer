using ProductCatalog.Domain;
using System.Collections.Generic;

namespace ProductCatalog.ViewModels
{
    public class PaginatedItemViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<CatalogItem>? Data { get; set; }

    }
}
