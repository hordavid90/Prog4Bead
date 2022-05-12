// <copyright file="Service.cs" company="PlaceholderCompany">
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
    /// The service table.
    /// </summary>
    [Table("Service")]
    public class Service
    {
        /// <summary>
        /// Gets or sets the ID of the service station.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("service_id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the service station.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the maximum space int the service station.
        /// </summary>
        [Required]
        public int MaxSpace { get; set; }

        /// <summary>
        /// Gets or sets the number of employees in the service station.
        /// </summary>
        [Required]
        public int EmployeeNumer { get; set; }

        /// <summary>
        /// Gets or sets the bikes int the service station that is there for reparation.
        /// </summary>
        public virtual List<Bike> BikesInService { get; set; }
    }
}
