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
            if (!context.catalogTypes.Any())
            {
                context.catalogTypes.AddRange(GetCatalogs());
                context.SaveChanges();
            }

            if (!context.catalogBrands.Any())
            {
                context.catalogBrands.AddRange(GetBrands());
                context.SaveChanges();
            }

            if (!context.catalogItems.Any())
            {
                context.catalogItems.AddRange(GetItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<CatalogType> GetCatalogs()
        {
            return new List<CatalogType>
            {
                new CatalogType {CatalogTypeName="Engagement Ring"},
                new CatalogType {CatalogTypeName = "Wedding Ring"},
                new CatalogType {CatalogTypeName = "Fashion Ring"}
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
