using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;

namespace ProductCatalog.Data
{
    //Catalog context is a child class of EF's parent class
    public class CatalogContext : DbContext
    {

        /// <summary>
        /// Constructor that says the context of "database"
        /// The parameters passed gives what database & 
        /// </summary>
        public CatalogContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { 

        }

        //Create 3 tables based on class definition
        public DbSet<Catalog> catalogs { get; set; }
        public DbSet<CatalogBrand> brands { get; set; }
        public DbSet<CatalogItem> items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Catalog>(e =>
            {
                e.Property(t => t.ID).HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(t => t.CatalogType).HasColumnType("text")
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("CatalogType");
            });

            modelBuilder.Entity<CatalogBrand>(e =>
            {
                e.Property(b => b.Id).HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(b => b.BrandName).HasColumnType("text")
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<CatalogItem>(e =>
            {
                e.Property(i => i.Id).HasColumnName("ID")
                .IsRequired()
                .ValueGeneratedOnAdd();

                e.Property(i => i.ItemName).HasColumnName("ItemName")
                .IsRequired()
                .HasMaxLength(100);

                e.Property(i => i.ItemDescription).HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(250);

                e.Property(i => i.Price).HasColumnName("Price")
                .IsRequired();

                e.Property(i => i.PictureUrl).HasColumnName("Url");

                //Setting foreign key CatalogTypeId, CatalogBrandId for CatalogType(Catalog) & CatalogBrand(CatalogBrand)
                // One-to-many relationship
                e.HasOne(c => c.CatalogType)
                .WithMany()
                .HasForeignKey(c => c.CatalogTypeId);

                e.HasOne(c => c.CatalogBrand)
                .WithMany()
                .HasForeignKey(c => c.CatalogBrandId);

            });
            
        }

    }
}
