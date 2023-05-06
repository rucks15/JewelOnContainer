﻿namespace JewelWebClient.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }

        public string CatalogBrand { get; set;}
        public string CatalogType { get; set; }

    }
}
