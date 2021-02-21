using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class ExecutionTestsDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ExecutionTestsDBContext()
        {
        }

        public ExecutionTestsDBContext(DbContextOptions<ExecutionTestsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuildVersion> BuildVersions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ClimateCondition> ClimateConditions { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<ExecutionTest> ExecutionTests { get; set; }
        public virtual DbSet<MeasureCondition> MeasureConditions { get; set; }
        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Periode> Periodes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product1> Products1 { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }
        public virtual DbSet<SelectionSet> SelectionSets { get; set; }
        public virtual DbSet<SelectionSetOptionItem> SelectionSetOptionItems { get; set; }
        public virtual DbSet<VGetAllCategory> VGetAllCategories { get; set; }
        public virtual DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }
        public virtual DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:mariaserver.database.windows.net,1433;Initial Catalog=mariaDb;Persist Security Info=False;User ID=madmin;Password=B2af0886bd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BuildVersion>(entity =>
            {
                entity.HasKey(e => e.SystemInformationId)
                    .HasName("PK__BuildVer__35E58ECA46427019");

                entity.ToTable("BuildVersion");

                entity.Property(e => e.SystemInformationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SystemInformationID");

                entity.Property(e => e.DatabaseVersion)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("Database Version");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.VersionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<ClimateCondition>(entity =>
            {
                entity.ToTable("ClimateCondition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ErrorLog");

                entity.Property(e => e.ErrorLogId).HasColumnName("ErrorLogID");

                entity.Property(e => e.ErrorMessage)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.ErrorProcedure).HasMaxLength(126);

                entity.Property(e => e.ErrorTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<ExecutionTest>(entity =>
            {
                entity.ToTable("ExecutionTest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ClimaticConditionId).HasColumnName("ClimaticConditionID");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.MeasurementDate).HasMaxLength(255);

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.PeriodeId).HasColumnName("PeriodeID");

                entity.Property(e => e.Picture).HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.TestValue).HasColumnName("Value");



                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ExecutionTests)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ExecutionTest_Category");

                entity.HasOne(d => d.ClimaticCondition)
                    .WithMany(p => p.ExecutionTests)
                    .HasForeignKey(d => d.ClimaticConditionId)
                    .HasConstraintName("FK_ExecutionTest_ClimateCondition");

                entity.HasOne(d => d.MeasureCondition)
                    .WithMany(p => p.ExecutionTests)
                    .HasForeignKey(d => d.MeasureConditionId)
                    .HasConstraintName("FK_ExecutionTest_MeasureCondition");

                entity.HasOne(d => d.Parameter)
                    .WithMany(p => p.ExecutionTests)
                    .HasForeignKey(d => d.ParameterId)
                    .HasConstraintName("FK_ExecutionTest_Parameter");

                entity.HasOne(d => d.Periode)
                    .WithMany(p => p.ExecutionTests)
                    .HasForeignKey(d => d.PeriodeId)
                    .HasConstraintName("FK_ExecutionTest_Periode");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ExecutionTests)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ExecutionTest_Product");

                entity.HasOne(d => d.SelectedOptionItem)
                    .WithMany(p => p.ExecutionTests)
                    .HasForeignKey(d => d.SelectedOptionItemId)
                    .HasConstraintName("FK_ExecutionTest_SelectionSetOptionItems");
            });
            

            modelBuilder.Entity<MeasureCondition>(entity =>
            {
                entity.ToTable("MeasureCondition");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Parameter>(entity =>
            {
                entity.ToTable("Parameter");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ParameterType).HasMaxLength(255);

                entity.Property(e => e.SelectionSetId).HasColumnName("SelectionSetID");

                entity.HasOne(d => d.SelectionSet)
                    .WithMany(p => p.Parameters)
                    .HasForeignKey(d => d.SelectionSetId)
                    .HasConstraintName("FK_Parameter_SelectionSet");
            });

            modelBuilder.Entity<Periode>(entity =>
            {
                entity.ToTable("Periode");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PeriodeType).HasMaxLength(255);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Product1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product", "SalesLT");

                entity.Property(e => e.Color).HasMaxLength(15);

                entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");

                entity.Property(e => e.ListPrice).HasColumnType("money");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.ProductNumber)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.SellEndDate).HasColumnType("datetime");

                entity.Property(e => e.SellStartDate).HasColumnType("datetime");

                entity.Property(e => e.Size).HasMaxLength(5);

                entity.Property(e => e.StandardCost).HasColumnType("money");

                entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);

                entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductCategory", "SalesLT");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");

                entity.Property(e => e.ProductCategoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductCategoryID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductDescription", "SalesLT");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductDescriptionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductDescriptionID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductModel", "SalesLT");

                entity.Property(e => e.CatalogDescription).HasColumnType("xml");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductModelId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductModelID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProductModelProductDescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ProductModelProductDescription", "SalesLT");

                entity.Property(e => e.Culture)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");

                entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<SelectionSet>(entity =>
            {
                entity.ToTable("SelectionSet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.SetName).HasMaxLength(255);
            });

            modelBuilder.Entity<SelectionSetOptionItem>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ItemName).HasMaxLength(255);

                entity.Property(e => e.SelectionSetId).HasColumnName("SelectionSetID");

                entity.HasOne(d => d.SelectionSet)
                    .WithMany(p => p.SelectionSetOptionItems)
                    .HasForeignKey(d => d.SelectionSetId)
                    .HasConstraintName("FK_SelectionSetOptionItems_SelectionSet");
            });

            modelBuilder.Entity<VGetAllCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vGetAllCategories", "SalesLT");

                entity.Property(e => e.ParentProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");

                entity.Property(e => e.ProductCategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<VProductAndDescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vProductAndDescription", "SalesLT");

                entity.Property(e => e.Culture)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength(true);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductModel)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VProductModelCatalogDescription>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vProductModelCatalogDescription", "SalesLT");

                entity.Property(e => e.Color).HasMaxLength(256);

                entity.Property(e => e.Copyright).HasMaxLength(30);

                entity.Property(e => e.Crankset).HasMaxLength(256);

                entity.Property(e => e.MaintenanceDescription).HasMaxLength(256);

                entity.Property(e => e.Material).HasMaxLength(256);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NoOfYears).HasMaxLength(256);

                entity.Property(e => e.Pedal).HasMaxLength(256);

                entity.Property(e => e.PictureAngle).HasMaxLength(256);

                entity.Property(e => e.PictureSize).HasMaxLength(256);

                entity.Property(e => e.ProductLine).HasMaxLength(256);

                entity.Property(e => e.ProductModelId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductModelID");

                entity.Property(e => e.ProductPhotoId)
                    .HasMaxLength(256)
                    .HasColumnName("ProductPhotoID");

                entity.Property(e => e.ProductUrl)
                    .HasMaxLength(256)
                    .HasColumnName("ProductURL");

                entity.Property(e => e.RiderExperience).HasMaxLength(1024);

                entity.Property(e => e.Rowguid).HasColumnName("rowguid");

                entity.Property(e => e.Saddle).HasMaxLength(256);

                entity.Property(e => e.Style).HasMaxLength(256);

                entity.Property(e => e.WarrantyDescription).HasMaxLength(256);

                entity.Property(e => e.WarrantyPeriod).HasMaxLength(256);

                entity.Property(e => e.Wheel).HasMaxLength(256);
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
