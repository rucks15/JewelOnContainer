using JewelWebClient.Infrastructure;
using JewelWebClient.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JewelWebClient.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _httpclient;
        public CatalogService(IConfiguration configuration, IHttpClient httpClient)
        {
            _baseUrl = $"{configuration["CatalogUrl"]}/api/Catalog";
            _httpclient = httpClient;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            var brandUri = APIPaths.Catalog.GetAllBrands(_baseUrl);
            var datasrtring = await _httpclient.GetStringAsync(brandUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };

            var brands = JArray.Parse(datasrtring);
            foreach (var item in brands)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("brandName")

                });
            }
            return items;
        }

        public async Task<Catalog> GetCatalogItemAsync(int page, int size, int? brand, int? type)
        {
            var CatalogItemsUri = APIPaths.Catalog.GetAllItems(_baseUrl, page, size, brand, type);
            var datastring = await _httpclient.GetStringAsync(CatalogItemsUri);
            return JsonConvert.DeserializeObject<Catalog>(datastring);
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            var typesUri = APIPaths.Catalog.GetAllTypes(_baseUrl);
            var datasrtring = await _httpclient.GetStringAsync(typesUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };

            var types = JArray.Parse(datasrtring);
            foreach (var item in types)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("catalogTypeName")

                });
            }
            return items;
        }
    }
}
