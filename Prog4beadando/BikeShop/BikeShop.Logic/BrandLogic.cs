// <copyright file="BrandLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Data;
    using BikeShop.Repository;

    /// <summary>
    /// This brand logic.
    /// </summary>
    public class BrandLogic : IBrandLogic
    {
        private readonly IBikeRepository bikeRepo;
        private readonly IBrandRepository brandRepo;
        private readonly IOwnerRepository ownerRepo;
        private readonly IServiceReporitory serviceRepo;
        private readonly IFacebookGroupRepository facebookGroupRepo;
        private readonly IOwnerFacebookGroupRepository ownerFacebookGroupRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandLogic"/> class.
        /// </summary>
        /// <param name="bikeRepo">The IBikeRepository.</param>
        /// <param name="brandRepo">The IBrandRepository.</param>
        /// <param name="ownerRepo">The IOwnerRepository.</param>
        /// <param name="serviceRepo">The IServiceRepository.</param>
        /// <param name="facebookGroupRepo">The IFacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        public BrandLogic(IBikeRepository bikeRepo, IBrandRepository brandRepo, IOwnerRepository ownerRepo, IServiceReporitory serviceRepo, IFacebookGroupRepository facebookGroupRepo, IOwnerFacebookGroupRepository ofbgRepo)
        {
            this.bikeRepo = bikeRepo;
            this.brandRepo = brandRepo;
            this.ownerRepo = ownerRepo;
            this.serviceRepo = serviceRepo;
            this.facebookGroupRepo = facebookGroupRepo;
            this.ownerFacebookGroupRepo = ofbgRepo;
        }

        /// <inheritdoc/>
        public void AddBrand(Brand newBrand)
        {
            this.brandRepo.Add(newBrand);
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newBrandName)
        {
            this.brandRepo.ChangeName(id, newBrandName);
        }

        /// <inheritdoc/>
        public void DeleteBrand(int id)
        {
            this.brandRepo.Delete(id);
        }

        /// <inheritdoc/>
        public Brand GetOne2(int id)
        {
            return this.brandRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public void ListAllBrands()
        {
            this.brandRepo.GetAll();
        }

        /// <summary>
        /// This method returns all the brands in the Db.
        /// </summary>
        /// <returns>It return all of the brands.</returns>
        public IQueryable<Brand> GetAll()
        {
            return this.brandRepo.GetAll();
        }

        /// <summary>
        /// This method returns the average price by brands.
        /// </summary>
        /// <param name="allBikes">It contains all of the bikes.</param>
        /// <returns>It returns the brand's name and the average price in a collection.</returns>
        public IQueryable AveragePriceByBrandLogic(IQueryable<Bike> allBikes)
        {
            var avgPrice = allBikes
                .Join(
                this.GetAll(),
                bike => bike.BrandId,
                brand => brand.Id,
                (bi, br) => new
                {
                    brandId = br.Id,
                    brandName = br.Name,
                    price = bi.BasePrice,
                })
                .GroupBy(x => x.brandName)
                .Select(x => new
                {
                    BrandName = x.Key,
                    AveragePrice = x.Average(y => y.price),
                });

            return avgPrice;
        }

        /// <summary>
        /// This method returns the average price of one specific brand.
        /// </summary>
        /// <param name="allBikes">It contains all of the bikes.</param>
        /// <param name="brandName">The brand's name we want to gets its average price.</param>
        /// <returns>It returns the average price.</returns>
        public double? AveragePriceOfOneBrand(IQueryable<Bike> allBikes, string brandName)
        {
            var avgPrice = allBikes
                .Join(
                this.GetAll(),
                bike => bike.BrandId,
                brand => brand.Id,
                (bi, br) => new
                {
                    brandId = br.Id,
                    brandName = br.Name,
                    price = bi.BasePrice,
                })
                .GroupBy(x => x.brandName)
                .Where(x => x.Key == brandName)
                .Select(x => x.Average(y => y.price))
                .FirstOrDefault();

            return avgPrice;
        }

        /// <summary>
        /// This method returns the average price of one brand.
        /// </summary>
        /// <param name="brandName">The name of the brand we want to get the average price for.</param>
        /// <returns>It return a task.</returns>
        public Task<double?> AveragePriceOfOneBrandTask(string brandName)
        {
            var allBikes = this.bikeRepo.GetAll();

            return Task.Run(() => this.AveragePriceOfOneBrand(allBikes, brandName));
        }

        public IEnumerable<Brand> GetAlll()
        {
            return this.brandRepo.GetAll();
        }
        public void ChangeCountry(int id, string newValue)
        {
            this.brandRepo.ChangeCountry(id, newValue);
        }

        public void ChangeEstablished(int id, int newValue)
        {
            this.brandRepo.ChangeEstablished(id, newValue);
        }
    }
}
