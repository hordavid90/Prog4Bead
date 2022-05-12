// <copyright file="BikeLogic.cs" company="PlaceholderCompany">
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
    /// This is the bike logic.
    /// </summary>
    public class BikeLogic : IBikeLogic
    {
        private readonly IBikeRepository bikeRepo;
        private readonly IBrandRepository brandRepo;
        private readonly IOwnerRepository ownerRepo;
        private readonly IServiceReporitory serviceRepo;
        private readonly IFacebookGroupRepository facebookGroupRepo;
        private readonly IOwnerFacebookGroupRepository ownerFacebookGroupRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BikeLogic"/> class.
        /// </summary>
        /// <param name="bikeRepo">The IBikeRepository.</param>
        /// <param name="brandRepo">The IBrandRepository.</param>
        /// <param name="ownerRepo">The IOwnerRepository.</param>
        /// <param name="serviceRepo">The IServiceRepository.</param>
        /// <param name="facebookGroupRepo">The IFacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        public BikeLogic(IBikeRepository bikeRepo, IBrandRepository brandRepo, IOwnerRepository ownerRepo, IServiceReporitory serviceRepo, IFacebookGroupRepository facebookGroupRepo, IOwnerFacebookGroupRepository ofbgRepo)
        {
            this.bikeRepo = bikeRepo;
            this.brandRepo = brandRepo;
            this.ownerRepo = ownerRepo;
            this.serviceRepo = serviceRepo;
            this.facebookGroupRepo = facebookGroupRepo;
            this.ownerFacebookGroupRepo = ofbgRepo;
        }

        /// <inheritdoc/>
        public void AddBike(Bike bike, Owner owner)
        {
            this.bikeRepo.AddBike(bike, owner);
        }

        public void AddBike2(Bike bike)
        {
            Owner owner = ownerRepo.GetOne(bike.OwnerId);

            this.bikeRepo.AddBike(bike, owner);
        }

        /// <inheritdoc/>
        public bool ChangeName(int id, string newName)
        {
            Bike bike = this.bikeRepo.GetOne(id);
            if (bike != null)
            {
                return this.bikeRepo.ChangeName(id, newName);
            }
            else
            {
                throw new Exception("Motor nem található!");
            }
        }

        /// <inheritdoc/>
        public void ChangePrice(int id, int newPrice)
        {
            Bike bike = this.bikeRepo.GetOne(id);
            if (bike != null)
            {
                this.bikeRepo.ChangePrice(id, newPrice);
            }
            else
            {
                throw new Exception("Motor nem található!");
            }
        }

        /// <inheritdoc/>
        public void DeleteBike(int id)
        {
            Bike bike = this.bikeRepo.GetOne(id);
            if (bike != null)
            {
                this.bikeRepo.Delete(id);
            }
            else
            {
                throw new Exception("Motor nem található!");
            }
        }

        /// <inheritdoc/>
        public Bike GetOne2(int id)
        {
            return this.bikeRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public void SellBike(int bikeId, Owner newOwner, Owner seller)
        {
            Bike bike = this.GetOne2(bikeId);
            if (bike != null)
            {
                if (newOwner != null)
                {
                    if (seller != null)
                    {
                        if (newOwner.Money >= bike.BasePrice)
                        {
                            this.bikeRepo.SellBike(bikeId, newOwner, seller);
                        }
                        else
                        {
                            throw new OwnerHasNotEnoughMoneyException("A vevőnek nincs elég pénze!");
                        }
                    }
                    else
                    {
                        throw new Exception("Nincs ilyen eladó!");
                    }
                }
                else
                {
                    throw new Exception("Nincs ilyen vevő!");
                }
            }
            else
            {
                throw new Exception("Motor nem található!");
            }
        }

        /// <summary>
        /// This method returns all the bikes in the Db.
        /// </summary>
        /// <returns>It return all of the bikes.</returns>
        public IQueryable<Bike> GetAll()
        {
            return this.bikeRepo.GetAll();
        }

        /// <summary>
        /// This method returns all the bikes in the Db.
        /// </summary>
        /// <returns>It return all of the bikes.</returns>
        public IEnumerable<Bike> GetAlll()
        {
            return this.bikeRepo.GetAll();
        }

        /// <summary>
        /// This method return the average price of the brands.
        /// </summary>
        /// <returns>It return the brands name and the average price.</returns>
        public IQueryable AverageBikePriceByBrandLogic()
        {
            var avgPrice = this.GetAll()
                .Join(
                this.brandRepo.GetAll(),
                bike => bike.BrandId,
                brand => brand.Id,
                (bi, br) => new
                {
                    brand = br.Name,
                    bikeprice = bi.BasePrice,
                })
                .GroupBy(x => x.brand)
                .Select(x => new
                {
                    brand = x.Key,
                    avg = x.Average(y => y.bikeprice),
                });

            return avgPrice;
        }

        /// <summary>
        /// This method returns the average price of the bikes by their brand.
        /// </summary>
        /// <returns>Returns a task.</returns>
        public Task<IQueryable> AveragePriceByBrandTask()
        {
            return Task.Run(() => this.AverageBikePriceByBrandLogic());
        }

        /// <summary>
        /// This returns the bikes with the oldest brand.
        /// </summary>
        /// <returns>It returns a collection of the bikes with the oldest brand.</returns>
        public IQueryable BikesWithTheOldestBrandLogic()
        {
            var minEstablishedDate = this.brandRepo.GetAll()
               .Select(x => x.Established)
               .Min();

            var oldestbrandId = this.brandRepo.GetAll()
                .Where(x => x.Established == minEstablishedDate)
                .Select(x => x.Id)
                .FirstOrDefault();

            var bikes = this.GetAll()
                .Join(
                this.brandRepo.GetAll(),
                bike => bike.BrandId,
                brand => brand.Id,
                (bike, brand) => new
                {
                    bikeModel = bike.Model,
                    brandId = brand.Id,
                    brandName = brand.Name,
                    established = brand.Established,
                })
                .Where(x => x.brandId == oldestbrandId)
                .Select(x => x.brandName + " " + x.bikeModel + " " + x.established);

            return bikes;
        } // Nem kell!!

        /// <summary>
        /// This returns the bikes with the oldest brand.
        /// </summary>
        /// <returns>It returns a collection of the bikes with the oldest brand.</returns>
        public IQueryable BikesWithTheOldestBrandLogic2()
        {
            var bikes = from bike in this.bikeRepo.GetAll()
            join brand in this.brandRepo.GetAll() on bike.BrandId equals brand.Id
            let minDate = this.brandRepo.GetAll().Min(x => x.Established)
            let oldestBrandId = this.brandRepo.GetAll().Where(x => x.Established == minDate).Select(x => x.Id).FirstOrDefault()
            where bike.BrandId == oldestBrandId
            select brand.Name + " " + bike.Model + " " + brand.Established;

            return bikes;
        }

        /// <summary>
        /// This method return one or more bikies which brand's established date is the oldest.
        /// </summary>
        /// <returns>It return a task.</returns>
        public Task<IQueryable> BikesWithOldestBrandTask()
        {
            return Task.Run(() => this.BikesWithTheOldestBrandLogic2());
        }

        public void Update(Bike bike)
        {
            this.bikeRepo.Update(bike);
        }
    }
}
