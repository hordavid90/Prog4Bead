// <copyright file="OwnerFacebookGroupLogic.cs" company="PlaceholderCompany">
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
    /// This is the OwnerFacebookGroupLogic.
    /// </summary>
    public class OwnerFacebookGroupLogic
    {
        private readonly IBikeRepository bikeRepo;
        private readonly IBrandRepository brandRepo;
        private readonly IOwnerRepository ownerRepo;
        private readonly IServiceReporitory serviceRepo;
        private readonly IFacebookGroupRepository facebookGroupRepo;
        private readonly IOwnerFacebookGroupRepository ownerFacebookGroupRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerFacebookGroupLogic"/> class.
        /// </summary>
        /// <param name="bikeRepo">The IBikeRepository.</param>
        /// <param name="brandRepo">The IBrandRepository.</param>
        /// <param name="ownerRepo">The IOwnerRepository.</param>
        /// <param name="serviceRepo">The IServiceRepository.</param>
        /// <param name="facebookGroupRepo">The IFacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        public OwnerFacebookGroupLogic(IBikeRepository bikeRepo, IBrandRepository brandRepo, IOwnerRepository ownerRepo, IServiceReporitory serviceRepo, IFacebookGroupRepository facebookGroupRepo, IOwnerFacebookGroupRepository ofbgRepo)
        {
            this.bikeRepo = bikeRepo;
            this.brandRepo = brandRepo;
            this.ownerRepo = ownerRepo;
            this.serviceRepo = serviceRepo;
            this.facebookGroupRepo = facebookGroupRepo;
            this.ownerFacebookGroupRepo = ofbgRepo;
        }

        /// <summary>
        /// This method adds a new OwnerFacebookGroup.
        /// </summary>
        /// <param name="newFBGroup">The new OwnerFacebookGroup.</param>
        public void AddOwnerFacebookGroup(OwnerFBGroup newFBGroup)
        {
            this.ownerFacebookGroupRepo.Add(newFBGroup);
        }

        /// <summary>
        /// This method deletes an owner from a Facebook group.
        /// </summary>
        /// <param name="groupid">The id of the group.</param>
        /// <param name="ownerid">The id of the owner we want to delete.</param>
        public void DeleteOwner(int groupid, int ownerid)
        {
            FacebookGroup group = this.facebookGroupRepo.GetOne(groupid);
            Owner owner = this.ownerRepo.GetOne(ownerid);
            if (group != null)
            {
                if (owner != null)
                {
                    this.ownerFacebookGroupRepo.Delete2(groupid, ownerid);
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
        /// This method returns one ownerfacebookgroup entity.
        /// </summary>
        /// <param name="id">The id of the ownerfacebookgroup.</param>
        /// <returns>It returns one ownerfacebookgroup entity.</returns>
        public OwnerFBGroup GetOne2(int id)
        {
            return this.ownerFacebookGroupRepo.GetOne(id);
        }

        /// <summary>
        /// This method returns all of the ownerfacebookgroup entity.
        /// </summary>
        /// <returns>It returns all of the ownerfacebookgroup entity.</returns>
        public IQueryable<OwnerFBGroup> GetAll()
        {
            var asd = this.ownerFacebookGroupRepo.GetAll();
            return asd;
        }

        /// <summary>
        /// This method returns the bikes in a facebook group.
        /// </summary>
        /// <param name="id">The id of the Facebook group.</param>
        /// <returns>It returns the group's name, the brand id, the brand name, the mike's model name and the owner.</returns>
        public IQueryable BikesByFbGroup(int id)
        {
            var bikes = this.bikeRepo.GetAll()
                .Join(
                this.ownerFacebookGroupRepo.GetAll(),
                bike => bike.OwnerId,
                group => group.OwnerId,
                (b, g) => new
                {
                    bikeModel = b.Model,
                    brandId = b.BrandId,
                    brandName = b.Brand.Name,
                    groupid = g.FBGroupId,
                    ownerid = g.OwnerId,
                    group = g.FacebookGroup.Name,
                    owner = b.Owner.Name,
                })
                .Where(x => x.groupid == id)
                .Select(x => x.group + ", márka id: " + x.brandId + ", márka: " + x.brandName + ", modell: " + x.bikeModel + ", tulajdonos: " + x.owner);

            return bikes;
        }

        /// <summary>
        /// This method returns the bikes in a facebook group.
        /// </summary>
        /// <param name="id">The id of the Facebook group.</param>
        /// <returns>It returns a task.</returns>
        public Task<IQueryable> BikesByFBGroupTask(int id)
        {
            return Task.Run(() => this.BikesByFbGroup(id));
        }
    }
}
