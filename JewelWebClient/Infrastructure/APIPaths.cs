namespace JewelWebClient.Infrastructure
{
    public static class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUrl)
            {
                //API path from postman
                return $"{baseUrl}/CatalogTypes";
            }

            public static string GetAllBrands(string baseUrl)
            {
                //API path from postman
                return $"{baseUrl}/CatalogBrands";
            }

            public static string GetAllItems(string baseUrl, int page, int take,int? brand, int?type)
            {
                var preUri = string.Empty;
                var filterqy = string.Empty;

                if(brand.HasValue)
                {
                    filterqy = $"CatalogBrandId={brand.Value}";
                }

                if(type.HasValue)
                {
                    filterqy = (filterqy == string.Empty) ? $"CatalogTypeId={type}" : $"{filterqy}&CatalogTypeId={type}";
                }

                if(string.IsNullOrEmpty(filterqy))
                {
                    preUri = $"{baseUrl}/CatalogItems?PageIndex={page}&PageSize={take}";
                }
                else
                {
                    preUri = $"{baseUrl}/CatalogItems?PageIndex={page}&PageSize={take}&{filterqy}";
                }
                //API path from postman
                return preUri;
            }

        }
        public static class Basket
            {
            public static string GetBasket(string baseUri, string basketId)
                {
                return $"{baseUri}/{basketId}";
                }

            public static string UpdateBasket(string baseUri)
                {
                return baseUri;
                }

            public static string CleanBasket(string baseUri, string basketId)
                {
                return $"{baseUri}/{basketId}";
                }
            }

        public static class Order
            {
            public static string GetOrder(string baseUri, string orderId)
                {
                return $"{baseUri}/{orderId}";
                }

            public static string AddNewOrder(string baseUri)
                {
                return $"{baseUri}/new";
                }
            }

        }
    }
