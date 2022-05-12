// <copyright file="CreateRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Data;
    using BikeShop.Repository;

    /// <summary>
    /// This class creates repos.
    /// </summary>
    public static class CreateRepo
    {
        /// <summary>
        /// This method return a BikeRepository.
        /// </summary>
        /// <param name="ctx">The Db Context.</param>
        /// <returns>BikeRepository.</returns>
        public static BikeRepository CreateBikeRepo(BikeDbContext ctx)
        {
            return new BikeRepository(ctx);
        }

        /// <summary>
        /// This method return a BrandRepository.
        /// </summary>
        /// <param name="ctx">The Db Context.</param>
        /// <returns>BrandRepository.</returns>
        public static BrandRepository CreateBrandRepo(BikeDbContext ctx)
        {
            return new BrandRepository(ctx);
        }

        /// <summary>
        /// This method return a OwnerRepository.
        /// </summary>
        /// <param name="ctx">The Db Context.</param>
        /// <returns>OwnerRepository.</returns>
        public static OwnerRepository CreateOwnerRepo(BikeDbContext ctx)
        {
            return new OwnerRepository(ctx);
        }

        /// <summary>
        /// This method return a ServiceRepository.
        /// </summary>
        /// <param name="ctx">The Db Context.</param>
        /// <returns>ServiceRepository.</returns>
        public static ServiceRepository CreateServiceRepo(BikeDbContext ctx)
        {
            return new ServiceRepository(ctx);
        }

        /// <summary>
        /// This method return a OwnerFacebookGroupRepository.
        /// </summary>
        /// <param name="ctx">The Db Context.</param>
        /// <returns>OwnerFacebookGroupRepository.</returns>
        public static OwnerFacebookGroupRepository CreateOwnerFacebookGroupRepo(BikeDbContext ctx)
        {
            return new OwnerFacebookGroupRepository(ctx);
        }

        /// <summary>
        /// This method return a FacebookGroupRepository.
        /// </summary>
        /// <param name="ctx">The Db Context.</param>
        /// <returns>FacebookGroupRepository.</returns>
        public static FacebookGroupRepository CreateFacebookGroupRepo(BikeDbContext ctx)
        {
            return new FacebookGroupRepository(ctx);
        }
    }
}
