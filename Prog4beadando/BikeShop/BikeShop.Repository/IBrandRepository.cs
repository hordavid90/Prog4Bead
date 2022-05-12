// <copyright file="IBrandRepository.cs" company="PlaceholderCompany">
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
    /// The BrandRepository interface.
    /// </summary>
    public interface IBrandRepository : IRepository<Brand>
    {
        /// <summary>
        /// This method changes a brand's name.
        /// </summary>
        /// <param name="id">The id of the brand we are looking for.</param>
        /// <param name="newBrandName">The new name of the brand.</param>
        void ChangeName(int id, string newBrandName);
        void ChangeCountry(int id, string newValue);
        void ChangeEstablished(int id, int newValue);
    }
}
