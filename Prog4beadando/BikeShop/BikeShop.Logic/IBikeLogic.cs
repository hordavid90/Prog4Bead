// <copyright file="IBikeLogic.cs" company="PlaceholderCompany">
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
    /// This is the interface for the bike Logic.
    /// </summary>
    public interface IBikeLogic
    {
        /// <summary>
        /// This method changes a bike's modelname.
        /// </summary>
        /// <param name="id">this id of the bike we are looking for.</param>
        /// <param name="newName">The new modelname.</param>
        /// <returns> Returns true if the changing was siccessful.</returns>
        bool ChangeName(int id, string newName);

        /// <summary>
        /// This method adds a new bike to the database.
        /// </summary>
        /// <param name="bike">The new bike we want to add.</param>
        /// <param name="owner">The buyer of the new bike.</param>
        void AddBike(Bike bike, Owner owner);

        void AddBike2(Bike bike);

       /// <summary>
       /// This method deletes a bike.
       /// </summary>
       /// <param name="id">The id of the bike that we want to delete.</param>
        void DeleteBike(int id);

        /// <summary>
        /// This method changes a bike's price.
        /// </summary>
        /// <param name="id">The id of the bike we are looking for.</param>
        /// <param name="newPrice">The new price if the bike.</param>
        void ChangePrice(int id, int newPrice);

        /// <summary>
        /// This method changes a bike's owner.
        /// </summary>
        /// <param name="bikeId">The id of the bike we want to sell.</param>
        /// <param name="newOwner">The buyer.</param>
        /// <param name="seller">The seller.</param>
        void SellBike(int bikeId, Owner newOwner, Owner seller);

        /// <summary>
        /// This method returns a bike.
        /// </summary>
        /// <param name="id">The id of the bike we are looking for.</param>
        /// <returns>It returns a bike.</returns>
        Bike GetOne2(int id);

        /// <summary>
        /// This method returns all the bikes in the Db.
        /// </summary>
        /// <returns>It return all of the bikes.</returns>
        public IEnumerable<Bike> GetAlll();

        public void Update(Bike bike);
    }
}
