// <copyright file="CreateLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Logic;
    using BikeShop.Repository;

    /// <summary>
    /// This class has methods that creates logics.
    /// </summary>
    public static class CreateLogic
    {
        /// <summary>
        /// This method returns a BikeLogic.
        /// </summary>
        /// <param name="bikeRepo">The BikeRepository.</param>
        /// <param name="brandRepo">The BrandRepository.</param>
        /// <param name="ownerRepo">The OwnerRepository.</param>
        /// <param name="serviceRepo">The ServiceRepository.</param>
        /// <param name="facebookGroupRepo">The FacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        /// <returns>BikeLogic.</returns>
        public static BikeLogic CreateBikeLogic(BikeRepository bikeRepo, BrandRepository brandRepo, OwnerRepository ownerRepo, ServiceRepository serviceRepo, FacebookGroupRepository facebookGroupRepo, OwnerFacebookGroupRepository ofbgRepo)
        {
            return new BikeLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, facebookGroupRepo, ofbgRepo);
        }

        /// <summary>
        /// This method returns a BrandLogic.
        /// </summary>
        /// <param name="bikeRepo">The BikeRepository.</param>
        /// <param name="brandRepo">The BrandRepository.</param>
        /// <param name="ownerRepo">The OwnerRepository.</param>
        /// <param name="serviceRepo">The ServiceRepository.</param>
        /// <param name="facebookGroupRepo">The FacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        /// <returns>BrandLogic.</returns>
        public static BrandLogic CreateBrandLogic(BikeRepository bikeRepo, BrandRepository brandRepo, OwnerRepository ownerRepo, ServiceRepository serviceRepo, FacebookGroupRepository facebookGroupRepo, OwnerFacebookGroupRepository ofbgRepo)
        {
            return new BrandLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, facebookGroupRepo, ofbgRepo);
        }

        /// <summary>
        /// This method returns a OwnerLogic.
        /// </summary>
        /// <param name="bikeRepo">The BikeRepository.</param>
        /// <param name="brandRepo">The BrandRepository.</param>
        /// <param name="ownerRepo">The OwnerRepository.</param>
        /// <param name="serviceRepo">The ServiceRepository.</param>
        /// <param name="facebookGroupRepo">The FacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        /// <returns>OwnerLogic.</returns>
        public static OwnerLogic CreateOwnerLogic(BikeRepository bikeRepo, BrandRepository brandRepo, OwnerRepository ownerRepo, ServiceRepository serviceRepo, FacebookGroupRepository facebookGroupRepo, OwnerFacebookGroupRepository ofbgRepo)
        {
            return new OwnerLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, facebookGroupRepo, ofbgRepo);
        }

        /// <summary>
        /// This method returns a OwnerLogic.
        /// </summary>
        /// <param name="bikeRepo">The BikeRepository.</param>
        /// <param name="brandRepo">The BrandRepository.</param>
        /// <param name="ownerRepo">The OwnerRepository.</param>
        /// <param name="serviceRepo">The ServiceRepository.</param>
        /// <param name="facebookGroupRepo">The FacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        /// <returns>OwnerLogic.</returns>
        public static ServiceLogic CreateServiceLogic(BikeRepository bikeRepo, BrandRepository brandRepo, OwnerRepository ownerRepo, ServiceRepository serviceRepo, FacebookGroupRepository facebookGroupRepo, OwnerFacebookGroupRepository ofbgRepo)
        {
            return new ServiceLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, facebookGroupRepo, ofbgRepo);
        }

        /// <summary>
        /// This method returns a OwnerLogic.
        /// </summary>
        /// <param name="bikeRepo">The BikeRepository.</param>
        /// <param name="brandRepo">The BrandRepository.</param>
        /// <param name="ownerRepo">The OwnerRepository.</param>
        /// <param name="serviceRepo">The ServiceRepository.</param>
        /// <param name="facebookGroupRepo">The FacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        /// <returns>OwnerLogic.</returns>
        public static FacebookGroupLogic CreateFacebookGroupLogic(BikeRepository bikeRepo, BrandRepository brandRepo, OwnerRepository ownerRepo, ServiceRepository serviceRepo, FacebookGroupRepository facebookGroupRepo, OwnerFacebookGroupRepository ofbgRepo)
        {
            return new FacebookGroupLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, facebookGroupRepo, ofbgRepo);
        }

        /// <summary>
        /// This method returns a OwnerLogic.
        /// </summary>
        /// <param name="bikeRepo">The BikeRepository.</param>
        /// <param name="brandRepo">The BrandRepository.</param>
        /// <param name="ownerRepo">The OwnerRepository.</param>
        /// <param name="serviceRepo">The ServiceRepository.</param>
        /// <param name="facebookGroupRepo">The FacebookGroupRepository.</param>
        /// <param name="ofbgRepo">The OwnerFacebookGroupRepository.</param>
        /// <returns>OwnerLogic.</returns>
        public static OwnerFacebookGroupLogic CreateOwnerFacebookGroupLogic(BikeRepository bikeRepo, BrandRepository brandRepo, OwnerRepository ownerRepo, ServiceRepository serviceRepo, FacebookGroupRepository facebookGroupRepo, OwnerFacebookGroupRepository ofbgRepo)
        {
            return new OwnerFacebookGroupLogic(bikeRepo, brandRepo, ownerRepo, serviceRepo, facebookGroupRepo, ofbgRepo);
        }
    }
}
