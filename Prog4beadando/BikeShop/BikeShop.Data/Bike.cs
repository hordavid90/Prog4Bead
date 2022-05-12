// <copyright file="Bike.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BikeShop.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    /// <summary>
    /// This is the Bike class.
    /// </summary>
    [Table("Bike")]
    public class Bike
    {
        /// <summary>
        /// Gets or sets the id of a bike.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("bike_id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the model of a bike.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the price of a bike.
        /// </summary>
        public int? BasePrice { get; set; }

        /// <summary>
        /// Gets or sets the brand id of a bike. This is a foreign key.
        /// </summary>
        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        /// <summary>
        /// Gets or sets the Brand of a bike.
        /// </summary>
        [NotMapped]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Gets or sets the owner id of a bike.
        /// </summary>
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the owner of a bike.
        /// </summary>
        [NotMapped]
        public virtual Owner Owner { get; set; }

        /// <summary>
        /// This method overrides the basic ToString method.
        /// </summary>
        /// <returns>It returns the id and the bike's model name.</returns>
        public override string ToString()
        {
            return $"Id: = {this.Id}, típusa: = {this.Model}";
        }

        /// <summary>
        /// This method decides if two bikes are the same or not.
        /// </summary>
        /// <param name="obj">It is a bike item.</param>
        /// <returns>It returns if two obejct are equal or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Bike)
            {
                Bike other = obj as Bike;
                return this.Id == other.Id &&
                    this.Model == other.Model &&
                    this.BasePrice == other.BasePrice &&
                    this.BrandId == other.BrandId &&
                    this.OwnerId == other.OwnerId;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This returns the bike's id as a HashCode.
        /// </summary>
        /// <returns>The id of the bike.</returns>
        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
