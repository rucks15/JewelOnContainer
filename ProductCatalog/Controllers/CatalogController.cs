using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Domain;
using ProductCatalog.ViewModels;
using System.Collections.Generic;

namespace ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _catalogContext;
        private readonly IConfiguration _configuration;
        //Dependency injection
        public CatalogController(CatalogContext context, IConfiguration configuration) 
        {
            _catalogContext = context;
            _configuration = configuration;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
           var types = await _catalogContext.catalogTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CatalogBrands()
        {
           var brands = await _catalogContext.catalogBrands.ToListAsync();
            return Ok(brands);
        }

        /*[HttpGet("[action]")]
        public async Task<IActionResult> CatalogItems(
            [FromQuery] int PageIndex,
            [FromQuery] int PageSize)
            {
        
            var local_items = await _catalogContext.catalogItems
                .OrderBy(c => c.ItemName)
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToListAsync();

            local_items = ChangePictureUrl(local_items);

            long local_itemsCount = local_items.Count();

            var model = new PaginatedItemViewModel
                {
                PageIndex = PageIndex,
                PageSize = local_items.Count,
                Data = local_items,
                Count = local_itemsCount
                };

            return Ok(model);
            }*/

        [HttpGet("[action]")]
        public async Task<IActionResult> CatalogItems(
            [FromQuery] int? catalogTypeId,
            [FromQuery] int? catalogBrandId,
            [FromQuery] int PageIndex,
            [FromQuery] int PageSize)
        {
            var query = (IQueryable<CatalogItem>) _catalogContext.catalogItems;
            if(catalogTypeId.HasValue)
            {
                query = query.Where(c => c.CatalogTypeId == catalogTypeId.Value);
            }
            if (catalogBrandId.HasValue)
            {
                query = query.Where(c => c.CatalogBrandId == catalogBrandId.Value);
            }

            var local_itemsCount = await query.LongCountAsync();
            var local_items = await query
                .OrderBy(c => c.ItemName)
                .Skip(PageIndex * PageSize)
                .Take(PageSize)
                .ToListAsync();

            local_items = ChangePictureUrl(local_items);

            var model = new PaginatedItemViewModel
            {
                PageIndex = PageIndex,
                PageSize = local_items.Count,
                Data = local_items,
                Count = local_itemsCount
            };
           
           return Ok(model);        
        }

        private List<CatalogItem> ChangePictureUrl(List<CatalogItem> items)
        {
            //string cannot be replaced in-line; so item.url is overwritten
            items.ForEach(item => item.PictureUrl = item.PictureUrl
            .Replace("http://externalcatalogbaseurltobereplaced", 
            _configuration["ExternalBaseURl"]));
            return items;
        }
    }
}
