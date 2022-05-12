// <copyright file="IBrandLogic.cs" company="PlaceholderCompany">
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
    /// This is the BrandLogic interface.
    /// </summary>
    public interface IBrandLogic
    {
        /// <summary>
        /// This method changes a brand's name.
        /// </summary>
        /// <param name="id">Id of the brand we are looking for.</param>
        /// <param name="newBrandName">The new name of the brand.</param>
        void ChangeName(int id, string newBrandName);

        /// <summary>
        /// This method adds a new brand.
        /// </summary>
        /// <param name="newBrand">The new brand.</param>
        void AddBrand(Brand newBrand);

        /// <summary>
        /// This method deletes a brand.
        /// </summary>
        /// <param name="id">The id of the brand we want to delete.</param>
        void DeleteBrand(int id);

        /// <summary>
        /// This method lists all brands in the db.
        /// </summary>
        void ListAllBrands();

        /// <summary>
        /// This method returns a brand.
        /// </summary>
        /// <param name="id">The id of the brand we are looking for.</param>
        /// <returns>A brand.</returns>
        Brand GetOne2(int id);

        IEnumerable<Brand> GetAlll();

        void ChangeCountry(int id, string newValue);

        void ChangeEstablished(int id, int newValue);
    }
}
