// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the MyRepository interface.
    /// </summary>
    /// <typeparam name="T">T could be a Bike, Brand, Owner, Servicestation.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// This method gives back all T type items.
        /// </summary>
        /// <returns>It returns all of the Owner, Bike, or Brand type items.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// This method gives back one bike specified by id.
        /// </summary>
        /// <param name="id"> This is the id of the bike we are looking for. </param>
        /// <returns> It returns a Bike. </returns>
        T GetOne(int id);

        /// <summary>
        /// This method inserts a new Item to the Db. It can be a Bike, a Brank and an Owner.
        /// </summary>
        /// <param name="newItem">It is either a Bike, a Brand or an Owner. </param>
        void Add(T newItem);

        /// <summary>
        /// This method deletes an item by it's id.
        /// </summary>
        /// <param name="id">It is the id of the item that we want to delete. </param>
        void Delete(int id);
    }
}
