// <copyright file="IBikeRepository.cs" company="PlaceholderCompany">
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
    /// This is the interface for the BikeRepository.
    /// </summary>
    public interface IBikeRepository : IRepository<Bike>
    {
        /// <summary>
        /// This method changes a bike's model name.
        /// </summary>
        /// <param name="id">The id of the bike we want to change its name.</param>
        /// <param name="newName">The new model name.</param>
        /// <returns> Returns true if the changing was siccessful.</returns>
        bool ChangeName(int id, string newName);

        /// <summary>
        /// This method changes a bike's price.
        /// </summary>
        /// <param name="id">The id of the bike we want to change its price.</param>
        /// <param name="newPrice">The new price.</param>
        void ChangePrice(int id, int newPrice);

        /// <summary>
        /// This method changes a bike's owner.
        /// </summary>
        /// <param name="bikeId">The id of the bike.</param>
        /// <param name="newOwner">The buyer.</param>
        /// <param name="seller">The seller.</param>
        void SellBike(int bikeId, Owner newOwner, Owner seller);

        /// <summary>
        /// This method adds a new bike to the Db.
        /// </summary>
        /// <param name="bike">The new bike.</param>
        /// <param name="owner">The owner of the new bike.</param>
        void AddBike(Bike bike, Owner owner);

        void Update(Bike bike);
    }
}
