// <copyright file="IOwnerLogic.cs" company="PlaceholderCompany">
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
    /// This is the interface for the owner logic.
    /// </summary>
    public interface IOwnerLogic
    {
        /// <summary>
        /// This method changes an owner's name.
        /// </summary>
        /// <param name="id">The id of the owner we are modifying.</param>
        /// <param name="newName">The new name.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// This method adds money to an owner.
        /// </summary>
        /// <param name="id">The id of the owner we are adding money to.</param>
        /// <param name="amount">The amount of money we are adding.</param>
        void AddMoney(int id, int amount);

        /// <summary>
        /// This method takes money from an owner.
        /// </summary>
        /// <param name="id">The id of the owner we are taking money from.</param>
        /// <param name="amount">The amount of money we are taking.</param>
        void TakeMoney(int id, int amount);

        /// <summary>
        /// This method returns an owner.
        /// </summary>
        /// <param name="id">The id of the owner we are looking for.</param>
        /// <returns>It returns an owner.</returns>
        Owner GetOne2(int id);

        /// <summary>
        /// This method adds a new owner.
        /// </summary>
        /// <param name="newOwner">The new owner.</param>
        void AddOwner(Owner newOwner);

        /// <summary>
        /// This method deletes an owner.
        /// </summary>
        /// <param name="id">The id of the owner we want to delete.</param>
        void DeleteOwner(int id);

        /// <summary>
        /// This method lists all the owners.
        /// </summary>
        void ListAll();

        public IEnumerable<Owner> GetAlll();

        void ChangeFortune(int id, int amount);
    }
}
