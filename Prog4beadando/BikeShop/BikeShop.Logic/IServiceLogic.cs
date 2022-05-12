// <copyright file="IServiceLogic.cs" company="PlaceholderCompany">
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
    /// This is the interface for the Service logic.
    /// </summary>
    public interface IServiceLogic
    {
        /// <summary>
        /// This method changes a servicestation's name.
        /// </summary>
        /// <param name="id">Id of the servicestation we are looking for.</param>
        /// <param name="newName">The new name of the servicestation.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// This method adds a new servicestation.
        /// </summary>
        /// <param name="newServicestation">The new servicestation.</param>
        void AddServicestation(Service newServicestation);

        /// <summary>
        /// This method deletes a Servicestation.
        /// </summary>
        /// <param name="id">The id of the Servicestation we want to delete.</param>
        void DeleteServicestation(int id);

        /// <summary>
        /// This method lists all Servicestations in the db.
        /// </summary>
        void ListAllServicestations();

        /// <summary>
        /// This method returns a Servicestation.
        /// </summary>
        /// <param name="id">The id of the Servicestation we are looking for.</param>
        /// <returns>A Servicestation.</returns>
        Service GetOne2(int id);

        /// <summary>
        /// This method increases the capacity of a Servicestation.
        /// </summary>
        /// <param name="id">The id of the Servicestation we are looking for.</param>
        /// <param name="amount">The amount of new free spaces.</param>
        void ChangeCapacity(int id, int amount);

        /// <summary>
        /// This method adds a new worker to a serviceStation.
        /// </summary>
        /// <param name="id">The id of the Servicestation we are looking for.</param>
        void HireNewWorker(int id);

        /// <summary>
        /// This method decreases the number of workers in a serviceStation by one.
        /// </summary>
        /// <param name="id">The id of the Servicestation we are looking for.</param>
        void FireWorker(int id);

        /// <summary>
        /// This method adds a bike to a serviceStation.
        /// </summary>
        /// <param name="serviceId">The id of the Servicestation we are looking for.</param>
        /// <param name="bike">The bike we want to add.</param>
        void AddBikeToServicestation(int serviceId, Bike bike);

        /// <summary>
        /// This method deletes a bike from a serviceStation.
        /// </summary>
        /// <param name="serviceId">The id of the Servicestation we are looking for.</param>
        /// <param name="bike">The bike we want to delete.</param>
        void DeleteBikeFromServicestation(int serviceId, Bike bike);

        public IEnumerable<Service> GetAlll();

        void ChangeEmpCount(int id, int newCount);
    }
}
