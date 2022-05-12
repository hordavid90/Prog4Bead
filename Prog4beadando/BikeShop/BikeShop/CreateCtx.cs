// <copyright file="CreateCtx.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BikeShop.Data;

    /// <summary>
    /// This class has a method that creates a DbContext.
    /// </summary>
    public static class CreateCtx
    {
        /// <summary>
        /// This method returns a BikeDbContext.
        /// </summary>
        /// <returns>BikeDbContext.</returns>
        public static BikeDbContext CreateBikeDbContext()
        {
            return new BikeDbContext();
        }
    }
}
