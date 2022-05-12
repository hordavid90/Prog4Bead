// <copyright file="IOwnerRepository.cs" company="PlaceholderCompany">
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
    /// This is the interface for the owner repository.
    /// </summary>
    public interface IOwnerRepository : IRepository<Owner>
    {
        /// <summary>
        /// This method deletes an owner.
        /// </summary>
        /// <param name="id">The id of the owner we are looking for.</param>
        /// <param name="newName">The new name of the owner.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// This method adds money to an owner.
        /// </summary>
        /// <param name="id">The if of the owner who we want to add money to.</param>
        /// <param name="amount">The amount of money we want to add.</param>
        void AddMoney(int id, int amount);

        /// <summary>
        /// This method takes money from an owner.
        /// </summary>
        /// <param name="id">The if of the owner who we want to take money from.</param>
        /// <param name="amount">The amount of money we want to take.</param>
        void TakeMoney(int id, int amount);

        void ChangeFortune(int id, int newAmount);
    }
}
