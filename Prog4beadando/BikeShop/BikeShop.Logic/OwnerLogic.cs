// <copyright file="OwnerLogic.cs" company="PlaceholderCompany">
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
    /// This is the OwnerLogic class.
    /// </summary>
    public class OwnerLogic : IOwnerLogic
    {
        private readonly IBikeRepository bikeRepo;
        private readonly IBrandRepository brandRepo;
        private readonly IOwnerRepository ownerRepo;
        private readonly IServiceReporitory serviceRepo;
        private readonly IFacebookGroupRepository facebookGroupRepo;
        private readonly IOwnerFacebookGroupRepository ownerFacebookGroupRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerLogic"/> class.
        /// </summary>
        /// <param name="bikeRepo">The IBikeRepository.</param>
        /// <param name="brandRepo">The IBrandRepository.</param>
        /// <param name="ownerRepo">The IOwnerRepository.</param>
        /// <param name="serviceRepo">The IServiceRepository.</param>
        /// <param name="facebookGroupRepo">The IFacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        public OwnerLogic(IBikeRepository bikeRepo, IBrandRepository brandRepo, IOwnerRepository ownerRepo, IServiceReporitory serviceRepo, IFacebookGroupRepository facebookGroupRepo, IOwnerFacebookGroupRepository ofbgRepo)
        {
            this.bikeRepo = bikeRepo;
            this.brandRepo = brandRepo;
            this.ownerRepo = ownerRepo;
            this.serviceRepo = serviceRepo;
            this.facebookGroupRepo = facebookGroupRepo;
            this.ownerFacebookGroupRepo = ofbgRepo;
        }

        /// <inheritdoc/>
        public void AddMoney(int id, int amount)
        {
            Owner o = this.ownerRepo.GetOne(id);
            if (o != null)
            {
                this.ownerRepo.AddMoney(id, amount);
            }
            else
            {
                throw new NullReferenceException("Tulajdonos nem található!");
            }
        }

        /// <inheritdoc/>
        public void AddOwner(Owner newOwner)
        {
            this.ownerRepo.Add(newOwner);
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newName)
        {
            Owner o = this.ownerRepo.GetOne(id);
            if (o != null)
            {
                this.ownerRepo.ChangeName(id, newName);
            }
            else
            {
                throw new NullReferenceException("Tulajdonos nem található!");
            }
        }

        /// <inheritdoc/>
        public void DeleteOwner(int id)
        {
            Owner o = this.ownerRepo.GetOne(id);
            var ownersBikes = o.Bikes;
            if (o != null)
            {
                if (ownersBikes.Count == 0)
                {
                    this.ownerRepo.Delete(id);
                }
                else
                {
                    throw new Exception("Előbb el kell adnia a tulajdonosnak a motorjait!");
                }
            }
            else
            {
                throw new Exception("Tulajdonos nem található!");
            }
        }

        /// <inheritdoc/>
        public Owner GetOne2(int id)
        {
            return this.ownerRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public void ListAll()
        {
            this.ownerRepo.GetAll();
        }

        /// <inheritdoc/>
        public void TakeMoney(int id, int amount)
        {
            Owner o = this.ownerRepo.GetOne(id);
            if (o != null)
            {
                if (o.Money >= amount)
                {
                    this.ownerRepo.TakeMoney(id, amount);
                }
                else
                {
                    throw new Exception("A tulajdonos csődbe megy!");
                }
            }
            else
            {
                throw new Exception("Tulajdonos nem található!");
            }
        }

        /// <summary>
        /// This method returns all the owners in the Db.
        /// </summary>
        /// <returns>It return all of the owners.</returns>
        public IQueryable<Owner> GetAll()
        {
            return this.ownerRepo.GetAll();
        }

        IEnumerable<Owner> IOwnerLogic.GetAlll()
        {
            return this.ownerRepo.GetAll();
        }

        /// <summary>
        /// This return the favorite brand of an owner if he has any.
        /// </summary>
        /// <param name="id">The id of the owner.</param>
        /// <returns>The favorite brands name.</returns>
        public string OwnersFavoriteBrandLogic(int id)
        {
            var ownersbikesByBrandCount = this.GetOne2(id)
                .Bikes.GroupBy(x => x.Brand.Name)
                .Select(x => new
                {
                    brand = x.Key,
                    brandCount = x.Count(),
                })
                .OrderByDescending(x => x.brandCount);

            if (this.GetOne2(id).Bikes.Count > 0)
            {
                int maxdarab = ownersbikesByBrandCount.FirstOrDefault().brandCount;
                var valami2 = ownersbikesByBrandCount.ElementAtOrDefault(1);

                if (valami2 != null)
                {
                    int masodikBrandCount = ownersbikesByBrandCount.ElementAtOrDefault(1).brandCount;

                    if (maxdarab > masodikBrandCount)
                    {
                        return ownersbikesByBrandCount.FirstOrDefault().brand;
                    }
                    else if (maxdarab == masodikBrandCount)
                    {
                        return "A tulajdonosnak nincs kedvenc motorja.";
                    }
                    else
                    {
                        return " ";
                    }
                }
                else
                {
                    return ownersbikesByBrandCount.FirstOrDefault().brand;
                }
            }
            else
            {
                return "A tulajdonosnak nincs motorja.";
            }
        }

        public void ChangeFortune(int id, int amount)
        {
            this.ownerRepo.ChangeFortune(id, amount);
        }
    }
}
