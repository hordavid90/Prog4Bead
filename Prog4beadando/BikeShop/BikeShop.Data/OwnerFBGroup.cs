// <copyright file="OwnerFBGroup.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the connection table for the Owners and Facebook groups.
    /// </summary>
    [Table("OwnerFacebookGroup")]
    public class OwnerFBGroup
    {
        /// <summary>
        /// Gets or sets the connection Id for the Owner-FBgroup conection.
        /// </summary>
        [Key]
        public int ConId { get; set; }

        /// <summary>
        /// Gets or sets the Owner id in the connection.
        /// </summary>
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the owner in the connection.
        /// </summary>
        [NotMapped]
        public virtual Owner Owner { get; set; }

        /// <summary>
        /// Gets or sets the FB group Id for the Owner-FBgroup conection.
        /// </summary>
        [ForeignKey(nameof(FacebookGroup))]
        public int FBGroupId { get; set; }

        /// <summary>
        /// Gets or sets the Facebook group for the Owner-FBgroup conection.
        /// </summary>
        [NotMapped]
        public virtual FacebookGroup FacebookGroup { get; set; }
    }
}
