// <copyright file="BikeDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the DbContext.
    /// </summary>
    public class BikeDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BikeDbContext"/> class.
        /// </summary>
        public BikeDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets Brands.
        /// </summary>
        public virtual DbSet<Brand> Brand { get; set; }

        /// <summary>
        /// Gets or sets Bikes.
        /// </summary>
        public virtual DbSet<Bike> Bike { get; set; }

        /// <summary>
        /// Gets or sets Owners.
        /// </summary>
        public virtual DbSet<Owner> Owner { get; set; }

        /// <summary>
        /// Gets or sets Service stations.
        /// </summary>
        public virtual DbSet<Service> Service { get; set; }

        /// <summary>
        /// Gets or sets Facebook groups.
        /// </summary>
        public virtual DbSet<FacebookGroup> FacebookGroup { get; set; }

        /// <summary>
        /// Gets or sets the OwnerFacebookGroup.
        /// </summary>
        public virtual DbSet<OwnerFBGroup> OwnerFacebookGroup { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\DataBase.mdf; Integrated Security = True; MultipleActiveResultSets = True");
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>(entity =>
            {
                entity.HasOne(bike => bike.Brand).
                WithMany(brand => brand.Bikes).
                HasForeignKey(bike => bike.BrandId).
                OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Bike>(entity =>
            {
                entity.HasOne(bike => bike.Owner).
                WithMany(owner => owner.Bikes).
                HasForeignKey(bike => bike.OwnerId).
                OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OwnerFBGroup>()
                .HasOne<Owner>(o => o.Owner)
                .WithMany(x => x.OwnerFBGroup)
                .HasForeignKey(o => o.OwnerId);

            modelBuilder.Entity<OwnerFBGroup>()
                .HasOne<FacebookGroup>(g => g.FacebookGroup)
                .WithMany(x => x.OwnerFBGroup)
                .HasForeignKey(g => g.FBGroupId);

            Brand bmw = new Brand() { Id = 1, Name = "BMW", Country = "Germany", Established = 1916 };
            Brand honda = new Brand() { Id = 2, Name = "Honda", Country = "Japan", Established = 1948 };
            Brand suzuki = new Brand() { Id = 3, Name = "Suzuki", Country = "Japan", Established = 1909 };

            Owner zoltan = new Owner() { Id = 1, Name = "Zoltán", Money = 100000 };
            Owner janos = new Owner() { Id = 2, Name = "János", Money = 50000 };
            Owner bela = new Owner() { Id = 3, Name = "Béla", Money = 62500 };
            Owner tibor = new Owner() { Id = 4, Name = "Tibor", Money = 59800 };
            Owner geza = new Owner() { Id = 5, Name = "Géza", Money = 59800 };

            FacebookGroup suzukiHungary = new FacebookGroup()
            {
                Id = 1,
                Name = "GSX-R Club Hungary",
                IsBrandSpecifiad = true,
                SpecifiedBrand = "Suzuki",
            };

            FacebookGroup hondaHungary = new FacebookGroup()
            {
                Id = 2,
                Name = "Honda Club Hungary",
                IsBrandSpecifiad = true,
                SpecifiedBrand = "Honda",
            };

            FacebookGroup bmwHungary = new FacebookGroup()
            {
                Id = 3,
                Name = "BMW CLub Hungary",
                IsBrandSpecifiad = true,
                SpecifiedBrand = "BMW",
            };

            Bike bmw1 = new Bike() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW S1000RR", OwnerId = janos.Id };
            Bike bmw2 = new Bike() { Id = 2, BrandId = bmw.Id, BasePrice = 30000, Model = "BMW R1250GS", OwnerId = zoltan.Id };
            Bike honda1 = new Bike() { Id = 3, BrandId = honda.Id, BasePrice = 10000, Model = "Honda CBR600RR", OwnerId = zoltan.Id };
            Bike honda2 = new Bike() { Id = 4, BrandId = honda.Id, BasePrice = 15000, Model = "Honda CBR1000RR", OwnerId = bela.Id };
            Bike suzuki1 = new Bike() { Id = 5, BrandId = suzuki.Id, BasePrice = 20000, Model = "Suzuki GSX-R750", OwnerId = tibor.Id };
            Bike suzuki2 = new Bike() { Id = 6, BrandId = suzuki.Id, BasePrice = 25000, Model = "Suzuki DRZ 400", OwnerId = tibor.Id };

            Service suzukiHarmati = new Service() { Id = 1, Name = "suzukiHarmati", MaxSpace = 15 };
            Service hondaDream = new Service() { Id = 2, Name = "hondaDream", MaxSpace = 10 };
            Service bmwMotorrad = new Service() { Id = 3, Name = "BMW Motorrad", MaxSpace = 7 };

            OwnerFBGroup a = new OwnerFBGroup() { ConId = 1, OwnerId = 1, FBGroupId = 2 };
            OwnerFBGroup b = new OwnerFBGroup() { ConId = 2, OwnerId = 1, FBGroupId = 3 };
            OwnerFBGroup c = new OwnerFBGroup() { ConId = 3, OwnerId = 2, FBGroupId = 3 };
            OwnerFBGroup d = new OwnerFBGroup() { ConId = 4, OwnerId = 4, FBGroupId = 1 };
            OwnerFBGroup e = new OwnerFBGroup() { ConId = 5, OwnerId = 3, FBGroupId = 2 };

            modelBuilder.Entity<Brand>().HasData(bmw, honda, suzuki);
            modelBuilder.Entity<Bike>().HasData(bmw1, honda1, suzuki1, bmw2, honda2, suzuki2);
            modelBuilder.Entity<Owner>().HasData(zoltan, janos, bela, tibor, geza);
            modelBuilder.Entity<Service>().HasData(suzukiHarmati, hondaDream, bmwMotorrad);
            modelBuilder.Entity<FacebookGroup>().HasData(suzukiHungary, hondaHungary, bmwHungary);
            modelBuilder.Entity<OwnerFBGroup>().HasData(a, b, c, d, e);
        }
    }
}
