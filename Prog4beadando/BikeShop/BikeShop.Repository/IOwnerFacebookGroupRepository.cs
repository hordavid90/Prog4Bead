// <copyright file="IOwnerFacebookGroupRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Data;

    /// <summary>
    /// The OwnerFacebookGroupRepository interface.
    /// </summary>
    public interface IOwnerFacebookGroupRepository : IRepository<OwnerFBGroup>
    {
        /// <summary>
        /// This method deletes an owner from a FB group.
        /// </summary>
        /// <param name="groupId">The group id we want to delete from.</param>
        /// <param name="ownerId">The id of the owner we want to delete from the FB group.</param>
        void Delete2(int groupId, int ownerId);
    }
}
