// <copyright file="IServiceReporitory.cs" company="PlaceholderCompany">
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
    /// This is the interface for the service repository.
    /// </summary>
    public interface IServiceReporitory : IRepository<Service>
    {
        /// <summary>
        /// This method changes a service's name.
        /// </summary>
        /// <param name="id">The id of the service we want to modify.</param>
        /// <param name="newName">The new name of the service.</param>
        void ChangeName(int id, string newName);

        /// <summary>
        /// This method changes a service's capacity.
        /// </summary>
        /// <param name="id">The id of the service we want to modify.</param>
        /// <param name="newCapacity">The new capacity of the service.</param>
        void ChangeCapacity(int id, int newCapacity);

        /// <summary>
        /// This method adds a new worker to a service station.
        /// </summary>
        /// <param name="id">The id of the service station.</param>
        void HireNewEmployee(int id);

        /// <summary>
        /// This method takes one worker away from a service station.
        /// </summary>
        /// <param name="id">The id of the service station.</param>
        void FireEmployee(int id);

        /// <summary>
        /// This method adds a bike to a serviceStation.
        /// </summary>
        /// <param name="serviceId">The id of the Servicestation we are looking for.</param>
        /// <param name="bike">The bike we want to add.</param>
        void AddBikeToService(int serviceId, Bike bike);

        /// <summary>
        /// This method deletes a bike from a serviceStation.
        /// </summary>
        /// <param name="serviceId">The id of the Servicestation we are looking for.</param>
        /// <param name="bike">The bike we want to delete.</param>
        void DeleteBikeFromService(int serviceId, Bike bike);

        void ChangeEmpCount(int id, int newCount);
    }
}
