using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;

namespace ProductCatalog.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            //EF core migrates from C# to Sql; create tables in database
            context.Database.Migrate();

            //when catalog table does not exist the following block executed
            if (!context.catalogs.Any())
            {
                context.catalogs.AddRange(GetCatalogs());
                context.SaveChanges();
            }

            if (!context.brands.Any())
            {
                context.brands.AddRange(GetBrands());
                context.SaveChanges();
            }

            if (!context.items.Any())
            {
                context.items.AddRange(GetItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<Catalog> GetCatalogs()
        {
            return new List<Catalog>
            {
                new Catalog {CatalogType="Engagement Ring"},
                new Catalog {CatalogType = "Wedding Ring"},
                new Catalog {CatalogType = "Fashion Ring"}
            };
        }

        private static IEnumerable<CatalogBrand> GetBrands()
        {
            return new List<CatalogBrand>
            {
                new CatalogBrand {BrandName = "Tiffany"},
                new CatalogBrand {BrandName = "DeBeers"},
                new CatalogBrand {BrandName = "Graff"}
            };
        }

        private static IEnumerable<CatalogItem> GetItems()
        {
            return new List<CatalogItem>
            {
                new CatalogItem {CatalogTypeId=1, CatalogBrandId=1, ItemDescription="Sample ring 1", ItemName="Ring Item 1", Price=1200.00M,PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/1"},
                new CatalogItem {CatalogTypeId=2, CatalogBrandId=2, ItemDescription="Sample ring 2", ItemName="Ring Item 2", Price=1800.00M, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/2"},
                new CatalogItem {CatalogTypeId=3, CatalogBrandId=3, ItemDescription="Sample ring 3", ItemName="Ring Item 3", Price=2000.50M, PictureUrl="http://externalcatalogbaseurltobereplaced/api/pic/3"}
            };
        }
    }
}
