// <copyright file="BikeBrandConnection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class contains the brand names and the average price of the bikes.
    /// </summary>
    public class BikeBrandConnection
    {
        /// <summary>
        /// Gets or sets this brand names.
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// Gets or sets the average price of the bikes by brand.
        /// </summary>
        public double? AveragePrice { get; set; }
    }
}
