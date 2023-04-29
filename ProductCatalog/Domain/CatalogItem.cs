namespace ProductCatalog.Domain
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

        //Navigation property
        public virtual CatalogType CatalogType { get; set; }
        public virtual CatalogBrand CatalogBrand { get; set; }

    }
}
