// <copyright file="FacebookGroupLogic.cs" company="PlaceholderCompany">
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
    /// The FacebookGroup logic.
    /// </summary>
    public class FacebookGroupLogic : IFacebookGroupLogic
    {
        private readonly IBikeRepository bikeRepo;
        private readonly IBrandRepository brandRepo;
        private readonly IOwnerRepository ownerRepo;
        private readonly IServiceReporitory serviceRepo;
        private readonly IFacebookGroupRepository facebookGroupRepo;
        private readonly IOwnerFacebookGroupRepository ownerFacebookGroupRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookGroupLogic"/> class.
        /// </summary>
        /// <param name="bikeRepo">The IBikeRepository.</param>
        /// <param name="brandRepo">The IBrandRepository.</param>
        /// <param name="ownerRepo">The IOwnerRepository.</param>
        /// <param name="serviceRepo">The IServiceRepository.</param>
        /// <param name="facebookGroupRepo">The IFacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        public FacebookGroupLogic(IBikeRepository bikeRepo, IBrandRepository brandRepo, IOwnerRepository ownerRepo, IServiceReporitory serviceRepo, IFacebookGroupRepository facebookGroupRepo, IOwnerFacebookGroupRepository ofbgRepo)
        {
            this.bikeRepo = bikeRepo;
            this.brandRepo = brandRepo;
            this.ownerRepo = ownerRepo;
            this.serviceRepo = serviceRepo;
            this.facebookGroupRepo = facebookGroupRepo;
            this.ownerFacebookGroupRepo = ofbgRepo;
        }

        /// <inheritdoc/>
        public void AddFacebookGroup(FacebookGroup newGroup)
        {
            this.facebookGroupRepo.Add(newGroup);
        }

        /// <inheritdoc/>
        public void AddOwnerToGroup(int groupid, Owner owner)
        {
            var group = this.facebookGroupRepo.GetOne(groupid);

            if (group != null)
            {
                if (owner != null)
                {
                    var bikes = owner.Bikes;
                    foreach (var bike in bikes)
                    {
                        if (group.IsBrandSpecifiad == false || bike.Brand.Name == group.SpecifiedBrand)
                        {
                            this.facebookGroupRepo.AddOwnerToGroup(groupid, owner);
                            return;
                        }
                        else
                        {
                            throw new Exception("A csoportba csak " + group.SpecifiedBrand + " márkájú motorokkal" +
                                "rendelkező tulajok léphetnek be.");
                        }
                    }
                }
                else
                {
                    throw new Exception("A tulajdonos nem található!");
                }
            }
            else
            {
                throw new Exception("A csoport nem található!");
            }
        }

        /// <inheritdoc/>
        public void ChangeName(int id, string newGroupName)
        {
            FacebookGroup group = this.facebookGroupRepo.GetOne(id);
            if (group != null)
            {
                this.facebookGroupRepo.ChangeName(id, newGroupName);
            }
            else
            {
                throw new Exception("A csoport nem található!");
            }
        }

        /// <inheritdoc/>
        public void DeleteFacebookGroup(int id)
        {
            FacebookGroup group = this.facebookGroupRepo.GetOne(id);
            if (group != null)
            {
                this.facebookGroupRepo.Delete(id);
            }
            else
            {
                throw new Exception("A csoport nem található!");
            }
        }

        /// <inheritdoc/>
        public FacebookGroup GetOne2(int id)
        {
            return this.facebookGroupRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public void ListAllFacebookGroup()
        {
            this.facebookGroupRepo.GetAll();
        }

        /// <inheritdoc/>
        public void RemoveOwnerFromGroup(int groupid, Owner owner)
        {
            FacebookGroup group = this.facebookGroupRepo.GetOne(groupid);
            if (group != null)
            {
                if (owner != null)
                {
                    this.facebookGroupRepo.RemoveOwnerFromGroup(groupid, owner);
                }
                else
                {
                    throw new Exception("A tulajdonos nem található!");
                }
            }
            else
            {
                throw new Exception("A csoport nem található!");
            }
        }

        /// <summary>
        /// This method returns all the Facebook groups in the Db.
        /// </summary>
        /// <returns>It return all of the Facebook groups.</returns>
        public IQueryable<FacebookGroup> GetAll()
        {
            return this.facebookGroupRepo.GetAll();
        }
    }
}
