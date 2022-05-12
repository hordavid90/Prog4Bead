// <copyright file="IFacebookGroupLogic.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// This is the interface for the Facebook group logic.
    /// </summary>
    public interface IFacebookGroupLogic
    {
        /// <summary>
        /// This method changes a Facebook group's name.
        /// </summary>
        /// <param name="id">Id of the Facebook group we are looking for.</param>
        /// <param name="newGroupName">The new name of the Facebook group.</param>
        void ChangeName(int id, string newGroupName);

        /// <summary>
        /// This method adds a new Facebook group.
        /// </summary>
        /// <param name="newGroup">The new Facebook group.</param>
        void AddFacebookGroup(FacebookGroup newGroup);

        /// <summary>
        /// This method deletes a Facebook group.
        /// </summary>
        /// <param name="id">The id of the Facebook group we want to delete.</param>
        void DeleteFacebookGroup(int id);

        /// <summary>
        /// This method lists all Facebook group in the db.
        /// </summary>
        void ListAllFacebookGroup();

        /// <summary>
        /// This method returns a Facebook group.
        /// </summary>
        /// <param name="id">The id of the Facebook group we are looking for.</param>
        /// <returns>A Facebook group.</returns>
        FacebookGroup GetOne2(int id);

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
    }
}
