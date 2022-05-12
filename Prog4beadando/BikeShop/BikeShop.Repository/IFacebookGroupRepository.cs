// <copyright file="IFacebookGroupRepository.cs" company="PlaceholderCompany">
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
    /// This is the interface for the FacebookGroupRepository.
    /// </summary>
    public interface IFacebookGroupRepository : IRepository<FacebookGroup>
    {
        /// <summary>
        /// This method adds an owner to the group.
        /// </summary>
        /// <param name="groupid">The id of the group where we want to add a new owner.</param>
        /// <param name="owner">The ower we want to add.</param>
        void AddOwnerToGroup(int groupid, Owner owner);

        /// <summary>
        /// This method adds an owner to the group.
        /// </summary>
        /// <param name="groupid">The id of the group where we want to add a new owner.</param>
        /// <param name="owner">The ower we want to add.</param>
        void RemoveOwnerFromGroup(int groupid, Owner owner);

        /// <summary>
        /// This method changes a Facebook groups name.
        /// </summary>
        /// <param name="id">The if of the group we want to modify.</param>
        /// <param name="newName">The new name of the group.</param>
        void ChangeName(int id, string newName);
    }
}
